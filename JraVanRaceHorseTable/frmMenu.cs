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

        // キャンセルフラグ
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

            // JVInitの呼び出し
            int lReturnCode = JVLink.JVInit("JVLinkSDKSampleAPP1");
            if (lReturnCode != 0)
            {
                MessageBox.Show("JVInitエラー コード：" + lReturnCode);
            }

            // 開催年月日選択コンボボックスの表示
            SetCmdYearItem();

            // データベース関連機能ボタンを使用可に設定
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

        // 開催情報取得ボタンクリック
        private void btnGetJVData_Click(object sender, EventArgs e)
        {
            try
            {
                // キャンセル検知フラグの初期化
                bCancelFlag = false;
                // プログレスバーの初期化
                barFileCount.Value = 0;
                barReadSize.Value = 0;

                // JVOpenの呼び出し

                // JVOpen:ファイル識別子
                string strDataSpec = "RACERCVN";
                // JVOpen:オプション
                int lOption = 2;

                // JVLink:戻り値
                int lReadCount = 0;
                // JVOpen:総ダウンロードファイル数
                int lDownloadCount = 0;
                // JVOpen:最新ファイルのタイムスタンプ
                int lReturnCode = JVLink.JVOpen(
                    strDataSpec, strFromTime, lOption, ref lReadCount, ref lDownloadCount, out string strLastFileTimestamp);
                if (lReturnCode < 0)
                {
                    MessageBox.Show("JVOpenエラー コード：" + lReturnCode);
                    return;
                }

                // ボタンの抑止
                btnGetJVData.Enabled = false;
                btnViewDenmaList.Enabled = false;
                btnInitDB.Enabled = false;
                btnSettingJVLink.Enabled = false;
                cmbYear.Enabled = false;
                btnStopJVData.Enabled = true;

                // 合計ファイル数のプログレスバーの上限を設定
                barFileCount.Maximum = lReadCount;

                // JVGets用(バッファポインタ)
                object objBuff = Array.Empty<byte>();
                // JVGets用(バッファサイズ)
                int lBuffSize = 110000;

                // プログレスバー用変数
                var lTotalFileCount = 0;
                var lTotalReadSize = 0;

                // レース詳細情報構造体
                var structRace = new JV_RA_RACE();
                // 馬毎レース情報構造体
                var structRaceUma = new JV_SE_RACE_UMA();
                // 競走馬マスタ構造体
                var structUma = new JV_UM_UMA();

                var bSkipFlg = false;

                while (true)
                {
                    // バックグラウンドでの処理を実行
                    Application.DoEvents();

                    // キャンセルが押されたら処理(ループ)を抜ける
                    if (bCancelFlag)
                    {
                        break;
                    }

                    // JVGetsの呼び出し
                    lReturnCode = JVLink.JVGets(ref objBuff, lBuffSize, out string strFileName);
                    var szBuff = (byte[])objBuff;

                    // エラー判定
                    switch (lReturnCode)
                    {
                        // 正常
                        case int i when i >= (int)JvRead.Success:
                            // 文字コード変換(SJIS→UNICODE)
                            var strBuff = Encoding.GetEncoding("sjis").GetString(szBuff);

                            // データ区分の取得
                            var strRecID = strBuff[..2];

                            bSkipFlg = false;
                            // 処理対象データのみデータベースへ登録
                            if (strRecID == RecordKind.Race)
                            {
                                // レース詳細
                                structRace.SetDataB(ref strBuff);
                                _raceService.Add(structRace);
                            }
                            else if (strRecID == RecordKind.RaceUma)
                            {
                                // 馬毎レース情報
                                structRaceUma.SetDataB(ref strBuff);

                                var id = structRaceUma.id;
                                var raceId = _raceService.GetRaceId(
                                    id.Year!, id.MonthDay!, id.JyoCD!, id.Kaiji!, id.Nichiji!, id.RaceNum!);

                                _raceUmaService.Add(structRaceUma, raceId);
                            }
                            else if (strRecID == RecordKind.Uma)
                            {
                                // 競走馬マスタ
                                structUma.SetDataB(ref strBuff);
                                _umaService.Add(structUma);
                            }
                            else
                            {
                                // 対象外ファイルはスキップ(フラグを設定)
                                bSkipFlg = true;
                            }

                            if (bSkipFlg)
                            {
                                // 対象外ファイルはスキップ
                                JVLink.JVSkip();
                                // カレントファイルのプログレスバーを更新
                                barReadSize.Value = barReadSize.Maximum;

                                // 合計ファイル数のプログレスバーを更新
                                lTotalFileCount++;
                                barFileCount.Value = lTotalFileCount;
                            }
                            else
                            {
                                // カレントファイルのプログレスバーを更新
                                barReadSize.Maximum = JVLink.m_CurrentReadFilesize;
                                lTotalReadSize = lTotalReadSize + szBuff.Length - 1;
                                barReadSize.Value = lTotalReadSize;
                            }

                            break;
                        // ファイルの区切れ
                        case (int)JvRead.Eof:
                            // 合計ファイル数のプログレスバーを更新
                            lTotalFileCount++;
                            barFileCount.Value = lTotalFileCount;

                            // カレントファイルのプログレスバーを初期化
                            lTotalReadSize = 0;

                            // FromTimeを退避
                            strFromTime = JVLink.m_CurrentFileTimeStamp;

                            break;
                        // 全レコード読込み終了(EOF)
                        case (int)JvRead.Eol:
                            goto readFinish;
                        // ダウンロード中
                        case (int)JvRead.DownloadNow:
                            continue;
                        // エラー
                        case (int)JvRead.Err:
                            MessageBox.Show("JVGetsエラー コード：" + lReturnCode);
                            goto readFinish;
                    }
                }
            readFinish:;

                // FromTimeを設定ファイルに保存
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["fromTime"].Value = strFromTime;
                config.Save();

                if (!bCancelFlag)
                {
                    MessageBox.Show("開催情報の取得が終了しました。");
                }
                else
                {
                    MessageBox.Show("開催情報の取得を中止しました。");
                }

                // 開催年月日選択コンボボックスの表示
                SetCmdYearItem();

                // ボタンの抑止を解除
                btnGetJVData.Enabled = true;
                btnViewDenmaList.Enabled = true;
                btnInitDB.Enabled = true;
                btnSettingJVLink.Enabled = true;
                cmbYear.Enabled = true;
                btnStopJVData.Enabled = true;
                // プログレスバーを元に戻す
                barFileCount.Value = 0;
                barReadSize.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // JVCloseの呼出
                int lReturnCode = JVLink.JVClose();
                if (lReturnCode != 0)
                {
                    MessageBox.Show("JVCloseエラー コード：" + lReturnCode);
                }
            }
        }

        private void btnStopJVData_Click(object sender, EventArgs e)
        {
            // キャンセルフラグの設定
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
            DialogResult result = MessageBox.Show("ＤＢを初期化しますか？", "確認", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            // プログレスバーの初期化
            barReadSize.Value = 0;
            barFileCount.Value = 0;
            barFileCount.Maximum = 100;

            // テーブルの全レコードをクリア
            _raceService.DeleteAll();
            barFileCount.Value = 30;

            _raceUmaService.DeleteAll();
            barFileCount.Value = 60;

            _umaService.DeleteAll();
            barFileCount.Value = 90;

            // FromTimeを初期化し設定ファイルに保存
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["fromTime"].Value = "00000000000000";
            config.Save();

            // 開催年月日選択コンボボックスのクリア
            SetCmdYearItem();

            btnViewDenmaList.Enabled = false;
            cmbYear.Enabled = false;

            barFileCount.Value = 100;

            MessageBox.Show("ＤＢの初期化が終了しました。");
        }

        private void btnSettingJVLink_Click(object sender, EventArgs e)
        {
            // 設定画面表示
            int lReturnCode = JVLink.JVSetUIProperties();
            if (lReturnCode != 0)
            {
                MessageBox.Show("JVSetUIPropertiesエラー コード：" + lReturnCode);
            }
        }

        private void SetCmdYearItem()
        {
            // コンボボックスのクリア
            cmbYear.Text = "";
            cmbYear.Items.Clear();

            var raceYearMonthList = _raceService.GetRaceYearMonthDayList();

            foreach (var raceYearMonth in raceYearMonthList)
            {
                cmbYear.Items.Add(raceYearMonth.Year + raceYearMonth.MonthDay);
            }

            // 直近日付を初期表示
            if (cmbYear.Items.Count > 0)
            {
                cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            }
        }
    }
}