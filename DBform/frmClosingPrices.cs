using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace DBform
{
    public partial class frmClosingPrices : Form
    {
        public frmClosingPrices()
        {
            InitializeComponent();
        }


        private void btnGetData_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = null;

            try
            {
                /* get database parameters from App.config file */
                String strServer = ConfigurationManager.AppSettings["server"];
                String strDatabase = ConfigurationManager.AppSettings["database"];
          
                String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";
                sqlCon = new SqlConnection(strConnect);
                sqlCon.Open();
 
                String symbol = comboBox1.Text;
                // set up values for dropdown list
                DataSet allDates = getAllDatesForSymbol(sqlCon, symbol);
                
                DataSet transactions = getTransactionsForSymbol(sqlCon, symbol, allDates);
          
                List<double> quantities = getQuantities(allDates, transactions);        
            }

            catch (Exception ex)

            {
              //  MessageBox.Show(" " + DateTime.Now.ToLongTimeString() + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally

            {

                if (sqlCon != null && sqlCon.State == System.Data.ConnectionState.Open)

                    sqlCon.Close();

            }


        }

        private DataSet getAllDatesForSymbol(SqlConnection sqlCon, string symbol)
        {
            //gets data from TS_DailyData
            SqlCommand sqlCmd = new SqlCommand("spGetAllDatesAndCloseForSymbol", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@ticker", System.Data.SqlDbType.VarChar).Value = symbol;

            sqlCmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet dataset = new DataSet();
            da.Fill(dataset, "Dates");
  
            return dataset;
        }

        private DataSet getTransactionsForSymbol(SqlConnection sqlCon, string symbol, DataSet allDates)
        {
           // gets data from transactions table for specific symbol
            SqlCommand sqlCmd = new SqlCommand("spGetQuantityForSymbol", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@ticker", System.Data.SqlDbType.VarChar).Value = symbol;       
            sqlCmd.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(sqlCmd);
            DataSet dataset = new DataSet();
            da2.Fill(dataset, "transactions");

            // methods that calculate all columns for table
            List<double> quantities = getQuantities(allDates, dataset);
            List<decimal> pos_values = getValues(allDates, quantities);
            List<decimal> dailypl = getDailyPL(allDates, dataset, quantities, pos_values);
            List<decimal> cumpl = getCumPL(dailypl);

            // adds all columns to "newTable"
            DataTable newTable = ToDataTable(allDates.Tables["Dates"], quantities, pos_values, dailypl, cumpl);   
            dgvData.AutoGenerateColumns = true;
            dgvData.DataSource = newTable;

            UpdateDataGridView();
            UpdateChart(newTable);

            return dataset;
        }

        public DataTable ToDataTable(DataTable dates, List<double> quantities, List<decimal> pos_values, List<decimal> dailypl, List<decimal> cumpl)
        {
            // adds column names and datatypes
            Type typeQ = quantities.ElementAt(0).GetType();
            Type typeV = pos_values.ElementAt(0).GetType();
            Type typeD = dailypl.ElementAt(1).GetType();
            Type typeC = cumpl.ElementAt(0).GetType();
           
            dates.Columns.Remove("ClosingPrice");
            dates.Columns.Add("Quantity", typeQ);
            dates.Columns.Add("Value", typeV);
            dates.Columns.Add("Daily P/L", typeD);
            dates.Columns.Add("Cum. P/L", typeC);

            //fills columns with values 
            for (int i = 0; i < dates.Rows.Count; i++)
            {
                DateTime date = (DateTime)dates.Rows[i].ItemArray[0];

                double currQuantity = quantities.ElementAt(i);
                decimal currValue = pos_values.ElementAt(i);
                decimal currDailypl = dailypl.ElementAt(i);
                decimal currCumpl = cumpl.ElementAt(i);

                dates.Rows[i].SetField<string>(1, currQuantity.ToString());
                dates.Rows[i].SetField<string>(2, currValue.ToString());
                dates.Rows[i].SetField<string>(3, currDailypl.ToString());
                dates.Rows[i].SetField<string>(4, currCumpl.ToString());            
            }
            return dates;
        }


        private void UpdateDataGridView()
        {
           //formats columns
            dgvData.Columns["Value"].DefaultCellStyle.Format = "c0";
            dgvData.Columns["Daily P/L"].DefaultCellStyle.Format = "c0";
            dgvData.Columns["Cum. P/L"].DefaultCellStyle.Format = "c0";

            for (int cix = 0; cix < dgvData.Columns.Count; cix++)
            {
                dgvData.AutoResizeColumn(cix);
            }
        }
        private void UpdateChart(DataTable newTable)
        {
            // Series 0 charts cum. P/L
            // Series 1 charts daily. P/L
            chrtPrices.Series[0].Points.Clear();
            chrtPrices.Series[1].Points.Clear();


            var nrRows = newTable.Rows.Count;
            decimal maxPr = Decimal.MinValue;
            decimal minPr = Decimal.MaxValue;
            for (int row = 1; row < nrRows; ++row)
            {
                DateTime date = (DateTime)newTable.Rows[row].ItemArray[0];
                decimal cumpL = (decimal)newTable.Rows[row].ItemArray[4];
                decimal dailypl = (decimal)newTable.Rows[row].ItemArray[3];
                chrtPrices.Series[0].Points.AddXY(date, cumpL);
                chrtPrices.Series[1].Points.AddXY(date, dailypl);
                 if (cumpL > maxPr) maxPr = cumpL;
                 if (cumpL < minPr) minPr = cumpL;
            }

            // try to format y axis
            chrtPrices.ChartAreas[0].AxisY.LabelStyle.Format = "C2";
            chrtPrices.ChartAreas[1].AxisY.LabelStyle.Format = "C2";

            chrtPrices.ChartAreas[0].AxisY.Maximum = Math.Ceiling(1.1 * (double)maxPr);
            chrtPrices.ChartAreas[0].AxisY.Minimum = Math.Floor(0.9 * (double)minPr);
            chrtPrices.ChartAreas[1].AxisY.Maximum = Math.Ceiling(1.1 * (double)maxPr);
            chrtPrices.ChartAreas[1].AxisY.Minimum = Math.Floor(0.9 * (double)minPr);

      
        }

        private List<double> getQuantities(DataSet dates, DataSet quantities)
        {
            // gets quantites for every single day by combining values of TS_DailyData and Transactions
            List<double> transactions = new List<double>();
            DataTable dq = quantities.Tables["Transactions"];
            DateTime prev_trans_Date = (DateTime)dq.Rows[0].ItemArray[1];
            double prev_quantity = (double)dq.Rows[0].ItemArray[3];
            int prev_id = (int)dq.Rows[0].ItemArray[0];

            // if date in transactions, take that transaction as current,
            // if not, take previous transaction
            for (int date = 0; date < dates.Tables["Dates"].Rows.Count; date++)
            {
                DateTime currDate = (DateTime)dates.Tables["Dates"].Rows[date].ItemArray[0];
                DataRow[] dr = dq.Select("Dates='" + currDate + "'"); 

                if (dr.Count() == 0)
                {
                    if (currDate < prev_trans_Date)
                    {
                        transactions.Add(0);
                    }
                    else
                    {
                        transactions.Add(prev_quantity);
                    }
                }
                else
                {
                    prev_id = (int)dr.ElementAt(0).ItemArray[0];
                    prev_quantity = (double)dr.ElementAt(0).ItemArray[3];
                    transactions.Add(prev_quantity);

                }
            }
            return transactions;
        }

        private List<decimal> getValues(DataSet Dates, List<double> quantities)
        {
            // positions value = shares * close_price
            List<decimal> values = new List<decimal>();
            DataTable dc = Dates.Tables["Dates"];
            for (int ix = 0; ix < dc.Rows.Count; ix++)
            {
                double currClose = (double)dc.Rows[ix].ItemArray[1];
                double currQuantity = quantities[ix];
                decimal currValue = (decimal)(currClose * currQuantity);
                values.Add(currValue);
            }
            return values;
        }

        private List<decimal> getDailyPL(DataSet Dates, DataSet Transactions, List<double> quantities, List<decimal> values)
        {
            // If transaction has occured: Daily P/L = shares * (close price - trans. price)
            // If transaction has NOT occured: Daily P/L = shares * (close price - prev. close price)
            List<decimal> dailyPL = new List<decimal>();
            DataTable dailyInfo = Dates.Tables["Dates"];
            DataTable transactions = Transactions.Tables["Transactions"];
            for (int date = 0; date < dailyInfo.Rows.Count; date++)
            {
                DateTime currDate = (DateTime)dailyInfo.Rows[date].ItemArray[0];
                DataRow[] dr = transactions.Select("Dates='" + currDate + "'");
                decimal currPL = 0;
                if (dr.Count() != 0)
                {
                    decimal tran = (decimal)dr.ElementAt(0).ItemArray[2];
                    decimal sub = Convert.ToDecimal(dailyInfo.Rows[date].ItemArray[1]) - tran;
                    currPL = Convert.ToDecimal(quantities.ElementAt(date)) * sub;
                    dailyPL.Add(currPL);
                }
                else
                {
                    if (date != 0)
                    {
                        currPL = Convert.ToDecimal((double)quantities.ElementAt(date) * ((double)dailyInfo.Rows[date].ItemArray[1] - (double)dailyInfo.Rows[date - 1].ItemArray[1]));
                    }
                    else
                    {
                        currPL= Convert.ToDecimal((double)quantities.ElementAt(date) * (double)dailyInfo.Rows[date].ItemArray[1]);
                    }
                }
                dailyPL.Add(currPL);
            }
            return dailyPL;
        }

        private List<decimal> getCumPL(List<decimal> dailyPL)
        {
            // Cum. P/L = sum of daily P/Ls
            List<decimal> cumPL = new List<decimal>();
            decimal currPL = 0;
            for (int ix = 0; ix < dailyPL.Count; ++ix)
            {
                currPL += dailyPL.ElementAt(ix);
                cumPL.Add(currPL);
            }
            return cumPL;
        }
        
        private void showSingleCell(DataSet dataset)
        {
            double q = (double)dataset.Tables["Prices"].Rows[2].ItemArray[1];
            MessageBox.Show($"Rows[2].ItemArray[1] = {q}");
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbSymbol_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmClosingPrices_Load(object sender, EventArgs e)
        {
            //calls stored procedure to get ticker values
            String strServer = ConfigurationManager.AppSettings["server"];
            String strDatabase = ConfigurationManager.AppSettings["database"];

            String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                SqlCommand sqlComm = new SqlCommand("spGetAllSymbols", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter newDataAdapter = new SqlDataAdapter();
                newDataAdapter.SelectCommand = sqlComm;
                DataTable result = new DataTable();
                newDataAdapter.Fill(result);
                comboBox1.DataSource = result;
                comboBox1.DisplayMember = "ticker";
                comboBox1.ValueMember = "";
            }

        }

        private void chrtPrices_Click(object sender, EventArgs e)
        {

        }
    }
}

