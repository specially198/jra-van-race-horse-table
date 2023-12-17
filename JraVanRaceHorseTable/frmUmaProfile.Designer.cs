namespace JraVanRaceHorseTable
{
    partial class frmUmaProfile
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
            lblUmaProfile1 = new Label();
            txtParam = new TextBox();
            TabUmaProfile = new TabControl();
            TabUmaProf = new TabPage();
            grdUmaProfile = new DataGridView();
            lblUmaProfile6 = new Label();
            lblUmaProfile2 = new Label();
            lblUmaProfile4 = new Label();
            lblUmaProfile3 = new Label();
            lblUmaProfile5 = new Label();
            TabUmaProfile.SuspendLayout();
            TabUmaProf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdUmaProfile).BeginInit();
            SuspendLayout();
            // 
            // lblUmaProfile1
            // 
            lblUmaProfile1.BackColor = SystemColors.ControlDark;
            lblUmaProfile1.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            lblUmaProfile1.Location = new Point(15, 14);
            lblUmaProfile1.Name = "lblUmaProfile1";
            lblUmaProfile1.Size = new Size(1689, 64);
            lblUmaProfile1.TabIndex = 0;
            // 
            // txtParam
            // 
            txtParam.Location = new Point(1356, 227);
            txtParam.Name = "txtParam";
            txtParam.Size = new Size(348, 39);
            txtParam.TabIndex = 1;
            txtParam.Visible = false;
            // 
            // TabUmaProfile
            // 
            TabUmaProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabUmaProfile.Controls.Add(TabUmaProf);
            TabUmaProfile.Location = new Point(15, 384);
            TabUmaProfile.Name = "TabUmaProfile";
            TabUmaProfile.SelectedIndex = 0;
            TabUmaProfile.Size = new Size(1689, 770);
            TabUmaProfile.TabIndex = 2;
            // 
            // TabUmaProf
            // 
            TabUmaProf.Controls.Add(grdUmaProfile);
            TabUmaProf.Controls.Add(lblUmaProfile6);
            TabUmaProf.Location = new Point(8, 46);
            TabUmaProf.Name = "TabUmaProf";
            TabUmaProf.Padding = new Padding(3);
            TabUmaProf.Size = new Size(1673, 716);
            TabUmaProf.TabIndex = 0;
            TabUmaProf.Text = "競走成績";
            TabUmaProf.UseVisualStyleBackColor = true;
            // 
            // grdUmaProfile
            // 
            grdUmaProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grdUmaProfile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdUmaProfile.Location = new Point(3, 38);
            grdUmaProfile.Name = "grdUmaProfile";
            grdUmaProfile.ReadOnly = true;
            grdUmaProfile.RowHeadersWidth = 82;
            grdUmaProfile.RowTemplate.Height = 41;
            grdUmaProfile.Size = new Size(1600, 660);
            grdUmaProfile.TabIndex = 1;
            // 
            // lblUmaProfile6
            // 
            lblUmaProfile6.BackColor = SystemColors.Control;
            lblUmaProfile6.Location = new Point(6, 3);
            lblUmaProfile6.Name = "lblUmaProfile6";
            lblUmaProfile6.Size = new Size(1672, 32);
            lblUmaProfile6.TabIndex = 0;
            lblUmaProfile6.Text = "障害レースについては、[後3ハロン]に\"後3Fタイム\"でなく、\"当該レース走破タイムの1F平均タイム\"を表示しています。";
            // 
            // lblUmaProfile2
            // 
            lblUmaProfile2.Location = new Point(15, 92);
            lblUmaProfile2.Name = "lblUmaProfile2";
            lblUmaProfile2.Size = new Size(1154, 135);
            lblUmaProfile2.TabIndex = 3;
            // 
            // lblUmaProfile4
            // 
            lblUmaProfile4.Location = new Point(15, 245);
            lblUmaProfile4.Name = "lblUmaProfile4";
            lblUmaProfile4.Size = new Size(846, 108);
            lblUmaProfile4.TabIndex = 4;
            // 
            // lblUmaProfile3
            // 
            lblUmaProfile3.Location = new Point(1246, 92);
            lblUmaProfile3.Name = "lblUmaProfile3";
            lblUmaProfile3.Size = new Size(458, 46);
            lblUmaProfile3.TabIndex = 5;
            lblUmaProfile3.TextAlign = ContentAlignment.TopRight;
            // 
            // lblUmaProfile5
            // 
            lblUmaProfile5.Location = new Point(925, 227);
            lblUmaProfile5.Name = "lblUmaProfile5";
            lblUmaProfile5.Size = new Size(410, 126);
            lblUmaProfile5.TabIndex = 6;
            // 
            // frmUmaProfile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1926, 1179);
            Controls.Add(lblUmaProfile5);
            Controls.Add(lblUmaProfile3);
            Controls.Add(lblUmaProfile4);
            Controls.Add(lblUmaProfile2);
            Controls.Add(TabUmaProfile);
            Controls.Add(txtParam);
            Controls.Add(lblUmaProfile1);
            Name = "frmUmaProfile";
            Text = "サンプルプログラム － 競走馬プロフィール";
            Load += frmUmaProfile_Load;
            TabUmaProfile.ResumeLayout(false);
            TabUmaProf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdUmaProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUmaProfile1;
        public TextBox txtParam;
        private TabControl TabUmaProfile;
        private TabPage TabUmaProf;
        private DataGridView grdUmaProfile;
        private Label lblUmaProfile6;
        private Label lblUmaProfile2;
        private Label lblUmaProfile4;
        private Label lblUmaProfile3;
        private Label lblUmaProfile5;
    }
}