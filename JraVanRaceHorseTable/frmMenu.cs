using JraVanRaceHorseTable.Services;
using System.Configuration;
using System.Text;
using static JraVanRaceHorseTable.Const;
using static JVData_Struct;

namespace JraVanRaceHorseTable
{
    public partial class frmMenu : Form
    {
        private readonly IFormFactory _factory;
        private readonly IRaceService _raceService;
        private readonly IRaceUmaService _raceUmaService;
        private readonly IUmaService _umaService;

        // �L�����Z���t���O
        bool bCancelFlag = false;

        // FromTime
        string? strFromTime;

        public frmMenu(
            IFormFactory factory,
            IRaceService raceService,
            IRaceUmaService raceUmaService,
            IUmaService umaService)
        {
            InitializeComponent();

            _factory = factory;
            _raceService = raceService;
            _raceUmaService = raceUmaService;
            _umaService = umaService;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            // FROMTIME
            strFromTime = ConfigurationManager.AppSettings["fromTime"];
            strFromTime ??= "00000000000000";

            // JVInit�̌Ăяo��
            int lReturnCode = JVLink.JVInit("JVLinkSDKSampleAPP1");
            if (lReturnCode != 0)
            {
                MessageBox.Show("JVInit�G���[ �R�[�h�F" + lReturnCode);
            }

            // �J�ÔN�����I���R���{�{�b�N�X�̕\��
            SetCmdYearItem();

            // �f�[�^�x�[�X�֘A�@�\�{�^�����g�p�ɐݒ�
            btnGetJVData.Enabled = true;
            btnInitDB.Enabled = true;

            if (cmbYear.Items.Count > 0)
            {
                btnViewDenmaList.Enabled = true;
                cmbYear.Enabled = true;
            }
            else
            {
                btnViewDenmaList.Enabled = false;
                cmbYear.Enabled = false;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        // �J�Ï��擾�{�^���N���b�N
        private void btnGetJVData_Click(object sender, EventArgs e)
        {
            try
            {
                // �L�����Z�����m�t���O�̏�����
                bCancelFlag = false;
                // �v���O���X�o�[�̏�����
                barFileCount.Value = 0;
                barReadSize.Value = 0;

                // JVOpen�̌Ăяo��

                // JVOpen:�t�@�C�����ʎq
                string strDataSpec = "RACERCVN";
                // JVOpen:�I�v�V����
                int lOption = 2;

                // JVLink:�߂�l
                int lReadCount = 0;
                // JVOpen:���_�E�����[�h�t�@�C����
                int lDownloadCount = 0;
                // JVOpen:�ŐV�t�@�C���̃^�C���X�^���v
                int lReturnCode = JVLink.JVOpen(
                    strDataSpec, strFromTime, lOption, ref lReadCount, ref lDownloadCount, out string strLastFileTimestamp);
                if (lReturnCode < 0)
                {
                    MessageBox.Show("JVOpen�G���[ �R�[�h�F" + lReturnCode);
                    return;
                }

                // �{�^���̗}�~
                btnGetJVData.Enabled = false;
                btnViewDenmaList.Enabled = false;
                btnInitDB.Enabled = false;
                btnSettingJVLink.Enabled = false;
                cmbYear.Enabled = false;
                btnStopJVData.Enabled = true;

                // ���v�t�@�C�����̃v���O���X�o�[�̏����ݒ�
                barFileCount.Maximum = lReadCount;

                // JVGets�p(�o�b�t�@�|�C���^)
                object objBuff = Array.Empty<byte>();
                // JVGets�p(�o�b�t�@�T�C�Y)
                int lBuffSize = 110000;

                // �v���O���X�o�[�p�ϐ�
                var lTotalFileCount = 0;
                var lTotalReadSize = 0;

                // ���[�X�ڍ׏��\����
                var structRace = new JV_RA_RACE();
                // �n�����[�X���\����
                var structRaceUma = new JV_SE_RACE_UMA();
                // �����n�}�X�^�\����
                var structUma = new JV_UM_UMA();

                var bSkipFlg = false;

                while (true)
                {
                    // �o�b�N�O���E���h�ł̏��������s
                    Application.DoEvents();

                    // �L�����Z���������ꂽ�珈��(���[�v)�𔲂���
                    if (bCancelFlag)
                    {
                        break;
                    }

                    // JVGets�̌Ăяo��
                    lReturnCode = JVLink.JVGets(ref objBuff, lBuffSize, out string strFileName);
                    var szBuff = (byte[])objBuff;

                    // �G���[����
                    switch (lReturnCode)
                    {
                        // ����
                        case int i when i >= (int)JvRead.Success:
                            // �����R�[�h�ϊ�(SJIS��UNICODE)
                            var strBuff = Encoding.GetEncoding("sjis").GetString(szBuff);

                            // �f�[�^�敪�̎擾
                            var strRecID = strBuff[..2];

                            bSkipFlg = false;
                            // �����Ώۃf�[�^�̂݃f�[�^�x�[�X�֓o�^
                            if (strRecID == RecordKind.Race)
                            {
                                // ���[�X�ڍ�
                                structRace.SetDataB(ref strBuff);
                                _raceService.Add(structRace);
                            }
                            else if (strRecID == RecordKind.RaceUma)
                            {
                                // �n�����[�X���
                                structRaceUma.SetDataB(ref strBuff);

                                var id = structRaceUma.id;
                                var raceId = _raceService.GetRaceId(
                                    id.Year!, id.MonthDay!, id.JyoCD!, id.Kaiji!, id.Nichiji!, id.RaceNum!);

                                _raceUmaService.Add(structRaceUma, raceId);
                            }
                            else if (strRecID == RecordKind.Uma)
                            {
                                // �����n�}�X�^
                                structUma.SetDataB(ref strBuff);
                                _umaService.Add(structUma);
                            }
                            else
                            {
                                // �ΏۊO�t�@�C���̓X�L�b�v(�t���O��ݒ�)
                                bSkipFlg = true;
                            }

                            if (bSkipFlg)
                            {
                                // �ΏۊO�t�@�C���̓X�L�b�v
                                JVLink.JVSkip();
                                // �J�����g�t�@�C���̃v���O���X�o�[���X�V
                                barReadSize.Value = barReadSize.Maximum;

                                // ���v�t�@�C�����̃v���O���X�o�[���X�V
                                lTotalFileCount++;
                                barFileCount.Value = lTotalFileCount;
                            }
                            else
                            {
                                // �J�����g�t�@�C���̃v���O���X�o�[���X�V
                                barReadSize.Maximum = JVLink.m_CurrentReadFilesize;
                                lTotalReadSize = lTotalReadSize + szBuff.Length - 1;
                                barReadSize.Value = lTotalReadSize;
                            }

                            break;
                        // �t�@�C���̋�؂�
                        case (int)JvRead.Eof:
                            // ���v�t�@�C�����̃v���O���X�o�[���X�V
                            lTotalFileCount++;
                            barFileCount.Value = lTotalFileCount;

                            // �J�����g�t�@�C���̃v���O���X�o�[��������
                            lTotalReadSize = 0;

                            // FromTime��ޔ�
                            strFromTime = JVLink.m_CurrentFileTimeStamp;

                            break;
                        // �S���R�[�h�Ǎ��ݏI��(EOF)
                        case (int)JvRead.Eol:
                            goto readFinish;
                        // �_�E�����[�h��
                        case (int)JvRead.DownloadNow:
                            continue;
                        // �G���[
                        case (int)JvRead.Err:
                            MessageBox.Show("JVGets�G���[ �R�[�h�F" + lReturnCode);
                            goto readFinish;
                    }
                }
            readFinish:;

                // FromTime��ݒ�t�@�C���ɕۑ�
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["fromTime"].Value = strFromTime;
                config.Save();

                if (!bCancelFlag)
                {
                    MessageBox.Show("�J�Ï��̎擾���I�����܂����B");
                }
                else
                {
                    MessageBox.Show("�J�Ï��̎擾�𒆎~���܂����B");
                }

                // �J�ÔN�����I���R���{�{�b�N�X�̕\��
                SetCmdYearItem();

                // �{�^���̗}�~������
                btnGetJVData.Enabled = true;
                btnViewDenmaList.Enabled = true;
                btnInitDB.Enabled = true;
                btnSettingJVLink.Enabled = true;
                cmbYear.Enabled = true;
                btnStopJVData.Enabled = true;
                // �v���O���X�o�[�����ɖ߂�
                barFileCount.Value = 0;
                barReadSize.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // JVClose�̌ďo
                int lReturnCode = JVLink.JVClose();
                if (lReturnCode != 0)
                {
                    MessageBox.Show("JVClose�G���[ �R�[�h�F" + lReturnCode);
                }
            }
        }

        private void btnStopJVData_Click(object sender, EventArgs e)
        {
            // �L�����Z���t���O�̐ݒ�
            bCancelFlag = true;
        }

        private void btnViewDenmaList_Click(object sender, EventArgs e)
        {
            var frmDenmaList = _factory.Create<frmDenmaList>();
            frmDenmaList.txtParam.Text = cmbYear.Text;
            frmDenmaList.Show();
        }

        private void btnInitDB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("�c�a�����������܂����H", "�m�F", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            // �v���O���X�o�[�̏�����
            barReadSize.Value = 0;
            barFileCount.Value = 0;
            barFileCount.Maximum = 100;

            // �e�[�u���̑S���R�[�h���N���A
            _raceService.DeleteAll();
            barFileCount.Value = 30;

            _raceUmaService.DeleteAll();
            barFileCount.Value = 60;

            _umaService.DeleteAll();
            barFileCount.Value = 90;

            // FromTime�����������ݒ�t�@�C���ɕۑ�
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["fromTime"].Value = "00000000000000";
            config.Save();

            // �J�ÔN�����I���R���{�{�b�N�X�̃N���A
            SetCmdYearItem();

            btnViewDenmaList.Enabled = false;
            cmbYear.Enabled = false;

            barFileCount.Value = 100;

            MessageBox.Show("�c�a�̏��������I�����܂����B");
        }

        private void btnSettingJVLink_Click(object sender, EventArgs e)
        {
            // �ݒ��ʕ\��
            int lReturnCode = JVLink.JVSetUIProperties();
            if (lReturnCode != 0)
            {
                MessageBox.Show("JVSetUIProperties�G���[ �R�[�h�F" + lReturnCode);
            }
        }

        private void SetCmdYearItem()
        {
            // �R���{�{�b�N�X�̃N���A
            cmbYear.Text = "";
            cmbYear.Items.Clear();

            var raceYearMonthList = _raceService.GetRaceYearMonthDayList();

            foreach (var raceYearMonth in raceYearMonthList)
            {
                cmbYear.Items.Add(raceYearMonth.Year + raceYearMonth.MonthDay);
            }

            // ���ߓ��t�������\��
            if (cmbYear.Items.Count > 0)
            {
                cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            }
        }
    }
}