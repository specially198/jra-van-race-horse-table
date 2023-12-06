namespace JraVanRaceHorseTable
{
    public class Const
    {
        // レコード種別
        public class RecordKind
        {
            public const string Race = "RA";    // レース詳細
            public const string RaceUma = "SE"; // 馬毎レース情報
            public const string Uma = "UM";     // 競走馬マスタ
        }

        // JV-Linkステータス
        public enum JvRead
        {
            Eol,              // ファイルリスト読み込み終了 
            Success,          // 正常読み込み
            Eof = -1,         // ファイルの区切れ
            Err = -2,         // エラー
            DownloadNow = -3, // ダウンロード中
        }

        // データ区分
        public class DataKind
        {
            public const string Thursday = "1";           // 出走馬名表(木曜)
            public const string Friday = "2";             // 出馬表(金・土曜)
            public const string BreakingNews3 = "3";      // 成績速報(3着まで確定)
            public const string BreakingNews5 = "4";      // 成績速報(5着まで確定)
            public const string BreakingNewsAll = "5";    // 成績速報(全馬着順確定)
            public const string BreakingNewsCorner = "6"; // 成績速報(全馬着順+ｺｰﾅｰ通過順)
            public const string Monday = "7";             // 成績(月曜)
            public const string Nar = "A";                // 地方競馬
            public const string Overseas = "B";           // 海外国際レース
        }
        public static readonly string[] DataKindNarAndOverseas = { DataKind.Nar, DataKind.Overseas };

        // コード変換
        public class Code
        {
            public const string RaceCourse = "2001"; // 競馬場コード
            public const string DayOfWeek = "2002";  // 曜日コード
            public const string Syubetu = "2005";    // 競走種別コード
            public const string Kigo = "2006";       // 競走記号コード
            public const string Jyoken = "2007";     // 競走条件コード
            public const string Jyuryo = "2008";     // 重量種別コード
            public const string Track = "2009";      // トラックコード
            public const string Baba = "2010";       // 馬場状態コード
            public const string Weather = "2011";    // 天候コード
            public const string Keiro = "2203";      // 毛色コード
            public const string UmaKigo = "2204";    // 馬記号コード
            public const string Minarai = "2303";    // 騎手見習コード
        }

        // グレードコード
        public class GradeCd
        {
            public const string G1 = "A";
            public const string G2 = "B";
            public const string G3 = "C";
            public const string JG1 = "F";
            public const string JG2 = "G";
            public const string JG3 = "H";

            public static string GetName(string value)
            {
                switch(value)
                {
                    case G1:
                        return "(ＧⅠ)";
                    case G2:
                        return "(ＧⅡ)";
                    case G3:
                        return "(ＧⅢ)";
                    case JG1:
                        return "(ＪＧⅠ)";
                    case JG2:
                        return "(ＪＧⅡ)";
                    case JG3:
                        return "(ＪＧⅢ)";
                    default:
                        return "";
                }
            }
        }

        // 競走種別コード
        public class SyubetuCd
        {
            public const string Age2 = "11";
            public const string Age3 = "12";
            public const string OverAge3 = "13";
            public const string OverAge4 = "14";
            public const string JumpOverAge3 = "18";
            public const string JumpOverAge4 = "19";

            public static string GetName(string value)
            {
                switch (value)
                {
                    case Age2:
                        return "２歳";
                    case Age3:
                        return "３歳";
                    case OverAge3:
                        return "３歳上";
                    case OverAge4:
                        return "４歳上";
                    case JumpOverAge3:
                        return "障害３歳上";
                    case JumpOverAge4:
                        return "障害４歳上";
                    default:
                        return "";
                }
            }
        }

        // 競走条件コード
        public class JyokenCd
        {
            public const string Class1Win = "005";
            public const string Class2Win = "010";
            public const string Class3Win = "016";
            public const string NewComer = "701";
            public const string Maiden = "703";
            public const string Open = "999";

            public static string GetName(string value)
            {
                switch (value)
                {
                    case Class1Win:
                        return "１勝クラス";
                    case Class2Win:
                        return "２勝クラス";
                    case Class3Win:
                        return "３勝クラス";
                    case NewComer:
                        return "新馬";
                    case Maiden:
                        return "未勝利";
                    case Open:
                        return "オープン";
                    default:
                        return "";
                }
            }
        }

        // 枠背景色
        public static readonly string[] WakuBackColor = {
            "#FFFFFF", "#010000", "#FF0000", "#0000FF", "#FFFF00", "#00FF00", "#FF8000", "#FF8080"
        };
        // 枠前景色
        public static readonly string[] WakuForeColor = {"", "White", "White", "White", "", "", "", ""};

        // 性別
        public static readonly string[] SexName = { "牡", "牝", "騙" };
    }
}
