using JraVanRaceHorseTable.Models;
using JraVanRaceHorseTable.Services;
using static JraVanRaceHorseTable.Const;

namespace JraVanRaceHorseTable
{
    public partial class frmRaceInfo : Form
    {
        private readonly IRaceService _raceService;
        private readonly IRaceUmaService _raceUmaService;
        private readonly IUmaService _umaService;

        private List<string> paramList = new();
        
        public frmRaceInfo(IRaceService raceService, IRaceUmaService raceUmaService, IUmaService umaService)
        {
            InitializeComponent();

            _raceService = raceService;
            _raceUmaService = raceUmaService;
            _umaService = umaService;
        }

        private void frmRaceInfo_Load(object sender, EventArgs e)
        {
            // 開催年の取得
            var year = txtParam.Text[..4];
            // 開催月日の取得
            var monthDay = txtParam.Text.Substring(4, 4);
            // 競馬場コードの取得
            var jyoCd = txtParam.Text.Substring(8, 2);
            // レース番号の取得
            var raceNum = txtParam.Text.Substring(10, 2);

            var race = _raceService.GetRace(year, monthDay, jyoCd, raceNum);

            var raceUmas = _raceUmaService.GetList(race.Id, race.DataKubun);

            // ラベル表示
            SetLabel(race);

            // グリッド内表示
            SetGrid(raceUmas);
        }

        private void SetLabel(Race race)
        {
            // 競馬場コードの変換
            var clsCodeConv = new ClsCodeConv(Application.StartupPath + "/CodeTable.csv");
            var raceCourseName = clsCodeConv.GetCodeName(Code.RaceCourse, race.JyoCD, 4);

            string hondai;
            if (!"000".Equals(race.Nkai))
            {
                hondai = string.Format(" 第{0}回 {1}{2}", race.Nkai.TrimStart('0'), race.Hondai.Trim(), GradeCd.GetName(race.GradeCD));
            }
            else
            {
                hondai = string.Format(" {0}", race.Hondai.Trim());
            }

            // ラベル表示（場、レース番号、本題（＋重賞の場合は回次、グレード））
            lblRaceInfo1.Text = string.Format(" {0}{1}R{2}", raceCourseName, race.RaceNum!.TrimStart('0'), hondai);

            var dayOfWeekName = clsCodeConv.GetCodeName(Code.DayOfWeek, race.YoubiCD, 2);
            var syubetuName = clsCodeConv.GetCodeName(Code.Syubetu, race.SyubetuCD, 3);
            var jyokenName = clsCodeConv.GetCodeName(Code.Jyoken, race.JyokenCD5, 1);
            var kigoName = clsCodeConv.GetCodeName(Code.Kigo, race.KigoCD, 1);

            // [年月日][曜日][発走時刻][競走種別][競争条件]
            var monthDay = txtParam.Text.Substring(4, 4);
            var text1 = string.Format(" {0}/{1}/{2}({3})  発走 {4}:{5} {6} {7} ",
                txtParam.Text[..4], monthDay[..2], monthDay[2..], dayOfWeekName,
                race.HassoTime[..2], race.HassoTime[2..],
                syubetuName,
                jyokenName);

            var jyuryoName = clsCodeConv.GetCodeName(Code.Jyuryo, race.JyuryoCD, 1);

            // [競走記号][重量種別]
            var text2 = string.Format("{0}   {1}", kigoName, jyuryoName);

            // [コース区分]
            var courseKubun = race.CourseKubunCD;
            if ("  ".Equals(race.CourseKubunCD))
            {
                courseKubun += "        ";
            }
            else
            {
                courseKubun += "コース  ";
            }
            var text3 = string.Format("{0}{1}", "".PadLeft(17), courseKubun);

            var TrackName = clsCodeConv.GetCodeName(Code.Track, race.TrackCD, 2);

            // [トラックコード][距離]
            var text4 = string.Format("{0}{1}m ", TrackName, race.Kyori);

            var tosuWord = "登録頭数 ";
            var tosu = race.TorokuTosu;
            if (DataKind.BreakingNewsCorner.Equals(race.DataKubun)
                || DataKind.Monday.Equals(race.DataKubun))
            {
                tosuWord = "出走頭数 ";
                tosu = race.SyussoTosu.TrimStart('0');
            }

            var honsyokin = race.Honsyokin1[..6].TrimStart('0').PadLeft(6)
                + race.Honsyokin2[..6].TrimStart('0').PadLeft(6)
                + race.Honsyokin3[..6].TrimStart('0').PadLeft(6)
                + race.Honsyokin4[..6].TrimStart('0').PadLeft(6)
                + race.Honsyokin5[..6].TrimStart('0').PadLeft(6);

            // [出走頭数]/[登録頭数][本賞金]（1着～5着）
            var text5 = string.Format("{0}{1}頭  本賞金    {2}万円", tosuWord, tosu, honsyokin);

            var tenkoName = clsCodeConv.GetCodeName(Code.Weather, race.TenkoCD, 1);

            var baba = "";
            if (!"0".Equals(race.SibaBabaCD))
            {
                var sibaBabaName = clsCodeConv.GetCodeName(Code.Baba, race.SibaBabaCD, 1);
                baba = string.Format("芝:{0} ", sibaBabaName);
            }
            if (!"0".Equals(race.DirtBabaCD))
            {
                var dirtBabaName = clsCodeConv.GetCodeName(Code.Baba, race.DirtBabaCD, 1);
                baba = string.Format("ダート:{0} ", dirtBabaName);
            }

            var nyusenTosu = "".PadLeft(15);
            if (!"00".Equals(race.NyusenTosu))
            {
                nyusenTosu = string.Format("入線頭数 {0}頭  ", race.NyusenTosu!.TrimStart('0').PadLeft(2));
            }

            var fukasyokin = "";
            if (!"00000000".Equals(race.Fukasyokin1))
            {
                fukasyokin = "付加賞金 ";
                var fukasyokin1Integer = race.Fukasyokin1[..6];
                var fukasyokin1Decimal = race.Fukasyokin1.Substring(6, 1);
                if ("0".Equals(fukasyokin1Decimal))
                {
                    fukasyokin += fukasyokin1Integer.TrimStart('0').PadLeft(6);
                }
                else
                {
                    fukasyokin += (fukasyokin1Integer.TrimStart('0') + "." + fukasyokin1Decimal).PadLeft(6);
                }
                var fukasyokin2Integer = race.Fukasyokin2[..6];
                var fukasyokin2Decimal = race.Fukasyokin2.Substring(6, 1);
                if ("0".Equals(fukasyokin2Decimal))
                {
                    fukasyokin += fukasyokin2Integer.TrimStart('0').PadLeft(6);
                }
                else
                {
                    fukasyokin += (fukasyokin2Integer.TrimStart('0') + "." + fukasyokin2Decimal).PadLeft(6);
                }
                var fukasyokin3Integer = race.Fukasyokin3[..6];
                var fukasyokin3Decimal = race.Fukasyokin3.Substring(6, 1);
                if ("0".Equals(fukasyokin3Decimal))
                {
                    fukasyokin += fukasyokin3Integer.TrimStart('0').PadLeft(6);
                }
                else
                {
                    fukasyokin += (fukasyokin3Integer.TrimStart('0') + "." + fukasyokin3Decimal).PadLeft(6);
                }
                fukasyokin += " 万円";
            }

            // [天候][馬場状態][入線頭数][付加賞金]（1着～3着）
            var text6 = string.Format("{0}{1}{2}{3}{4}",
                "".PadLeft(17), tenkoName.PadRight(5), baba.PadRight(21), nyusenTosu, fukasyokin);

            // ラベル表示（レース詳細）
            lblRaceInfo2.Text = text1.PadRight(58) + text2 + "\r\n"
                + text3 + text4.PadRight(16) + text5 + "\r\n"
                + text6;

            // ラベル表示（データ作成日）
            DateTime raceDate = new(
                int.Parse(race.MakeDate[..4]), int.Parse(race.MakeDate.Substring(4, 2)), int.Parse(race.MakeDate[6..]));
            lblRaceInfo3.Text = raceDate.ToString("yyyy/M/d") + " 作成データ";
        }

        private void SetGrid(List<RaceUma> raceUmas)
        {
            // 行・列数、高さ指定
            grdDenmaList.ColumnCount = 22;
            grdDenmaList.RowCount = raceUmas.Count;
            grdDenmaList.RowHeadersVisible = false;
            grdDenmaList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 文字の表示位置
            grdDenmaList.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDenmaList.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDenmaList.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDenmaList.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDenmaList.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // タイトル行の表示
            string[] titles = { "枠", "番", "B", "馬記号", "馬名", "性齢", "毛", "習", "騎手", "負担", "馬体重", "増減", "本賞金累計", "収得賞金", "調教師", "馬主", "生産者", "逃げ回数", "先行回数", "差し回数", "追込回数", "服色" };
            for (int i = 0; i < titles.Length; i++)
            {
                grdDenmaList.Columns[i].HeaderText = titles[i];
            }

            // 血統登録番号に対応した競走馬マスタを持ってくる
            List<string> kettoNumList = new();
            foreach (var raceUma in raceUmas)
            {
                kettoNumList.Add(raceUma.KettoNum);
            }
            var umas = _umaService.GetList(kettoNumList);

            var clsCodeConv = new ClsCodeConv(Application.StartupPath + "/CodeTable.csv");

            var row = 0;
            var col = 0;
            foreach (var raceUma in raceUmas)
            {
                // 出馬表表示

                // 枠番
                if (!"0".Equals(raceUma.Wakuban))
                {
                    var cell = grdDenmaList.Rows[row].Cells[col];
                    cell.Value = raceUma.Wakuban;
                    // 枠番によって色分け
                    cell.Style.BackColor = ColorTranslator.FromHtml(WakuBackColor[int.Parse(raceUma.Wakuban) - 1]);
                    cell.Style.ForeColor = Color.FromName(WakuForeColor[int.Parse(raceUma.Wakuban) - 1]);
                }
                col++;

                // 馬番
                if (!"0".Equals(raceUma.Umaban))
                {
                    grdDenmaList.Rows[row].Cells[col].Value = raceUma.Umaban!.TrimStart('0');
                }
                col++;

                // ブリンカー
                if ("1".Equals(raceUma.Blinker))
                {
                    grdDenmaList.Rows[row].Cells[col].Value = "B";
                }
                col++;

                // 馬記号
                var umaKigoName = clsCodeConv.GetCodeName(Code.UmaKigo, raceUma.UmaKigoCD, 1);
                grdDenmaList.Rows[row].Cells[col].Value = umaKigoName;
                col++;

                // 馬名
                grdDenmaList.Rows[row].Cells[col].Value = raceUma.Bamei.Trim();
                col++;

                // 性別馬齢
                grdDenmaList.Rows[row].Cells[col].Value = SexName[int.Parse(raceUma.SexCD!) - 1] + raceUma.Barei!.TrimStart('0');
                col++;

                // 毛色
                var keiroName = clsCodeConv.GetCodeName(Code.Keiro, raceUma.KeiroCD, 1);
                grdDenmaList.Rows[row].Cells[col].Value = keiroName;
                col++;

                // 騎手見習い区分
                var minaraiName = clsCodeConv.GetCodeName(Code.Minarai, raceUma.MinaraiCD, 1);
                grdDenmaList.Rows[row].Cells[col].Value = minaraiName;
                col++;

                // 騎手
                grdDenmaList.Rows[row].Cells[col].Value = raceUma.KisyuRyakusyo;
                col++;

                // 負担
                grdDenmaList.Rows[row].Cells[col].Value = raceUma.Futan[..2] + "." + raceUma.Futan[2..];
                col++;

                // 馬体重
                if (raceUma.BaTaijyu!.Trim().Length != 0 && !"0".Equals(raceUma.BaTaijyu) && !"999".Equals(raceUma.BaTaijyu))
                {
                    grdDenmaList.Rows[row].Cells[col].Value = raceUma.BaTaijyu + "kg";
                }
                col++;

                // 増減
                var zogen = "";
                if (" ".Equals(raceUma.ZogenFugo))
                {
                    switch (raceUma.ZogenSa)
                    {
                        case "000":
                            zogen = "±0";
                            break;
                        case "999":
                            zogen = "----";
                            break;
                        case "   ":
                            zogen = "    ";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    zogen = raceUma.ZogenFugo + raceUma.ZogenSa.TrimStart('0');

                }
                grdDenmaList.Rows[row].Cells[col].Value = zogen;
                col++;

                // 血統登録番号よりその馬の競走馬マスタを探す
                var uma = umas.Where(u => u.KettoNum == raceUma.KettoNum).FirstOrDefault();

                if (uma != null)
                {
                    // 次画面に渡すパラメータ
                    paramList.Add(uma.KettoNum);

                    // 本賞金累計
                    var ruikeiHonsyo = "";
                    if (!"000000000".Equals(uma.RuikeiHonsyoHeiti))
                    {
                        int ruikeiHonsyoHeiti = int.Parse((uma.RuikeiHonsyoHeiti + "00").TrimStart('0'));
                        ruikeiHonsyo = $"{ruikeiHonsyoHeiti:N0}";
                    }
                    else
                    {
                        ruikeiHonsyo = "0";
                    }
                    grdDenmaList.Rows[row].Cells[col].Value = ruikeiHonsyo;
                    col++;

                    // 収得賞金累計
                    var ruikeiSyutoku = "";
                    if (!"000000000".Equals(uma.RuikeiSyutokuHeichi))
                    {
                        int ruikeiSyutokuHeichi = int.Parse((uma.RuikeiSyutokuHeichi + "00").TrimStart('0'));
                        ruikeiSyutoku = $"{ruikeiSyutokuHeichi:N0}";
                    }
                    else
                    {
                        ruikeiSyutoku = "0";
                    }
                    grdDenmaList.Rows[row].Cells[col].Value = ruikeiSyutoku;
                    col++;
                }

                // 調教師
                grdDenmaList.Rows[row].Cells[col].Value = raceUma.ChokyosiRyakusyo;
                col++;

                // 馬主
                grdDenmaList.Rows[row].Cells[col].Value = raceUma.BanusiName!.Trim();
                col++;

                if (uma != null)
                {
                    // 生産者
                    grdDenmaList.Rows[row].Cells[col].Value = uma.BreederName.Trim();
                    col++;

                    // 逃げ回数
                    grdDenmaList.Rows[row].Cells[col].Value = uma.Kyakusitu1.TrimStart('0');
                    col++;

                    // 先行回数
                    grdDenmaList.Rows[row].Cells[col].Value = uma.Kyakusitu2.TrimStart('0');
                    col++;

                    // 差し回数
                    grdDenmaList.Rows[row].Cells[col].Value = uma.Kyakusitu3.TrimStart('0');
                    col++;

                    // 追込回数
                    grdDenmaList.Rows[row].Cells[col].Value = uma.Kyakusitu4.TrimStart('0');
                    col++;
                }

                // 服色
                grdDenmaList.Rows[row].Cells[col].Value = raceUma.Fukusyoku.Trim();
                col++;

                row++;
                col = 0;
            }
        }

        private void grdDenmaList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
