namespace JraVanRaceHorseTable
{
    partial class frmDenmaList
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
            components = new System.ComponentModel.Container();
            lblDenmaList = new Label();
            TabDenmaList = new TabControl();
            TabKaisaiInfo = new TabPage();
            grdDenmaList = new DataGridView();
            raceBindingSource = new BindingSource(components);
            txtParam = new TextBox();
            TabDenmaList.SuspendLayout();
            TabKaisaiInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdDenmaList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)raceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblDenmaList
            // 
            lblDenmaList.BackColor = SystemColors.ControlDark;
            lblDenmaList.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDenmaList.Location = new Point(12, 19);
            lblDenmaList.Name = "lblDenmaList";
            lblDenmaList.Size = new Size(1900, 64);
            lblDenmaList.TabIndex = 0;
            // 
            // TabDenmaList
            // 
            TabDenmaList.Controls.Add(TabKaisaiInfo);
            TabDenmaList.Location = new Point(12, 104);
            TabDenmaList.Name = "TabDenmaList";
            TabDenmaList.SelectedIndex = 0;
            TabDenmaList.Size = new Size(1900, 1000);
            TabDenmaList.TabIndex = 1;
            // 
            // TabKaisaiInfo
            // 
            TabKaisaiInfo.Controls.Add(grdDenmaList);
            TabKaisaiInfo.Location = new Point(8, 46);
            TabKaisaiInfo.Name = "TabKaisaiInfo";
            TabKaisaiInfo.Padding = new Padding(3);
            TabKaisaiInfo.Size = new Size(1884, 946);
            TabKaisaiInfo.TabIndex = 0;
            TabKaisaiInfo.Text = "開催情報";
            TabKaisaiInfo.UseVisualStyleBackColor = true;
            // 
            // grdDenmaList
            // 
            grdDenmaList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdDenmaList.Location = new Point(13, 12);
            grdDenmaList.Name = "grdDenmaList";
            grdDenmaList.ReadOnly = true;
            grdDenmaList.RowHeadersWidth = 82;
            grdDenmaList.RowTemplate.Height = 41;
            grdDenmaList.Size = new Size(1884, 1600);
            grdDenmaList.TabIndex = 0;
            grdDenmaList.CellDoubleClick += grdDenmaList_CellDoubleClick;
            // 
            // raceBindingSource
            // 
            raceBindingSource.DataSource = typeof(Models.Race);
            // 
            // txtParam
            // 
            txtParam.Location = new Point(1580, 104);
            txtParam.Name = "txtParam";
            txtParam.Size = new Size(332, 39);
            txtParam.TabIndex = 2;
            // 
            // frmDenmaList
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1972, 1129);
            Controls.Add(txtParam);
            Controls.Add(TabDenmaList);
            Controls.Add(lblDenmaList);
            Name = "frmDenmaList";
            Text = "サンプルプログラム － 出馬表選択";
            Load += frmDenmaList_Load;
            TabDenmaList.ResumeLayout(false);
            TabKaisaiInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdDenmaList).EndInit();
            ((System.ComponentModel.ISupportInitialize)raceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDenmaList;
        private TabControl TabDenmaList;
        private TabPage TabKaisaiInfo;
        public TextBox txtParam;
        private DataGridView grdDenmaList;
        private BindingSource raceBindingSource;
    }
}