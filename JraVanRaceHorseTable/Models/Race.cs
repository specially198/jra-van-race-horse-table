namespace JraVanRaceHorseTable.Models
{
    public class Race
    {
        public int Id { get; set; }

        public required string RecordSpec { get; set; }          // レコード種別
        public required string DataKubun { get; set; }           // データ区分
        public required string MakeDate { get; set; }            // データ作成年月日
        public required string Year { get; set; }                // 開催年
        public required string MonthDay { get; set; }            // 開催月日
        public required string JyoCD { get; set; }               // 競馬場コード
        public required string Kaiji { get; set; }               // 開催回[第N回]
        public required string Nichiji { get; set; }             // 開催日目[N日目]
        public string? RaceNum { get; set; }                     // レース番号
        public required string YoubiCD { get; set; }             // 曜日コード
        public required string TokuNum { get; set; }             // 特別競走番号
        public required string Hondai { get; set; }              // 競走名本題
        public required string Fukudai { get; set; }             // 競走名副題
        public required string Kakko { get; set; }               // 競走名カッコ内
        public string? HondaiEng { get; set; }                   // 競走名本題欧字
        public required string FukudaiEng { get; set; }          // 競走名副題欧字
        public required string KakkoEng { get; set; }            // 競走名カッコ内欧字
        public required string Ryakusyo10 { get; set; }          // 競走名略称１０字
        public required string Ryakusyo6 { get; set; }           // 競走名略称６字
        public required string Ryakusyo3 { get; set; }           // 競走名略称３字
        public required string Kubun { get; set; }               // 競走名区分
        public required string Nkai { get; set; }                // 重賞回次[第N回]
        public required string GradeCD { get; set; }             // グレードコード
        public required string GradeCDBefore { get; set; }       // 変更前グレードコード
        public required string SyubetuCD { get; set; }           // 競走種別コード
        public string? KigoCD { get; set; }                      // 競走記号コード
        public required string JyuryoCD { get; set; }            // 重量種別コード
        public required string JyokenCD1 { get; set; }           // 競走条件コード1
        public required string JyokenCD2 { get; set; }           // 競走条件コード2
        public required string JyokenCD3 { get; set; }           // 競走条件コード3
        public required string JyokenCD4 { get; set; }           // 競走条件コード4
        public required string JyokenCD5 { get; set; }           // 競走条件コード5
        public required string JyokenName { get; set; }          // 競走条件名称
        public required string Kyori { get; set; }               // 距離
        public required string KyoriBefore { get; set; }         // 変更前距離
        public required string TrackCD { get; set; }             // トラックコード
        public required string TrackCDBefore { get; set; }       // 変更前トラックコード
        public required string CourseKubunCD { get; set; }       // コース区分
        public required string CourseKubunCDBefore { get; set; } // 変更前コース区分
        public required string Honsyokin1 { get; set; }          // 本賞金1
        public required string Honsyokin2 { get; set; }          // 本賞金2
        public required string Honsyokin3 { get; set; }          // 本賞金3
        public required string Honsyokin4 { get; set; }          // 本賞金4
        public required string Honsyokin5 { get; set; }          // 本賞金5
        public required string Honsyokin6 { get; set; }          // 本賞金6
        public required string Honsyokin7 { get; set; }          // 本賞金7
        public required string HonsyokinBefore1 { get; set; }    // 変更前本賞金1
        public required string HonsyokinBefore2 { get; set; }    // 変更前本賞金2
        public required string HonsyokinBefore3 { get; set; }    // 変更前本賞金3
        public required string HonsyokinBefore4 { get; set; }    // 変更前本賞金4
        public required string HonsyokinBefore5 { get; set; }    // 変更前本賞金5
        public required string Fukasyokin1 { get; set; }         // 付加賞金1
        public required string Fukasyokin2 { get; set; }         // 付加賞金2
        public required string Fukasyokin3 { get; set; }         // 付加賞金3
        public required string Fukasyokin4 { get; set; }         // 付加賞金4
        public required string Fukasyokin5 { get; set; }         // 付加賞金5
        public required string FukasyokinBefore1 { get; set; }   // 変更前付加賞金1
        public required string FukasyokinBefore2 { get; set; }   // 変更前付加賞金2
        public required string FukasyokinBefore3 { get; set; }   // 変更前付加賞金3
        public required string HassoTime { get; set; }           // 発走時刻
        public required string HassoTimeBefore { get; set; }     // 変更前発走時刻
        public string? TorokuTosu { get; set; }                  // 登録頭数
        public required string SyussoTosu { get; set; }          // 出走頭数
        public string? NyusenTosu { get; set; }                  // 入線頭数
        public required string TenkoCD { get; set; }             // 天候コード
        public required string SibaBabaCD { get; set; }          // 芝馬場状態コード
        public required string DirtBabaCD { get; set; }          // ダート馬場状態コード
        public required string LapTime1 { get; set; }            // ラップタイム1
        public required string LapTime2 { get; set; }            // ラップタイム2
        public required string LapTime3 { get; set; }            // ラップタイム3
        public required string LapTime4 { get; set; }            // ラップタイム4
        public required string LapTime5 { get; set; }            // ラップタイム5
        public required string LapTime6 { get; set; }            // ラップタイム6
        public required string LapTime7 { get; set; }            // ラップタイム7
        public required string LapTime8 { get; set; }            // ラップタイム8
        public required string LapTime9 { get; set; }            // ラップタイム9
        public required string LapTime10 { get; set; }           // ラップタイム10
        public required string LapTime11 { get; set; }           // ラップタイム11
        public required string LapTime12 { get; set; }           // ラップタイム12
        public required string LapTime13 { get; set; }           // ラップタイム13
        public required string LapTime14 { get; set; }           // ラップタイム14
        public required string LapTime15 { get; set; }           // ラップタイム15
        public required string LapTime16 { get; set; }           // ラップタイム16
        public required string LapTime17 { get; set; }           // ラップタイム17
        public required string LapTime18 { get; set; }           // ラップタイム18
        public required string LapTime19 { get; set; }           // ラップタイム19
        public required string LapTime20 { get; set; }           // ラップタイム20
        public required string LapTime21 { get; set; }           // ラップタイム21
        public required string LapTime22 { get; set; }           // ラップタイム22
        public required string LapTime23 { get; set; }           // ラップタイム23
        public required string LapTime24 { get; set; }           // ラップタイム24
        public required string LapTime25 { get; set; }           // ラップタイム25
        public required string SyogaiMileTime { get; set; }      // 障害マイルタイム
        public required string HaronTimeS3 { get; set; }         // 前３ハロンタイム
        public required string HaronTimeS4 { get; set; }         // 前４ハロンタイム
        public required string HaronTimeL3 { get; set; }         // 後３ハロンタイム
        public required string HaronTimeL4 { get; set; }         // 後４ハロンタイム
        public string? Corner1 { get; set; }                     // コーナー通過順1コーナー
        public string? Syukaisu1 { get; set; }                   // コーナー通過順1周回数
        public string? Jyuni1 { get; set; }                      // コーナー通過順1各通過順位
        public string? Corner2 { get; set; }                     // コーナー通過順2コーナー
        public string? Syukaisu2 { get; set; }                   // コーナー通過順2周回数
        public string? Jyuni2 { get; set; }                      // コーナー通過順2各通過順位
        public string? Corner3 { get; set; }                     // コーナー通過順3コーナー
        public string? Syukaisu3 { get; set; }                   // コーナー通過順3周回数
        public string? Jyuni3 { get; set; }                      // コーナー通過順3各通過順位
        public string? Corner4 { get; set; }                     // コーナー通過順4コーナー
        public string? Syukaisu4 { get; set; }                   // コーナー通過順4周回数
        public string? Jyuni4 { get; set; }                      // コーナー通過順4各通過順位
        public required string RecordUpKubun { get; set; }       // レコード更新区分

        public List<RaceUma> RaceUmas { get; } = new();
    }
}
