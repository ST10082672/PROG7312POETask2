using System;

namespace PROG7312POETask2
{
    partial class frmServiceRequestStatus
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolTip toolTip; // Added tooltip control

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblServiceRequestId = new System.Windows.Forms.Label();
            this.cmbDataStructure = new System.Windows.Forms.ComboBox();
            this.dgvServiceRequests = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriorityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchId = new System.Windows.Forms.TextBox();
            this.ServiceRequestChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLineGraph = new System.Windows.Forms.RadioButton();
            this.btnBarGraph = new System.Windows.Forms.RadioButton();
            this.btnPoint = new System.Windows.Forms.RadioButton();
            this.cbFilterBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceRequestChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(650, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.toolTip.SetToolTip(this.btnSearch, "Search for a Service Request by ID");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblServiceRequestId
            // 
            this.lblServiceRequestId.AutoSize = true;
            this.lblServiceRequestId.Location = new System.Drawing.Point(280, 14);
            this.lblServiceRequestId.Name = "lblServiceRequestId";
            this.lblServiceRequestId.Size = new System.Drawing.Size(123, 16);
            this.lblServiceRequestId.TabIndex = 3;
            this.lblServiceRequestId.Text = "Service Request ID";
            this.toolTip.SetToolTip(this.lblServiceRequestId, "Enter the Service Request ID to search");
            // 
            // cmbDataStructure
            // 
            this.cmbDataStructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataStructure.FormattingEnabled = true;
            this.cmbDataStructure.Location = new System.Drawing.Point(46, 6);
            this.cmbDataStructure.Name = "cmbDataStructure";
            this.cmbDataStructure.Size = new System.Drawing.Size(150, 24);
            this.cmbDataStructure.TabIndex = 4;
            this.toolTip.SetToolTip(this.cmbDataStructure, "Select the data structure to manage service requests");
            this.cmbDataStructure.SelectedIndexChanged += new System.EventHandler(this.cmbDataStructure_SelectedIndexChanged);
            // 
            // dgvServiceRequests
            // 
            this.dgvServiceRequests.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvServiceRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.StatusColumn,
            this.DescriptionColumn,
            this.PriorityColumn});
            this.dgvServiceRequests.Location = new System.Drawing.Point(24, 40);
            this.dgvServiceRequests.Name = "dgvServiceRequests";
            this.dgvServiceRequests.RowHeadersWidth = 51;
            this.dgvServiceRequests.RowTemplate.Height = 24;
            this.dgvServiceRequests.Size = new System.Drawing.Size(877, 285);
            this.dgvServiceRequests.TabIndex = 0;
            this.dgvServiceRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiceRequests_CellContentClick);
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "Service Request ID";
            this.IdColumn.MinimumWidth = 6;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Width = 150;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.MinimumWidth = 6;
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.Width = 150;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.MinimumWidth = 6;
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.Width = 400;
            // 
            // PriorityColumn
            // 
            this.PriorityColumn.HeaderText = "Priority";
            this.PriorityColumn.MinimumWidth = 6;
            this.PriorityColumn.Name = "PriorityColumn";
            this.PriorityColumn.Width = 125;
            // 
            // txtSearchId
            // 
            this.txtSearchId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.txtSearchId.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchId.Location = new System.Drawing.Point(410, 11);
            this.txtSearchId.Name = "txtSearchId";
            this.txtSearchId.Size = new System.Drawing.Size(227, 22);
            this.txtSearchId.TabIndex = 1;
            this.txtSearchId.Text = "Enter Request ID";
            this.txtSearchId.TextChanged += new System.EventHandler(this.txtSearchId_TextChanged);
            this.txtSearchId.Enter += new System.EventHandler(this.txtSearchId_Enter);
            this.txtSearchId.Leave += new System.EventHandler(this.txtSearchId_Leave);
            // 
            // ServiceRequestChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ServiceRequestChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ServiceRequestChart.Legends.Add(legend1);
            this.ServiceRequestChart.Location = new System.Drawing.Point(24, 334);
            this.ServiceRequestChart.Name = "ServiceRequestChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Line";
            series1.YValuesPerPoint = 6;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Column";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Point";
            series3.YValuesPerPoint = 6;
            this.ServiceRequestChart.Series.Add(series1);
            this.ServiceRequestChart.Series.Add(series2);
            this.ServiceRequestChart.Series.Add(series3);
            this.ServiceRequestChart.Size = new System.Drawing.Size(877, 342);
            this.ServiceRequestChart.TabIndex = 5;
            this.ServiceRequestChart.Text = "ServiceRequestChart";
            // 
            // btnLineGraph
            // 
            this.btnLineGraph.AutoSize = true;
            this.btnLineGraph.Location = new System.Drawing.Point(986, 386);
            this.btnLineGraph.Name = "btnLineGraph";
            this.btnLineGraph.Size = new System.Drawing.Size(93, 20);
            this.btnLineGraph.TabIndex = 6;
            this.btnLineGraph.TabStop = true;
            this.btnLineGraph.Text = "Line Graph";
            this.btnLineGraph.UseVisualStyleBackColor = true;
            this.btnLineGraph.CheckedChanged += new System.EventHandler(this.btnLineGraph_CheckedChanged);
            // 
            // btnBarGraph
            // 
            this.btnBarGraph.AutoSize = true;
            this.btnBarGraph.Location = new System.Drawing.Point(986, 425);
            this.btnBarGraph.Name = "btnBarGraph";
            this.btnBarGraph.Size = new System.Drawing.Size(89, 20);
            this.btnBarGraph.TabIndex = 7;
            this.btnBarGraph.TabStop = true;
            this.btnBarGraph.Text = "Bar Graph";
            this.btnBarGraph.UseVisualStyleBackColor = true;
            this.btnBarGraph.CheckedChanged += new System.EventHandler(this.btnBarGraph_CheckedChanged);
            // 
            // btnPoint
            // 
            this.btnPoint.AutoSize = true;
            this.btnPoint.Location = new System.Drawing.Point(986, 460);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(58, 20);
            this.btnPoint.TabIndex = 8;
            this.btnPoint.TabStop = true;
            this.btnPoint.Text = "Point";
            this.btnPoint.UseVisualStyleBackColor = true;
            this.btnPoint.CheckedChanged += new System.EventHandler(this.btnPoint_CheckedChanged);
            // 
            // cbFilterBox
            // 
            this.cbFilterBox.FormattingEnabled = true;
            this.cbFilterBox.Items.AddRange(new object[] {
            "Status",
            "Priority"});
            this.cbFilterBox.Location = new System.Drawing.Point(986, 507);
            this.cbFilterBox.Name = "cbFilterBox";
            this.cbFilterBox.Size = new System.Drawing.Size(183, 24);
            this.cbFilterBox.TabIndex = 9;
            this.cbFilterBox.SelectedIndexChanged += new System.EventHandler(this.cbFilterBox_SelectedIndexChanged);
            // 
            // frmServiceRequestStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 675);
            this.Controls.Add(this.cbFilterBox);
            this.Controls.Add(this.btnPoint);
            this.Controls.Add(this.btnBarGraph);
            this.Controls.Add(this.btnLineGraph);
            this.Controls.Add(this.ServiceRequestChart);
            this.Controls.Add(this.cmbDataStructure);
            this.Controls.Add(this.lblServiceRequestId);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchId);
            this.Controls.Add(this.dgvServiceRequests);
            this.Name = "frmServiceRequestStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Request Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceRequestChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServiceRequests;
        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblServiceRequestId;
        private System.Windows.Forms.ComboBox cmbDataStructure;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriorityColumn;

        // Event handlers to manage placeholder text for txtSearchId
        private void txtSearchId_Enter(object sender, EventArgs e)
        {
            if (txtSearchId.Text == "Enter Request ID")
            {
                txtSearchId.Text = "";
                txtSearchId.ForeColor = System.Drawing.Color.Black;
                txtSearchId.Font = new System.Drawing.Font(txtSearchId.Font, System.Drawing.FontStyle.Regular); // Set to Regular font
            }
        }

        private void txtSearchId_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchId.Text))
            {
                txtSearchId.Text = "Enter Request ID";
                txtSearchId.ForeColor = System.Drawing.Color.Gray;
                txtSearchId.Font = new System.Drawing.Font(txtSearchId.Font, System.Drawing.FontStyle.Italic); // Set to Italic for placeholder
            }
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart ServiceRequestChart;
        private System.Windows.Forms.RadioButton btnLineGraph;
        private System.Windows.Forms.RadioButton btnBarGraph;
        private System.Windows.Forms.RadioButton btnPoint;
        private System.Windows.Forms.ComboBox cbFilterBox;
    }
}
