namespace JraVanRaceHorseTable.Models
{
    public class RaceUma
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; } = null!;

        public required string RecordSpec { get; set; }          // レコード種別
        public required string DataKubun { get; set; }           // データ区分
        public required string MakeDate { get; set; }            // データ作成年月日
        public required string Wakuban { get; set; }             // 枠番
        public string? Umaban { get; set; }                      // 馬番
        public required string KettoNum { get; set; }            // 血統登録番号
        public required string Bamei { get; set; }               // 馬名
        public required string UmaKigoCD { get; set; }           // 馬記号コード
        public string? SexCD { get; set; }                       // 性別コード
        public required string HinsyuCD { get; set; }            // 品種コード
        public required string KeiroCD { get; set; }             // 毛色コード
        public string? Barei { get; set; }                       // 馬齢
        public required string TozaiCD { get; set; }             // 東西所属コード
        public required string ChokyosiCode { get; set; }        // 調教師コード
        public required string ChokyosiRyakusyo { get; set; }    // 調教師名略称
        public required string BanusiCode { get; set; }          // 馬主コード
        public string? BanusiName { get; set; }                  // 馬主名
        public required string Fukusyoku { get; set; }           // 服色標示
        public required string Reserved1 { get; set; }           // 予備
        public required string Futan { get; set; }               // 負担重量
        public required string FutanBefore { get; set; }         // 変更前負担重量
        public required string Blinker { get; set; }             // ブリンカー使用区分
        public required string Reserved2 { get; set; }           // 予備
        public string? KisyuCode { get; set; }                   // 騎手コード
        public required string KisyuCodeBefore { get; set; }     // 変更前騎手コード
        public required string KisyuRyakusyo { get; set; }       // 騎手名略称
        public required string KisyuRyakusyoBefore { get; set; } // 変更前騎手名略称
        public required string MinaraiCD { get; set; }           // 騎手見習コード
        public required string MinaraiCDBefore { get; set; }     // 変更前騎手見習コード
        public string? BaTaijyu { get; set; }                    // 馬体重
        public required string ZogenFugo { get; set; }           // 増減符号
        public required string ZogenSa { get; set; }             // 変更前騎手見習コード
        public string? IJyoCD { get; set; }                      // 異常区分コード
        public required string NyusenJyuni { get; set; }         // 入線順位
        public required string KakuteiJyuni { get; set; }        // 確定着順
        public required string DochakuKubun { get; set; }        // 同着区分
        public required string DochakuTosu { get; set; }         // 同着頭数
        public string? Time { get; set; }                        // 走破タイム
        public string? ChakusaCD { get; set; }                   // 着差コード
        public string? ChakusaCDP { get; set; }                  // +着差コード
        public string? ChakusaCDPP { get; set; }                 // ++着差コード
        public required string Jyuni1c { get; set; }             // 1コーナーでの順位
        public required string Jyuni2c { get; set; }             // 2コーナーでの順位
        public required string Jyuni3c { get; set; }             // 3コーナーでの順位
        public required string Jyuni4c { get; set; }             // 4コーナーでの順位
        public string? Odds { get; set; }                        // 単勝オッズ
        public string? Ninki { get; set; }                       // 単勝人気順
        public string? Honsyokin { get; set; }                   // 獲得本賞金
        public string? Fukasyokin { get; set; }                  // 獲得付加賞金
        public required string Reserved3 { get; set; }           // 予備
        public required string Reserved4 { get; set; }           // 予備
        public required string HaronTimeL4 { get; set; }         // 後４ハロンタイム
        public required string HaronTimeL3 { get; set; }         // 後３ハロンタイム
        public string? KettoNum1 { get; set; }                   // 相手馬1血統登録番号
        public required string Bamei1 { get; set; }              // 相手馬1馬名
        public string? KettoNum2 { get; set; }                   // 相手馬2血統登録番号
        public required string Bamei2 { get; set; }              // 相手馬2馬名
        public string? KettoNum3 { get; set; }                   // 相手馬3血統登録番号
        public required string Bamei3 { get; set; }              // 相手馬3馬名
        public required string TimeDiff { get; set; }            // タイム差
        public string? RecordUpKubun { get; set; }               // レコード更新区分
        public required string DMKubun { get; set; }             // マイニング区分
        public required string DMTime { get; set; }              // マイニング予想走破タイム
        public required string DMGosaP { get; set; }             // 予測誤差(信頼度)＋
        public required string DMGosaM { get; set; }             // 予測誤差(信頼度)－
        public required string DMJyuni { get; set; }             // マイニング予想順位
        public required string KyakusituKubun { get; set; }      // 今回レース脚質判定
    }
}
