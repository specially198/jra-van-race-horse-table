namespace JraVanRaceHorseTable
{
    partial class frmRaceInfo
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
            lblRaceInfo1 = new Label();
            txtParam = new TextBox();
            TabRaceInfo = new TabControl();
            TabDenmaList1 = new TabPage();
            grdDenmaList = new DataGridView();
            lblRaceInfo2 = new Label();
            lblRaceInfo3 = new Label();
            TabRaceInfo.SuspendLayout();
            TabDenmaList1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdDenmaList).BeginInit();
            SuspendLayout();
            // 
            // lblRaceInfo1
            // 
            lblRaceInfo1.BackColor = SystemColors.ControlDark;
            lblRaceInfo1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblRaceInfo1.Location = new Point(15, 12);
            lblRaceInfo1.Name = "lblRaceInfo1";
            lblRaceInfo1.Size = new Size(1689, 64);
            lblRaceInfo1.TabIndex = 0;
            // 
            // txtParam
            // 
            txtParam.Location = new Point(1382, 138);
            txtParam.Name = "txtParam";
            txtParam.Size = new Size(322, 39);
            txtParam.TabIndex = 1;
            txtParam.Visible = false;
            // 
            // TabRaceInfo
            // 
            TabRaceInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabRaceInfo.Controls.Add(TabDenmaList1);
            TabRaceInfo.Location = new Point(15, 234);
            TabRaceInfo.Name = "TabRaceInfo";
            TabRaceInfo.SelectedIndex = 0;
            TabRaceInfo.Size = new Size(1689, 939);
            TabRaceInfo.TabIndex = 2;
            // 
            // TabDenmaList1
            // 
            TabDenmaList1.Controls.Add(grdDenmaList);
            TabDenmaList1.Location = new Point(8, 46);
            TabDenmaList1.Name = "TabDenmaList1";
            TabDenmaList1.Padding = new Padding(3);
            TabDenmaList1.Size = new Size(1673, 885);
            TabDenmaList1.TabIndex = 0;
            TabDenmaList1.Text = "基本情報";
            TabDenmaList1.UseVisualStyleBackColor = true;
            // 
            // grdDenmaList
            // 
            grdDenmaList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grdDenmaList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdDenmaList.Location = new Point(20, 10);
            grdDenmaList.Name = "grdDenmaList";
            grdDenmaList.RowHeadersWidth = 82;
            grdDenmaList.RowTemplate.Height = 41;
            grdDenmaList.Size = new Size(1600, 847);
            grdDenmaList.TabIndex = 0;
            grdDenmaList.CellDoubleClick += grdDenmaList_CellDoubleClick;
            // 
            // lblRaceInfo2
            // 
            lblRaceInfo2.Location = new Point(15, 96);
            lblRaceInfo2.Name = "lblRaceInfo2";
            lblRaceInfo2.Size = new Size(1330, 101);
            lblRaceInfo2.TabIndex = 3;
            // 
            // lblRaceInfo3
            // 
            lblRaceInfo3.Location = new Point(1222, 92);
            lblRaceInfo3.Name = "lblRaceInfo3";
            lblRaceInfo3.Size = new Size(482, 31);
            lblRaceInfo3.TabIndex = 4;
            lblRaceInfo3.TextAlign = ContentAlignment.TopRight;
            // 
            // frmRaceInfo
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1952, 1179);
            Controls.Add(lblRaceInfo3);
            Controls.Add(lblRaceInfo2);
            Controls.Add(TabRaceInfo);
            Controls.Add(txtParam);
            Controls.Add(lblRaceInfo1);
            Name = "frmRaceInfo";
            Text = "サンプルプログラム － 出馬表";
            Load += frmRaceInfo_Load;
            TabRaceInfo.ResumeLayout(false);
            TabDenmaList1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdDenmaList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRaceInfo1;
        public TextBox txtParam;
        private TabControl TabRaceInfo;
        private TabPage TabDenmaList1;
        private DataGridView grdDenmaList;
        private Label lblRaceInfo2;
        private Label lblRaceInfo3;
    }
}