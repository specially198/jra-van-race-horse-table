namespace JraVanRaceHorseTable
{
    public class Const
    {
        // レコード種別
        public class RECORD_KIND
        {
            public const string RACE = "RA";     // レース詳細
            public const string RACE_UMA = "SE"; // 馬毎レース情報
            public const string UMA = "UM";      // 競走馬マスタ
        }

        // JV-Linkステータス
        public enum JV_READ
        {
            EOL,               // ファイルリスト読み込み終了 
            SUCCESS,           // 正常読み込み
            EOF = -1,          // ファイルの区切れ
            ERR = -2,          // エラー
            DOWNLOAD_NOW = -3, // ダウンロード中
        }
    }
}
