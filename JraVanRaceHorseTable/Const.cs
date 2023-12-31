﻿namespace JraVanRaceHorseTable
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
            public const string Canceled = "9";           // レース中止
            public const string Nar = "A";                // 地方競馬
            public const string Overseas = "B";           // 海外国際レース
        }
        public static readonly string[] DataKindNarAndOverseas = { DataKind.Nar, DataKind.Overseas };
        public static readonly string[] DataKindResult = { DataKind.Monday, DataKind.Canceled, DataKind.Nar, DataKind.Overseas };

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
            public const string IJyo = "2101";       // 異常区分コード
            public const string Hinsyu = "2201";     // 品種コード
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

        // トラックコード
        public class TrackCd
        {
            public const string TurfStraight = "10";              // 芝 直線
            public const string TurfTurnLeft  = "11";             // 芝 左回り
            public const string TurfTurnLeftOuter = "12";         // 芝 左回り 外回り
            public const string TurfTurnLeftInnerToOuter = "13";  // 芝 左回り 内→外回り
            public const string TurfTurnLeftOuterToInner = "14";  // 芝 左回り 外→内回り
            public const string TurfTurnLeftInner2Laps = "15";    // 芝 左回り 内2周
            public const string TurfTurnLeftOuter2Laps = "16";    // 芝 左回り 外2周
            public const string TurfTurnRight = "17";             // 芝 右回り
            public const string TurfTurnRightOuter = "18";        // 芝 右回り 外回り
            public const string TurfTurnRightInnerToOuter = "19"; // 芝 右回り 内→外回り
            public const string TurfTurnRightOuterToInner = "20"; // 芝 右回り 外→内回り
            public const string TurfTurnRightInner2Laps = "21";   // 芝 右回り 内2周
            public const string TurfTurnRightOuter2Laps = "22";   // 芝 右回り 外2周
            public const string DirtTurnLeft = "23";              // ダート 左回り
            public const string DirtTurnRight = "24";             // ダート 右回り
            public const string JumpTurfSash = "51";              // 障害 芝 襷
            public const string JumpTurfDirt = "52";              // 障害 芝 ダート
            public const string JumpTurfLeft = "53";              // 障害 芝 左
            public const string JumpTurf = "54";                  // 障害 芝
            public const string JumpTurfOuter = "55";             // 障害 芝 外回り
            public const string JumpTurfOuterToInner = "56";      // 障害 芝 外→内回り
            public const string JumpTurfInnerToOuter = "57";      // 障害 芝 内→外回り
            public const string JumpTurfInner2LapsOver = "58";    // 障害 芝 内2周以上
            public const string JumpTurfOuter2LapsOver = "59";    // 障害 芝 外2周以上

            public static string GetName(string value)
            {
                switch (value)
                {
                    case TurfStraight:
                        return "芝直";
                    case TurfTurnLeft:
                    case TurfTurnLeftOuter:
                    case TurfTurnLeftInnerToOuter:
                    case TurfTurnLeftOuterToInner:
                    case TurfTurnLeftInner2Laps:
                    case TurfTurnLeftOuter2Laps:
                        return "芝左";
                    case TurfTurnRight:
                    case TurfTurnRightOuter:
                    case TurfTurnRightInnerToOuter:
                    case TurfTurnRightOuterToInner:
                    case TurfTurnRightInner2Laps:
                    case TurfTurnRightOuter2Laps:
                        return "芝右";
                    case DirtTurnLeft:
                        return "ダ左";
                    case DirtTurnRight:
                        return "ダ右";
                    case JumpTurfSash:
                    case JumpTurfDirt:
                    case JumpTurfLeft:
                    case JumpTurf:
                    case JumpTurfOuter:
                    case JumpTurfOuterToInner:
                    case JumpTurfInnerToOuter:
                    case JumpTurfInner2LapsOver:
                    case JumpTurfOuter2LapsOver:
                        return "障害";
                    default:
                        return "";
                }
            }
        }

        // 馬場状態コード
        public class BabaCd
        {
            public const string GoodToFirm = "1"; // 良
            public const string Good = "2";       // 稍重
            public const string Yielding = "3";   // 重
            public const string Soft = "4";       // 不良

            public static string GetName(string value)
            {
                switch (value)
                {
                    case GoodToFirm:
                        return "良";
                    case Good:
                        return "稍";
                    case Yielding:
                        return "重";
                    case Soft:
                        return "不";
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

        // 着順背景色
        public static readonly string[] RankBackColor = { "#FFCCCC", "#FFCC80", "#CCFFFF" };

        // 性別
        public static readonly string[] SexName = { "牡", "牝", "騙" };
    }
}
