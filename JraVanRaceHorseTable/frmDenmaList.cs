using JraVanRaceHorseTable.Services;
using static JraVanRaceHorseTable.Const;

namespace JraVanRaceHorseTable
{
    public partial class frmDenmaList : Form
    {
        private readonly IFormFactory _factory;
        private readonly IRaceService _raceService;

        private string[,] index = new string[12, 3];

        public frmDenmaList(IFormFactory factory, IRaceService raceService)
        {
            InitializeComponent();

            _factory = factory;
            _raceService = raceService;
        }

        private void frmDenmaList_Load(object sender, EventArgs e)
        {
            // 開催年の取得
            var year = txtParam.Text[..4];
            // 開催月日の取得
            var monthDay = txtParam.Text[4..];

            var races = _raceService.GetListByYearAndMonthDay(year, monthDay);

            grdDenmaList.ColumnCount = 3;
            grdDenmaList.RowCount = 12;
            grdDenmaList.RowHeadersVisible = false;
            grdDenmaList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grdDenmaList.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdDenmaList.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdDenmaList.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdDenmaList.Columns[0].Width = 500;
            grdDenmaList.Columns[1].Width = 500;
            grdDenmaList.Columns[2].Width = 500;

            var col = 0;
            var beforeJyoCd = "";

            // ラベルの表示
            var clsCodeConv = new ClsCodeConv(Application.StartupPath + "/CodeTable.csv");
            var dayOfWeekName = clsCodeConv.GetCodeName(Code.DayOfWeek, races[0].YoubiCD, 2);
            lblDenmaList.Text = string.Format("  {0}年{1}月{2}日({3})", year, monthDay[..2], monthDay[2..], dayOfWeekName);

            // 出馬表選択一覧の表示
            foreach (var r in races)
            {
                // タイトル行の表示
                // 競馬場コードが変わったら次の列をカレント列とする
                if (!string.IsNullOrEmpty(beforeJyoCd) && !r.JyoCD.Equals(beforeJyoCd))
                {
                    col++;
                }
                beforeJyoCd = r.JyoCD;

                // 競馬場コードの変換
                var raceCourseName = clsCodeConv.GetCodeName(Code.RaceCourse, r.JyoCD, 4);
                // 開催回、開催日数ゼロサプレス
                var kaiji = r.Kaiji.TrimStart('0');
                var nichiji = r.Nichiji.TrimStart('0');

                // ヘッダー
                grdDenmaList.Columns[col].HeaderText = string.Format("{0} {1}回{2}日", raceCourseName, kaiji, nichiji);

                var raceNum = int.Parse(r.RaceNum!.TrimStart('0'));

                // [レース番号] [競走名略称６文字][重賞][競走種別][競争条件]
                var text1 = string.Format("{0}R {1} {2} {3}",
                    raceNum.ToString().PadLeft(4),
                    (r.Ryakusyo6 + GradeCd.GetName(r.GradeCD)).Trim().PadRight(9),
                    SyubetuCd.GetName(r.SyubetuCD),
                    JyokenCd.GetName(r.JyokenCD5));

                var trackName = clsCodeConv.GetCodeName(Code.Track, r.TrackCD, 2);
                var tosu = r.TorokuTosu!.TrimStart('0');
                if (DataKind.BreakingNewsCorner.Equals(r.DataKubun)
                    || DataKind.Monday.Equals(r.DataKubun))
                {
                    tosu = r.SyussoTosu!.TrimStart('0');
                }

                // [発走時刻][トラックコード][距離][出走頭数](成績確定までは登録頭数)
                var text2 = string.Format("{0}:{1} {2} {3}m {4}頭",
                    r.HassoTime[..2], r.HassoTime[2..],
                    trackName.PadRight(18),
                    r.Kyori,
                    tosu);

                // 表示
                grdDenmaList.Rows[raceNum - 1].Cells[col].Value = text1 + "\r\n" + text2;
                // index(次画面移行の際に渡すパラメータ)保持
                index[raceNum - 1, col] = txtParam.Text + r.JyoCD + r.RaceNum;
            }

        }

        private void grdDenmaList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 選択されたグリッドの列、行を取得
            var row = e.RowIndex;
            var col = e.ColumnIndex;

            // グリッドが空でない場合、次のフォームを開く
            if (grdDenmaList[col, row].Value != null)
            {
                var frmRaceInfo = _factory.Create<frmRaceInfo>();
                frmRaceInfo.txtParam.Text = index[row, col];
                frmRaceInfo.Show();
            }
        }
    }
}
