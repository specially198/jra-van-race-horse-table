using JraVanRaceHorseTable.Models;
using JraVanRaceHorseTable.Services;
using static JraVanRaceHorseTable.Const;

namespace JraVanRaceHorseTable
{
    public partial class frmUmaProfile : Form
    {
        private readonly IRaceUmaService _raceUmaService;
        private readonly IUmaService _umaService;

        public frmUmaProfile(IRaceUmaService raceUmaService, IUmaService umaService)
        {
            InitializeComponent();

            _raceUmaService = raceUmaService;
            _umaService = umaService;
        }

        private void frmUmaProfile_Load(object sender, EventArgs e)
        {
            // 血統登録番号の取得
            var strKettoNum = txtParam.Text;

            // 血統登録番号よりその馬の競走馬マスタ、及びその馬の走ったレースの馬毎レース情報を取得
            var uma = _umaService.GetUma(strKettoNum) ?? throw new Exception("競走馬情報が取得できない");
            var raceUmas = _raceUmaService.GetListByHorse(strKettoNum);

            if (raceUmas.Count == 0)
            {
                MessageBox.Show("該当データは未取得です");
                return;
            }

            // ラベル表示
            SetLabel(uma, raceUmas[0]);

            // グリッド内表示
            SetGrid(raceUmas);
        }

        private void SetLabel(Uma uma, RaceUma raceUma)
        {
            // ラベル表示（データ作成日）
            DateTime raceDate = new(
            int.Parse(uma.MakeDate[..4]), int.Parse(uma.MakeDate.Substring(4, 2)), int.Parse(uma.MakeDate[6..]));
            lblUmaProfile3.Text = raceDate.ToString("yyyy/M/d") + " 作成データ";

            var clsCodeConv = new ClsCodeConv(Application.StartupPath + "/CodeTable.csv");

            // ラベル表示（馬記号、馬名）
            var umaKigoName = clsCodeConv.GetCodeName(Code.UmaKigo, uma.UmaKigoCD, 1);
            lblUmaProfile1.Text = string.Format(" {0}{1}", umaKigoName, uma.Bamei);
            DateTime birthDate = new(
            int.Parse(uma.BirthDate[..4]), int.Parse(uma.BirthDate.Substring(4, 2)), int.Parse(uma.BirthDate[6..]));

            // 性齢、毛色、品種、生年月日
            var text1 = string.Format(" {0}歳 {1} {2} {3}生",
            SexName[int.Parse(uma.SexCD!) - 1] + raceUma.Barei!.TrimStart('0'),
                clsCodeConv.GetCodeName(Code.Keiro, uma.KeiroCD, 1),
                clsCodeConv.GetCodeName(Code.Hinsyu, uma.HinsyuCD, 2),
                birthDate.ToString("yyyy年M月d日"));

            DateTime regDate = new(
            int.Parse(uma.RegDate[..4]), int.Parse(uma.RegDate.Substring(4, 2)), int.Parse(uma.RegDate[6..]));

            // 競走馬登録日、調教師
            var text2 = string.Format(" 競走馬登録: {0}   調教師    : {1}",
            regDate.ToString("yyyy年M月d日"),
                uma.ChokyosiRyakusyo);

            // 産地、馬主
            var text3 = string.Format(" 産地      : {0} 馬主      : {1}",
                uma.SanchiName.Trim().PadRight(16),
                uma.BanusiName);

            // 生産者
            string? breederName;
            if (uma.Syotai.Trim().Length != 0)
            {
                breederName = string.Format(" 招待地域  : {0}", uma.Syotai.Trim().PadRight(16));
            }
            else
            {
                breederName = "".PadLeft(29);
            }
            breederName += string.Format(" 生産者    : {0}", uma.BreederName);

            var text4 = breederName;

            // ラベル表示（性齢、毛色、品種、生年月日、競走馬登録日、調教師、産地、馬主、生産者）
            lblUmaProfile2.Text = text1 + "\r\n" + text2 + "\r\n" + text3 + "\r\n" + text4;

            // ラベル表示（賞金）
            int ruikeiHonsyoHeiti = int.Parse((uma.RuikeiHonsyoHeiti + "00"));
            int ruikeiHonsyoSyogai = int.Parse((uma.RuikeiHonsyoSyogai + "00"));
            int ruikeiFukaHeichi = int.Parse((uma.RuikeiFukaHeichi + "00"));
            int ruikeiFukaSyogai = int.Parse((uma.RuikeiFukaSyogai + "00"));
            int ruikeiSyutokuHeichi = int.Parse((uma.RuikeiSyutokuHeichi + "00"));
            int ruikeiSyutokuSyogai = int.Parse((uma.RuikeiSyutokuSyogai + "00"));
            lblUmaProfile4.Text =
                string.Format(" 平地本賞金  : {0}円 ", $"{ruikeiHonsyoHeiti:N0}".PadLeft(11))
                + string.Format(" 障害本賞金  : {0}円 ", $"{ruikeiHonsyoSyogai:N0}".PadLeft(11)) + "\r\n"
                + string.Format(" 平地付加賞金  : {0}円 ", $"{ruikeiFukaHeichi:N0}".PadLeft(11))
                + string.Format(" 障害付加賞金  : {0}円 ", $"{ruikeiFukaSyogai:N0}".PadLeft(11)) + "\r\n"
                + string.Format(" 平地収得賞金  : {0}円 ", $"{ruikeiSyutokuHeichi:N0}".PadLeft(11))
                + string.Format(" 障害収得賞金  : {0}円 ", $"{ruikeiSyutokuSyogai:N0}".PadLeft(11));

            // ラベル表示（脚質）
            lblUmaProfile5.Text =
                string.Format(" 逃げ回数: {0}回", int.Parse(uma.Kyakusitu1)) + "\r\n"
                + string.Format(" 先行回数: {0}回", int.Parse(uma.Kyakusitu2)) + "\r\n"
                + string.Format(" 差し回数: {0}回", int.Parse(uma.Kyakusitu3)) + "\r\n"
                + string.Format(" 追込回数: {0}回", int.Parse(uma.Kyakusitu4));
        }

        private void SetGrid(List<RaceUma> raceUmas)
        {
            // 行・列数、高さ指定
            grdUmaProfile.ColumnCount = 27;
            grdUmaProfile.RowCount = raceUmas.Count;
            grdUmaProfile.RowHeadersVisible = false;
            grdUmaProfile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 文字の表示位置
            grdUmaProfile.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdUmaProfile.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdUmaProfile.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdUmaProfile.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdUmaProfile.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // タイトル行の表示
            string[] titles = { "開催日", "回場日", "R", "レース名", "条件", "コース", "馬場", "習", "騎手", "負担", "B", "頭数", "枠番", "馬番", "異常", "着順", "タイム", "コーナー通過順", "単オッズ", "単人気", "馬体重", "増減差", "獲得本賞金", "獲得付加賞金", "後3ハロン", "1(2)着馬", "タイム差" };
            for (int i = 0; i < titles.Length; i++)
            {
                grdUmaProfile.Columns[i].HeaderText = titles[i];
            }

            var clsCodeConv = new ClsCodeConv(Application.StartupPath + "/CodeTable.csv");

            // 過去走表示
            var row = 0;
            var col = 0;
            foreach (var raceUma in raceUmas)
            {
                var race = raceUma.Race;

                // 開催日
                grdUmaProfile.Rows[row].Cells[col].Value = string.Format(
                    "{0}/{1}/{2}", race.Year, race.MonthDay[..2], race.MonthDay[2..]);
                col++;

                // 開催
                var raceCourseName = clsCodeConv.GetCodeName(Code.RaceCourse, race.JyoCD, 3);
                grdUmaProfile.Rows[row].Cells[col].Value = race.Kaiji.TrimStart('0') + raceCourseName + race.Nichiji.TrimStart('0');
                col++;

                // レース番号
                grdUmaProfile.Rows[row].Cells[col].Value = race.RaceNum!.TrimStart('0');
                col++;

                // レース名
                grdUmaProfile.Rows[row].Cells[col].Value = race.Ryakusyo6.Trim() + GradeCd.GetName(race.GradeCD);
                col++;

                // 競走条件
                grdUmaProfile.Rows[row].Cells[col].Value = SyubetuCd.GetName(race.SyubetuCD) + JyokenCd.GetName(race.JyokenCD5);
                col++;

                // コース
                grdUmaProfile.Rows[row].Cells[col].Value = TrackCd.GetName(race.TrackCD) + race.Kyori;
                col++;

                // 馬場
                var baba = "";
                if (!"0".Equals(race.SibaBabaCD))
                {
                    baba = "芝" + BabaCd.GetName(race.SibaBabaCD);
                }
                if (!"0".Equals(race.DirtBabaCD))
                {
                    if (baba.Length != 0)
                    {
                        baba += ":";
                    }
                    baba += "ダ" + BabaCd.GetName(race.DirtBabaCD);
                }
                grdUmaProfile.Rows[row].Cells[col].Value = baba;
                col++;

                // 騎手見習区分
                var minaraiName = clsCodeConv.GetCodeName(Code.Minarai, raceUma.MinaraiCD, 1);
                grdUmaProfile.Rows[row].Cells[col].Value = minaraiName;
                col++;

                // 騎手
                grdUmaProfile.Rows[row].Cells[col].Value = raceUma.KisyuRyakusyo;
                col++;

                // 負担
                grdUmaProfile.Rows[row].Cells[col].Value = raceUma.Futan[..2] + "." + raceUma.Futan[2..];
                col++;

                // ブリンカー区分
                if ("1".Equals(raceUma.Blinker))
                {
                    grdUmaProfile.Rows[row].Cells[col].Value = "B";
                }
                col++;

                // 頭数
                grdUmaProfile.Rows[row].Cells[col].Value = race.SyussoTosu;
                col++;

                // 枠番
                grdUmaProfile.Rows[row].Cells[col].Value = raceUma.Wakuban;
                col++;

                // 馬番
                grdUmaProfile.Rows[row].Cells[col].Value = raceUma.Umaban!.TrimStart('0');
                col++;

                // 異常
                var iJyoName = clsCodeConv.GetCodeName(Code.IJyo, raceUma.IJyoCD, 2);
                grdUmaProfile.Rows[row].Cells[col].Value = iJyoName;
                col++;

                // 着順
                if (!"0".Equals(raceUma.KakuteiJyuni))
                {
                    var cell = grdUmaProfile.Rows[row].Cells[col];
                    cell.Value = raceUma.KakuteiJyuni.TrimStart('0');
                    // 1～3着は色分け
                    var rank = int.Parse(raceUma.KakuteiJyuni);
                    switch (rank)
                    {
                        case 1:
                        case 2:
                        case 3:
                            cell.Style.BackColor = ColorTranslator.FromHtml(RankBackColor[rank - 1]);
                            break;
                        default:
                            break;
                    }
                }
                col++;

                // タイム
                if (!"0000".Equals(raceUma.Time))
                {
                    grdUmaProfile.Rows[row].Cells[col].Value = raceUma.Time![..1] + ":" + raceUma.Time!.Substring(1, 2) + "." + raceUma.Time[3..];
                }
                col++;

                // コーナー通過順
                var corner = "";
                // 第1コーナー通過順位
                if (!"00".Equals(raceUma.Jyuni1c))
                {
                    corner = raceUma.Jyuni1c.TrimStart('0').PadLeft(2) + "-";
                }
                // 第2コーナー通過順位
                if (!"00".Equals(raceUma.Jyuni2c))
                {
                    corner += raceUma.Jyuni2c.TrimStart('0').PadLeft(2) + "-";
                }
                // 第3コーナー通過順位
                if (!"00".Equals(raceUma.Jyuni3c))
                {
                    corner += raceUma.Jyuni3c.TrimStart('0').PadLeft(2) + "-";
                }
                // 第4コーナー通過順位
                if (!"00".Equals(raceUma.Jyuni4c))
                {
                    corner += raceUma.Jyuni4c.TrimStart('0').PadLeft(2);
                }

                grdUmaProfile.Rows[row].Cells[col].Value = corner;
                col++;

                // 単オッズ
                if (!"0000".Equals(raceUma.Odds))
                {
                    grdUmaProfile.Rows[row].Cells[col].Value = raceUma.Odds![..3].TrimStart('0') + "." + raceUma.Odds![3..];
                }
                col++;

                // 単人気
                if (!"0".Equals(raceUma.Ninki))
                {
                    grdUmaProfile.Rows[row].Cells[col].Value = raceUma.Ninki!.TrimStart('0');
                }
                col++;

                // 馬体重
                if (!"   ".Equals(raceUma.BaTaijyu) && !"0".Equals(raceUma.BaTaijyu) && !"999".Equals(raceUma.BaTaijyu))
                {
                    grdUmaProfile.Rows[row].Cells[col].Value = raceUma.BaTaijyu + "kg";
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
                grdUmaProfile.Rows[row].Cells[col].Value = zogen;
                col++;

                // 獲得本賞金
                var honsyokin = "";
                if (!"00000000".Equals(raceUma.Honsyokin))
                {
                    int intHonsyokin = int.Parse((raceUma.Honsyokin + "00").TrimStart('0'));
                    honsyokin = $"{intHonsyokin:N0}";
                }
                else
                {
                    honsyokin = "0";
                }
                grdUmaProfile.Rows[row].Cells[col].Value = honsyokin;
                col++;

                // 獲得付加賞金
                var fukasyokin = "";
                if (!"00000000".Equals(raceUma.Fukasyokin))
                {
                    int intFukasyokin = int.Parse((raceUma.Fukasyokin + "00").TrimStart('0'));
                    fukasyokin = $"{intFukasyokin:N0}";
                }
                else
                {
                    fukasyokin = "0";
                }
                grdUmaProfile.Rows[row].Cells[col].Value = fukasyokin;
                col++;

                // 後3ハロン
                if (!"000".Equals(raceUma.HaronTimeL3))
                {
                    if ("999".Equals(raceUma.HaronTimeL3))
                    {
                        grdUmaProfile.Rows[row].Cells[col].Value = "----";
                    }
                    else
                    {
                        grdUmaProfile.Rows[row].Cells[col].Value = raceUma.HaronTimeL3[..2] + "." + raceUma.HaronTimeL3[2..];
                    }
                }
                col++;

                // 1(2)着馬
                if ("01".Equals(raceUma.KakuteiJyuni))
                {
                    grdUmaProfile.Rows[row].Cells[col].Value = "(" + raceUma.Bamei1.Trim() + ")";
                }
                else
                {
                    grdUmaProfile.Rows[row].Cells[col].Value = raceUma.Bamei1.Trim();
                }
                col++;

                // タイム差
                if (!"0000".Equals(raceUma.TimeDiff) && !"9999".Equals(raceUma.TimeDiff))
                {
                    grdUmaProfile.Rows[row].Cells[col].Value =
                        raceUma.TimeDiff[..1] + int.Parse(raceUma.TimeDiff.Substring(1, 2)) + "." + raceUma.TimeDiff[3..];
                }
                col++;

                row++;
                col = 0;
            }
        }
    }
}
