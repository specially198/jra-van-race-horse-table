namespace JraVanRaceHorseTable
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGetJVData = new Button();
            btnStopJVData = new Button();
            cmbYear = new ComboBox();
            btnViewDenmaList = new Button();
            btnInitDB = new Button();
            btnSettingJVLink = new Button();
            barFileCount = new ProgressBar();
            barReadSize = new ProgressBar();
            SuspendLayout();
            // 
            // btnGetJVData
            // 
            btnGetJVData.Location = new Point(22, 26);
            btnGetJVData.Name = "btnGetJVData";
            btnGetJVData.Size = new Size(193, 74);
            btnGetJVData.TabIndex = 0;
            btnGetJVData.Text = "開催情報取得";
            btnGetJVData.UseVisualStyleBackColor = true;
            btnGetJVData.Click += btnGetJVData_Click;
            // 
            // btnStopJVData
            // 
            btnStopJVData.Location = new Point(236, 28);
            btnStopJVData.Name = "btnStopJVData";
            btnStopJVData.Size = new Size(193, 72);
            btnStopJVData.TabIndex = 1;
            btnStopJVData.Text = "キャンセル";
            btnStopJVData.UseVisualStyleBackColor = true;
            btnStopJVData.Click += btnStopJVData_Click;
            // 
            // cmbYear
            // 
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(22, 124);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(407, 40);
            cmbYear.TabIndex = 2;
            // 
            // btnViewDenmaList
            // 
            btnViewDenmaList.Location = new Point(22, 182);
            btnViewDenmaList.Name = "btnViewDenmaList";
            btnViewDenmaList.Size = new Size(407, 84);
            btnViewDenmaList.TabIndex = 3;
            btnViewDenmaList.Text = "出馬表表示";
            btnViewDenmaList.UseVisualStyleBackColor = true;
            btnViewDenmaList.Click += btnViewDenmaList_Click;
            // 
            // btnInitDB
            // 
            btnInitDB.Location = new Point(22, 292);
            btnInitDB.Name = "btnInitDB";
            btnInitDB.Size = new Size(193, 76);
            btnInitDB.TabIndex = 4;
            btnInitDB.Text = "ＤＢ初期化";
            btnInitDB.UseVisualStyleBackColor = true;
            btnInitDB.Click += btnInitDB_Click;
            // 
            // btnSettingJVLink
            // 
            btnSettingJVLink.Location = new Point(236, 292);
            btnSettingJVLink.Name = "btnSettingJVLink";
            btnSettingJVLink.Size = new Size(193, 76);
            btnSettingJVLink.TabIndex = 5;
            btnSettingJVLink.Text = "JV-Link設定";
            btnSettingJVLink.UseVisualStyleBackColor = true;
            btnSettingJVLink.Click += btnSettingJVLink_Click;
            // 
            // barFileCount
            // 
            barFileCount.Location = new Point(22, 406);
            barFileCount.Name = "barFileCount";
            barFileCount.Size = new Size(407, 36);
            barFileCount.TabIndex = 6;
            // 
            // barReadSize
            // 
            barReadSize.Location = new Point(22, 464);
            barReadSize.Name = "barReadSize";
            barReadSize.Size = new Size(407, 34);
            barReadSize.TabIndex = 7;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 678);
            Controls.Add(barReadSize);
            Controls.Add(barFileCount);
            Controls.Add(btnSettingJVLink);
            Controls.Add(btnInitDB);
            Controls.Add(btnViewDenmaList);
            Controls.Add(cmbYear);
            Controls.Add(btnStopJVData);
            Controls.Add(btnGetJVData);
            Name = "frmMenu";
            Text = "サンプルプログラム － メニュー";
            Load += frmMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private JVDTLabLib.JVLinkClass JVLink = new JVDTLabLib.JVLinkClass();
        private Button btnGetJVData;
        private Button btnStopJVData;
        private ComboBox cmbYear;
        private Button btnViewDenmaList;
        private Button btnInitDB;
        private Button btnSettingJVLink;
        private ProgressBar barFileCount;
        private ProgressBar barReadSize;
    }
}