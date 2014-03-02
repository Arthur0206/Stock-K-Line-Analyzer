using System;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace K_Line
{
    public partial class Form1 : Form
    {
        String startDay; 
        String startMonth;
        String startYear;
        String endDay;
        String endMonth;
        String endYear;
        WebClient Client = new WebClient();
        
        // rules parameter set by user
        int rulesNumOfRed;
        double rulesWaitingProfit;
        int rulesMaxHoldDays;
        int rulesLowPointInDays;
        int rulesLeastHoldDays;
        double rulesWilliam;
        double rulesStopLossPoint;

        int totalStickPatternFound = 0;
        int dataNotEnoughCase = 0;
        double totalRuleFitProfit = 0;      // sum of %
        int totalRuleFitNum = 0;            // number of cases
        double avgRuleFitProfit = 0;        // %
        double totalStopLossProfit = 0;     // sum of %
        int totalStopLossNum = 0;           // number of cases
        double avgStopLossProfit = 0;       // %

        public Form1()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            InitializeComponent();
            radioButtonImportFile.Checked = true;
            stockListFileTextBox.Enabled = true;
            buttonSelectStockListFile.Enabled = true;
            StockNameTextBox.Enabled = false;
            startDate.Value = DateTime.Today.AddYears(-1);
            endDate.Value = DateTime.Today;
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            // Put clean up codes here. this function will be called before application exits.
        }

        private bool ProcessStockFile(FileInfo file)
        {
            string[] readText = File.ReadAllLines(file.FullName);

            // check one line in the file. From bottom to top.
            for (int i = readText.Length - 2; i - 2 > 0; i--)
            {
                // Date,Open,High,Low,Close,Volume,Adj Close
                //   0   1    2    3    4     5       6

                // before checking any rules, initialized to ture, means match.
                // when checking every rules, will set it to false if the day doesn't match that specific rule.
                bool match = true;

                // get open price and closing price for the previous day and the following 3 days
                string[] split0 = readText[i + 1].Split(',');
                string[] split1 = readText[i].Split(',');
                string[] split2 = readText[i - 1].Split(',');
                string[] split3 = readText[i - 2].Split(',');

                double PO0 = Convert.ToDouble(split0[1]);
                double PC0 = Convert.ToDouble(split0[4]);
                double PO1 = Convert.ToDouble(split1[1]);
                double PC1 = Convert.ToDouble(split1[4]);
                double PO2 = Convert.ToDouble(split2[1]);
                double PC2 = Convert.ToDouble(split2[4]);
                double PO3 = Convert.ToDouble(split3[1]);
                double PC3 = Convert.ToDouble(split3[4]);

                // check continuous 3 red rule. if match, remain true and print out msg. If not, set to false
                if (true) 
                {
                    if (PC1 > PO1 && PC2 > PO2 && PC3 > PO3 && PO3 > PO2 && PO2 > PO1 && PC3 > PC0)
                    {
                        if (checkBoxDetailLog.Checked) MessageTextBox.AppendText(file.Name + ": found a 3 red @ " + split1[0] + "\n");
                    }
                    else
                    {
                        match = false;
                    }
                }

                // check william %
                if (checkBoxWilliam.Checked && match == true)
                {
                    // n in william % 's formula
                    int williamN = 14;
                    
                    // if we have enough days to calculate william %
                    if ((readText.Length - 1) - i + 1 >= williamN)
                    {
                        // calculate the 3 red days' william %, if any of them higher than "rulesWilliam", then no match.
                        for (int j = i; j > i - 3; j--){
                            double calculatedWilliam;
                            string[] split;
                            double lowest = 100000, highest = 0;

                            // find the lowest and highest price in "williamN" days (this includes the current day).
                            for (int k = j + williamN - 1; k >= j; k--)
                            {
                                split = readText[k].Split(',');
                                if (highest > Convert.ToDouble(split[2])) highest = Convert.ToDouble(split[2]);
    
                                if (lowest < Convert.ToDouble(split[3])) lowest = Convert.ToDouble(split[3]);
                            }
                            
                            // get current day's closing price
                            split = readText[j].Split(',');
                            double CP = Convert.ToDouble(split[4]);

                            // calculate william's % for current day
                            calculatedWilliam = ((CP - highest) / (highest - lowest)) * 100;

                            if (calculatedWilliam > rulesWilliam)
                                match = false;
                        }

                        if (match == true)
                        {
                            // if match is still true, pass william % rule.
                            if (checkBoxDetailLog.Checked) MessageTextBox.AppendText(file.Name + ": William % in 3 red days < " + rulesWilliam + "% @ " + split1[0] + "\n");
                        }
                    }
                    else
                    {
                        // doesn't have enough days to caluculate william %, so no match
                        match = false;
                    }
                }

                // if doens't match all rules, go to check next day
                if (match == true)
                    totalStickPatternFound++;
                else
                    continue;

                /****************************************************************************************************************/
                /**************** if match all rules, start checking selling date. check from i - 3th day to 0th day ****************/
                /****************************************************************************************************************/
                try
                {
                    int j;

                    for (j = i - 3 - rulesLeastHoldDays; j >= 1; j--)
                    {
                        // Date,Open,High,Low,Close,Volume,Adj Close
                        //   0   1    2    3    4     5       6
                        string[] first_red_data = readText[i].Split(',');
                        string[] buy_in_data = readText[i - 3].Split(',');
                        string[] cur_day_data = readText[j].Split(',');

                        // check if maximum waiting days has passed
                        if (checkBoxMaxHoldDays.Checked)
                        {
                            if (i - j >= rulesMaxHoldDays + 3)
                            {
                                double selling_price = Convert.ToDouble(cur_day_data[1]);
                                double by_in_price = Convert.ToDouble(buy_in_data[1]);

                                totalRuleFitNum++;
                                totalRuleFitProfit += (selling_price - by_in_price) / by_in_price;

                                // verify we earn or loss money. if current day's open price is higher than buy in day's open price, then earn money.
                                if (selling_price >= by_in_price)
                                {
                                    if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("賣出 @ " + cur_day_data[0] + ": 到達等待天數\n");
                                    if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("賺 " + cur_day_data[1] + " >= " + buy_in_data[1] + "\n");
                                }
                                else
                                {
                                    if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("賣出 @ " + cur_day_data[0] + ": 到達等待天數\n");
                                    if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("虧 " + cur_day_data[1] + " < " + buy_in_data[1] + "\n");
                                }

                                break;
                            }
                        }

                        // check if minimum profit is reached.
                        if (checkBoxProfit.Checked)
                        {
                            // ( (current_day_highest_price - buy_in_price) / buy_in_price ) * 100 
                            double profit = ((Convert.ToDouble(cur_day_data[2]) - Convert.ToDouble(buy_in_data[1])) / Convert.ToDouble(buy_in_data[1])) * 100;

                            if (profit >= rulesWaitingProfit)
                            {
                                totalRuleFitNum++;
                                totalRuleFitProfit += rulesWaitingProfit;

                                if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("賣出 @ " + cur_day_data[0] + ": 超過預期利潤\n");
                                if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("當天最高價 profit = " + profit + "%" + " > " + rulesWaitingProfit + "%" + "\n");

                                break;
                            }
                        }

                        // check if we reach stop loss point
                        if (checkBoxStopLoss.Checked)
                        {
                            double cur_day_open_price = Convert.ToDouble(cur_day_data[1]);
                            double cur_day_lowest_price = Convert.ToDouble(cur_day_data[3]);
                            double buy_in_price = Convert.ToDouble(buy_in_data[1]);

                            double first_day_open_price = Convert.ToDouble(first_red_data[1]);
                            double cur_day_close_price = Convert.ToDouble(cur_day_data[4]);

                            if (textBoxStopLossPoint.Text == "") //use rule: any PC < PO1
                            {
                                //if any Day's close price < first red open price, sell it on next day.
                                if (cur_day_close_price < first_day_open_price)
                                {
                                    totalStopLossNum++;
                                    totalStopLossProfit += (cur_day_close_price - buy_in_price) / buy_in_price;

                                    break;
                                }
                            }
                            else //use rule: any profit < stop loss point prifit
                            {
                                rulesStopLossPoint = Convert.ToDouble(textBoxStopLossPoint.Text);

                                // if current day's lowest price is less than buy in price, sell it on buy in price. assume transaction fee is 1%.
                                if (cur_day_lowest_price <= buy_in_price * ((100.0 + rulesStopLossPoint) / 100))
                                {
                                    totalStopLossNum++;

                                    if (cur_day_open_price <= buy_in_price * ((100.0 + rulesStopLossPoint) / 100))
                                        totalStopLossProfit += (cur_day_open_price - buy_in_price) / buy_in_price;
                                    else
                                        totalStopLossProfit += rulesStopLossPoint;
    
                                    if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("賣出 @ " + cur_day_data[0] + ": 降至買進價\n");
                                    if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("本日最低: " + cur_day_data[3] + ", 本日最高: " + cur_day_data[2] + ", 買進價: " + buy_in_data[1] + "\n");
                                    break;
                                }
                            }
                        }
                    }

                    if (j < 1)
                    {
                        dataNotEnoughCase++;
                        if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("未賣出: 剩餘天數資料不足\n");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error when checking selling date!\n");
                }

                if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("=================================================\n");
                
                // skip the 3 red days we've already checked
                i -= 3;
            }

            return true;

        }

        private void Process_Click(object sender, EventArgs e)
        {
            // check and then read in rules settings
            if (textBoxNumOfRed.Text == ""
                || (checkBoxMaxHoldDays.Checked && textBoxMaxHoldDays.Text == "")
                || (checkBoxProfit.Checked && textBoxProfit.Text == "")
                || (checkBoxLowPointPeriod.Checked && textBoxLowPointPeriod.Text == "")
                || (checkBoxWilliam.Checked && textBoxWilliam.Text == "")
            //  || (checkBoxStopLoss.Checked && textBoxStopLossPoint.Text == "")
                || (checkBoxLeastHoldDays.Checked && textBoxLeastHoldDays.Text == "")
                || downloadDirTextBox.Text == "")
            {
                MessageBox.Show("Please input valid Stock Files Foler and Rules Setting.\n");
                return;
            }
            else
            {
                rulesNumOfRed = Convert.ToInt32(textBoxNumOfRed.Text);
                rulesWaitingProfit = Convert.ToDouble(textBoxProfit.Text);
                rulesMaxHoldDays = Convert.ToInt32(textBoxMaxHoldDays.Text);
                rulesLowPointInDays = Convert.ToInt32(textBoxLowPointPeriod.Text);
                rulesWilliam = Convert.ToDouble(textBoxWilliam.Text);
                //rulesStopLossPoint = Convert.ToDouble(textBoxStopLossPoint.Text);
                rulesLeastHoldDays = Convert.ToInt32(textBoxLeastHoldDays.Text);
            }

            DirectoryInfo dir;
            FileInfo[] files = null;

            try
            {
                dir = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                files = dir.GetFiles("*.csv");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot open the file(s) in the selected folder.\n");
            }

            totalStickPatternFound = 0;
            dataNotEnoughCase = 0;
            totalRuleFitProfit = 0;     // sum of %
            totalRuleFitNum = 0;        // number of cases
            avgRuleFitProfit = 0;       // %
            totalStopLossProfit = 0;    // sum of %
            totalStopLossNum = 0;       // number of cases
            avgStopLossProfit = 0;      // %

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    //MessageTextBox.AppendText("Processing " + fi.Name + "\n"); 

                    if (!ProcessStockFile(fi))
                    {
                        MessageTextBox.AppendText("Error: processing " + fi.Name + "failed.\n");
                    }
                }
            }

            MessageTextBox.AppendText("[Rule] #Red = " + rulesNumOfRed);

            if (checkBoxProfit.Enabled)
                MessageTextBox.AppendText(", Profit = " + rulesWaitingProfit);
            if (checkBoxMaxHoldDays.Enabled)
                MessageTextBox.AppendText(", MaxHoldDays = " + rulesMaxHoldDays);
            if (checkBoxStopLoss.Enabled)
                MessageTextBox.AppendText(", StopLoss = " + rulesStopLossPoint);
            if (checkBoxLeastHoldDays.Enabled)
                MessageTextBox.AppendText(", LeastHoldDays = " + rulesLeastHoldDays);
            if (checkBoxLowPointPeriod.Enabled)
                MessageTextBox.AppendText(", LowPointDays = " + rulesLowPointInDays);

            MessageTextBox.AppendText("\n");

            double finalAvgProfig = (totalStopLossProfit + totalRuleFitProfit) / (totalStopLossNum + totalRuleFitNum);

            MessageTextBox.AppendText("- 共有 " + totalStickPatternFound + " 個連三紅。\n");
            MessageTextBox.AppendText("- 資料不足無法預測 " + dataNotEnoughCase + " 個。\n");
            MessageTextBox.AppendText("- 符合賣出條件 #: " + totalRuleFitNum + " 個。\n");
            MessageTextBox.AppendText("      => Avg Profit: " + totalRuleFitProfit / totalRuleFitNum + " %。\n");
            MessageTextBox.AppendText("- 達到停損點 #: " + totalStopLossNum + " 個。\n");
            MessageTextBox.AppendText("      => Avg Profit: " + totalStopLossProfit / totalStopLossNum + " %。\n");
            MessageTextBox.AppendText("- 最終平均獲利率: " + finalAvgProfig + " %。\n");
            MessageTextBox.AppendText("-------------------------------------------------------------\n");
        }

        private void radioButtonImportFile_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                stockListFileTextBox.Enabled = true;
                buttonSelectStockListFile.Enabled = true;
                StockNameTextBox.Enabled = false;
            }
            else
            {
                stockListFileTextBox.Enabled = false;
                buttonSelectStockListFile.Enabled = false;
                StockNameTextBox.Enabled = true;
            }
        }

        private void radioButtonTypeIn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                stockListFileTextBox.Enabled = false;
                buttonSelectStockListFile.Enabled = false;
                StockNameTextBox.Enabled = true;
            }
            else
            {
                stockListFileTextBox.Enabled = true;
                buttonSelectStockListFile.Enabled = true;
                StockNameTextBox.Enabled = false;
            }
        }

        private void buttonSelectStockListFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                stockListFileTextBox.Text = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Cannot open the selected file.\n");
            }
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSelectDownloadedFiles_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                downloadDirTextBox.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("Cannot open the selected folder.\n");
            }
        }

        private bool downloadStockFile(String stockName)
        {
            String url = "http://ichart.finance.yahoo.com/table.csv?s=" + stockName +
                "&a=" + startMonth + "&b=" + startDay + "&c=" + startYear + "&d=" + endMonth + "&e=" + endDay + "&f=" + endYear + "&g=d&ignore=.csv";

            try
            {
                Client.DownloadFile(url, folderBrowserDialog.SelectedPath + "\\" + stockName + ".csv");
            }
            catch (WebException)
            {
                MessageTextBox.AppendText("Error: download " + stockName + " failed.\n");
                return false;
            }

            return true;
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            buttonProcess.Enabled = false;

            startDay = startDate.Value.Day.ToString();
            startMonth = (startDate.Value.Month - 1).ToString();
            startYear = startDate.Value.Year.ToString();
            endDay = endDate.Value.Day.ToString();
            endMonth = (endDate.Value.Month - 1).ToString();
            endYear = endDate.Value.Year.ToString();

            if (folderBrowserDialog.SelectedPath.Equals(""))
            {
                MessageBox.Show("Please select downloaded folder path.");
            }
            else
            {
                if (radioButtonImportFile.Checked == true)
                {
                    // get stocks from file
                    if (openFileDialog.FileName.Equals(""))
                    {
                        MessageBox.Show("Please select the stock list file.");
                    }
                    else
                    {
                        StreamReader file = new StreamReader(openFileDialog.FileName);
                        string pattern = "^\x020*\"\x020*([a-zA-Z]+)\x020*\"";
                        Match match;
                        String line;
                        int numberOfStocks = 0;

                        // get the first line to check
                        line = file.ReadLine();
                        try
                        {
                            match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);

                            if (match.Success == true && match.Groups[1].ToString().Equals("Symbol"))
                            {
                                // the file format is correct. 
                                // http://www.nasdaq.com/screening/company-list.aspx

                                while ((line = file.ReadLine()) != null)
                                {
                                    match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
                                    if (match.Success == true)
                                    {
                                        MessageTextBox.AppendText("Downloading " + match.Groups[1].ToString() + ".csv.\n"); 
                                        downloadStockFile(match.Groups[1].ToString());
                                        numberOfStocks++;
                                    }
                                }

                                MessageTextBox.AppendText("Totally " + numberOfStocks + " stocks found in files.\n");
                            }
                            else
                            {
                                MessageBox.Show("The imported file is not of the right format.\n");
                            }
                        }
                        catch(Exception)
                        {
                            MessageBox.Show("The imported file is not of the right format.\n");
                        }
                    }
                }
                else
                {
                    // process a single stock entered by the user
                    downloadStockFile(StockNameTextBox.Text);
                }

                buttonProcess.Enabled = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            MessageTextBox.Clear();
        }

        private void checkBoxMaxHoldDays_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxMaxHoldDays.Checked)
            {
                textBoxMaxHoldDays.Enabled = true;
            }
            else
            {
                textBoxMaxHoldDays.Enabled = false;
            }
        }

        private void checkBoxProfit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxProfit.Checked)
            {
                textBoxProfit.Enabled = true;
            }
            else
            {
                textBoxProfit.Enabled = false;
            }
        }

        private void checkBoxWilliam_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxWilliam.Checked)
            {
                textBoxWilliam.Enabled = true;
            }
            else
            {
                textBoxWilliam.Enabled = false;
            }
        }

        private void checkBoxStopLoss_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxStopLoss.Checked)
            {
                textBoxStopLossPoint.Enabled = true;
            }
            else
            {
                textBoxStopLossPoint.Enabled = false;
            }
        }

        private void checkBoxLeastHoldDays_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxLeastHoldDays.Checked)
            {
                textBoxLeastHoldDays.Enabled = true;
            }
            else
            {
                textBoxLeastHoldDays.Enabled = false;
            }
        }
    }
}
