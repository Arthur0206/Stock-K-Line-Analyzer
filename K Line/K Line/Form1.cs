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
        int rulesWaitingDays;
        int rulesLowPointInDays;
        double rulesWilliam;

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

            string[] split = readText[readText.Length - 1].Split(',');
            double previousClosePrice = Convert.ToDouble(split[4]);

            int currentLowPointInDays = 0;
            int currentNumOfRed = 0;

            for (int i = readText.Length - 2; i > 0; i--)
            {
                split = readText[i].Split(',');

                double currentClosePrice = Convert.ToDouble(split[4]);
                double currentOpenPrice = Convert.ToDouble(split[1]);

                if (currentNumOfRed != 0 || currentLowPointInDays >= rulesLowPointInDays)
                {
                    if (currentClosePrice > previousClosePrice && currentClosePrice > currentOpenPrice)
                    {
                        currentNumOfRed++;
                    }
                    else
                    {
                        currentNumOfRed = 0;
                    }

                    if (currentNumOfRed >= rulesNumOfRed)
                    {
                        // MessageTextBox.AppendText(file.Name + ": found a 3 red @ " + split[0] + "\n");

                        double buyInPrice = currentClosePrice;
                        DateTime buyInDay = DateTime.Parse(split[0]);

                        for (int j = i; j > 0; j--)
                        {
                            split = readText[j].Split(',');
                            DateTime examDay = DateTime.Parse(split[0]);

                            if (examDay.Subtract(buyInDay).Days >= rulesWaitingDays)
                            {
                                // MessageTextBox.AppendText("虧錢!\n");
                                break;
                            }
                            else
                            {
                                double examClosePrice = Convert.ToDouble(split[4]);

                                if (examClosePrice >= buyInPrice * (1 + rulesWaitingProfit/100))
                                {
                                    // MessageTextBox.AppendText("賺錢!\n");
                                    totalProfitMatchFound++;
                                    break;
                                }
                            }
                        }

                        totalStickPatternFound++;
                        currentNumOfRed = 0;
                        currentLowPointInDays = 0;
                    }
                }

                if (currentClosePrice <= previousClosePrice)
                {
                    currentLowPointInDays++;
                }
                else
                {
                    currentLowPointInDays = 0;
                }

                previousClosePrice = currentClosePrice;
            }

            return true;
        }

        private void Process_Click(object sender, EventArgs e)
        {
            // check and then read in rules settings
            if (textBoxNumOfRed.Text == "" || textBoxWaitingDays.Text == "" || textBoxProfit.Text == ""
                || textBoxLowPointPeriod.Text == "" || downloadDirTextBox.Text == "")
            {
                MessageBox.Show("Please input valid Stock Files Foler and Rules Setting.\n");
                return;
            }
            else
            {
                rulesNumOfRed = Convert.ToInt32(textBoxNumOfRed.Text);
                rulesWaitingProfit = Convert.ToDouble(textBoxProfit.Text);
                rulesWaitingDays = Convert.ToInt32(textBoxWaitingDays.Text);
                rulesLowPointInDays = Convert.ToInt32(textBoxLowPointPeriod.Text);
                rulesWilliam = Convert.ToDouble(textBoxWilliam.Text);
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

            // check and then read in rules settings
            if (textBoxNumOfRed.Text == "" || textBoxWaitingDays.Text == "" || textBoxProfit.Text == "" || textBoxLowPointPeriod.Text == "")
            {
                MessageBox.Show("Please input valid Rules Setting.\n");
                return;
            }
            else
            {
                rulesNumOfRed = Convert.ToInt32(textBoxNumOfRed.Text);
                rulesWaitingDays = Convert.ToInt32(textBoxWaitingDays.Text);
                rulesWaitingProfit = Convert.ToInt32(textBoxProfit.Text);
                rulesLowPointInDays = Convert.ToInt32(textBoxLowPointPeriod.Text);
            }

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

            MessageTextBox.AppendText("[Rule] #Red = " + rulesNumOfRed + ", Profit = "
                + rulesWaitingProfit + "%, Wait Days = " + rulesWaitingDays + ", Period = " + rulesLowPointInDays + "\n");
            MessageTextBox.AppendText("共有 " + totalStickPatternFound + " 個連三紅, ");
            MessageTextBox.AppendText("其中共 " + totalProfitMatchFound + " 個符合獲利條件.\n");
            MessageTextBox.AppendText("成功率 = " + Convert.ToString(100.00 * (double)totalProfitMatchFound / (double)totalStickPatternFound) + "%\n");
            MessageTextBox.AppendText("------------------------------------------------------------\n");
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
    }
}
