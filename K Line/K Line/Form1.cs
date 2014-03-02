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
        int totalProfitMatchFound = 0;

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
                    for (int j = i - 3 - rulesLeastHoldDays; j >= 1; j--)
                    {
                        if (j == 1)
                        {
                            if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("未賣出: 剩餘天數資料不足\n");
                        }

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
                                // verify we earn or loss money. if current day's open price is higher than buy in day's open price, then earn money.
                                if (Convert.ToDouble(cur_day_data[1]) >= Convert.ToDouble(buy_in_data[1]))
                                {
                                    totalProfitMatchFound++;
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
                                totalProfitMatchFound++;
                                if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("賣出 @ " + cur_day_data[0] + ": 超過預期利潤\n");
                                if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("當天最高價 profit = " + profit + "%" + " > " + rulesWaitingProfit + "%" + "\n");

                                break;
                            }
                        }

                        // check if we reach stop loss point
                        if (checkBoxStopLoss.Checked)
                        {
                            // if current day's lowest price is less than buy in price, sell it on buy in price. assume transaction fee is 1%.
                            if (Convert.ToDouble(cur_day_data[3]) <= Convert.ToDouble(buy_in_data[1]) * ((100.0 + rulesStopLossPoint) / 100))
                            {
                                totalStickPatternFound--;
                                if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("賣出 @ " + cur_day_data[0] + ": 降至買進價\n");
                                if (checkBoxDetailLog.Checked) MessageTextBox.AppendText("本日最低: " + cur_day_data[3] + ", 本日最高: " + cur_day_data[2] + ", 買進價: " + buy_in_data[1] + "\n");
                                break;
                            }
                        }
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
                || (checkBoxStopLoss.Checked && textBoxStopLossPoint.Text == "")
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
                rulesStopLossPoint = Convert.ToDouble(textBoxStopLossPoint.Text);
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

            totalProfitMatchFound = 0;
            totalStickPatternFound = 0;

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

            MessageTextBox.AppendText("共有 " + totalStickPatternFound + " 個連三紅, ");
            MessageTextBox.AppendText("其中共 " + totalProfitMatchFound + " 個符合獲利條件.\n");
            MessageTextBox.AppendText("成功率 = " + Convert.ToString(100.00 * (double)totalProfitMatchFound / (double)totalStickPatternFound) + "%\n");
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
            totalStickPatternFound = 0;
            totalProfitMatchFound = 0;
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
