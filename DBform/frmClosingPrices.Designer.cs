namespace DBform
{
    partial class frmClosingPrices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnGetData = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.chrtPrices = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tSDailyDataBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.financeS24DataSet2 = new DBform.FinanceS24DataSet2();
            this.financeS24DataSet = new DBform.FinanceS24DataSet();
            this.spGetAllSymbolsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spGetAllSymbolsTableAdapter = new DBform.FinanceS24DataSetTableAdapters.spGetAllSymbolsTableAdapter();
            this.financeS24DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financeS24DataSet1 = new DBform.FinanceS24DataSet1();
            this.tSDailyDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tS_DailyDataTableAdapter = new DBform.FinanceS24DataSet1TableAdapters.TS_DailyDataTableAdapter();
            this.tS_DailyDataTableAdapter1 = new DBform.FinanceS24DataSet2TableAdapters.TS_DailyDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDailyDataBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGetAllSymbolsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDailyDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(66, 7);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // dgvData
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(1, 38);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvData.Size = new System.Drawing.Size(312, 352);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Symbol:";
            // 
            // chrtPrices
            // 
            this.chrtPrices.BorderlineWidth = 10;
            chartArea1.Name = "ChartArea1";
            this.chrtPrices.ChartAreas.Add(chartArea1);
            this.chrtPrices.Location = new System.Drawing.Point(322, 38);
            this.chrtPrices.Name = "chrtPrices";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series2";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chrtPrices.Series.Add(series1);
            this.chrtPrices.Series.Add(series2);
            this.chrtPrices.Size = new System.Drawing.Size(346, 352);
            this.chrtPrices.TabIndex = 6;
            this.chrtPrices.Text = "chart1";
            this.chrtPrices.Click += new System.EventHandler(this.chrtPrices_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.tSDailyDataBindingSource1;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(368, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tSDailyDataBindingSource1
            // 
            this.tSDailyDataBindingSource1.DataMember = "TS_DailyData";
            this.tSDailyDataBindingSource1.DataSource = this.financeS24DataSet2;
            // 
            // financeS24DataSet2
            // 
            this.financeS24DataSet2.DataSetName = "FinanceS24DataSet2";
            this.financeS24DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financeS24DataSet
            // 
            this.financeS24DataSet.DataSetName = "FinanceS24DataSet";
            this.financeS24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spGetAllSymbolsBindingSource
            // 
            this.spGetAllSymbolsBindingSource.DataMember = "spGetAllSymbols";
            this.spGetAllSymbolsBindingSource.DataSource = this.financeS24DataSet;
            // 
            // spGetAllSymbolsTableAdapter
            // 
            this.spGetAllSymbolsTableAdapter.ClearBeforeFill = true;
            // 
            // financeS24DataSetBindingSource
            // 
            this.financeS24DataSetBindingSource.DataSource = this.financeS24DataSet;
            this.financeS24DataSetBindingSource.Position = 0;
            // 
            // financeS24DataSet1
            // 
            this.financeS24DataSet1.DataSetName = "FinanceS24DataSet1";
            this.financeS24DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tSDailyDataBindingSource
            // 
            this.tSDailyDataBindingSource.DataMember = "TS_DailyData";
            this.tSDailyDataBindingSource.DataSource = this.financeS24DataSet1;
            // 
            // tS_DailyDataTableAdapter
            // 
            this.tS_DailyDataTableAdapter.ClearBeforeFill = true;
            // 
            // tS_DailyDataTableAdapter1
            // 
            this.tS_DailyDataTableAdapter1.ClearBeforeFill = true;
            // 
            // frmClosingPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 389);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chrtPrices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnGetData);
            this.Name = "frmClosingPrices";
            this.Text = "Daily Closing Prices";
            this.Load += new System.EventHandler(this.frmClosingPrices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDailyDataBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGetAllSymbolsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeS24DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDailyDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPrices;
        private System.Windows.Forms.ComboBox comboBox1;
        private FinanceS24DataSet financeS24DataSet;
        private System.Windows.Forms.BindingSource spGetAllSymbolsBindingSource;
        private FinanceS24DataSetTableAdapters.spGetAllSymbolsTableAdapter spGetAllSymbolsTableAdapter;
        private System.Windows.Forms.BindingSource financeS24DataSetBindingSource;
        private FinanceS24DataSet1 financeS24DataSet1;
        private System.Windows.Forms.BindingSource tSDailyDataBindingSource;
        private FinanceS24DataSet1TableAdapters.TS_DailyDataTableAdapter tS_DailyDataTableAdapter;
        private FinanceS24DataSet2 financeS24DataSet2;
        private System.Windows.Forms.BindingSource tSDailyDataBindingSource1;
        private FinanceS24DataSet2TableAdapters.TS_DailyDataTableAdapter tS_DailyDataTableAdapter1;
    }
}

