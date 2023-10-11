namespace JraVanRaceHorseTable.Models
{
    public class Uma
    {
        public int Id { get; set; }

        public required string RecordSpec { get; set; }               // レコード種別
        public required string DataKubun { get; set; }                // データ区分
        public required string MakeDate { get; set; }                 // データ作成年月日
        public required string KettoNum { get; set; }                 // 血統登録番号
        public required string DelKubun { get; set; }                 // 競走馬抹消区分
        public required string RegDate { get; set; }                  // 競走馬登録年月日
        public required string DelDate { get; set; }                  // 競走馬抹消年月日
        public required string BirthDate { get; set; }                // 生年月日
        public required string Bamei { get; set; }                    // 馬名
        public required string BameiKana { get; set; }                // 馬名半角カナ
        public required string BameiEng { get; set; }                 // 馬名欧字
        public required string ZaikyuFlag { get; set; }               // JRA施設在きゅうフラグ
        public required string Reserved { get; set; }                 // 予備
        public required string UmaKigoCD { get; set; }                // 馬記号コード
        public required string SexCD { get; set; }                    // 性別コード
        public required string HinsyuCD { get; set; }                 // 品種コード
        public required string KeiroCD { get; set; }                  // 毛色コード
        public required string Ketto3InfoHansyokuNum1 { get; set; }   // 3代血統情報 繁殖登録番号1 父
        public required string Ketto3InfoBamei1 { get; set; }         // 3代血統情報 馬名1 父
        public required string Ketto3InfoHansyokuNum2 { get; set; }   // 3代血統情報 繁殖登録番号2 母
        public required string Ketto3InfoBamei2 { get; set; }         // 3代血統情報 馬名2 母
        public required string Ketto3InfoHansyokuNum3 { get; set; }   // 3代血統情報 繁殖登録番号3 父父
        public required string Ketto3InfoBamei3 { get; set; }         // 3代血統情報 馬名3 父父
        public required string Ketto3InfoHansyokuNum4 { get; set; }   // 3代血統情報 繁殖登録番号4 父母
        public required string Ketto3InfoBamei4 { get; set; }         // 3代血統情報 馬名4 父母
        public required string Ketto3InfoHansyokuNum5 { get; set; }   // 3代血統情報 繁殖登録番号5 母父
        public required string Ketto3InfoBamei5 { get; set; }         // 3代血統情報 馬名5 母父
        public required string Ketto3InfoHansyokuNum6 { get; set; }   // 3代血統情報 繁殖登録番号6 母母
        public required string Ketto3InfoBamei6 { get; set; }         // 3代血統情報 馬名6 母母
        public required string Ketto3InfoHansyokuNum7 { get; set; }   // 3代血統情報 繁殖登録番号7 父父父
        public required string Ketto3InfoBamei7 { get; set; }         // 3代血統情報 馬名7 父父父
        public required string Ketto3InfoHansyokuNum8 { get; set; }   // 3代血統情報 繁殖登録番号8 父父母
        public required string Ketto3InfoBamei8 { get; set; }         // 3代血統情報 馬名8 父父母
        public required string Ketto3InfoHansyokuNum9 { get; set; }   // 3代血統情報 繁殖登録番号9 父母父
        public required string Ketto3InfoBamei9 { get; set; }         // 3代血統情報 馬名9 父母父
        public required string Ketto3InfoHansyokuNum10 { get; set; }  // 3代血統情報 繁殖登録番号10 父母母
        public required string Ketto3InfoBamei10 { get; set; }        // 3代血統情報 馬名10 父母母
        public required string Ketto3InfoHansyokuNum11 { get; set; }  // 3代血統情報 繁殖登録番号11 母父父
        public required string Ketto3InfoBamei11 { get; set; }        // 3代血統情報 馬名11 母父父
        public required string Ketto3InfoHansyokuNum12 { get; set; }  // 3代血統情報 繁殖登録番号12 母父母
        public required string Ketto3InfoBamei12 { get; set; }        // 3代血統情報 馬名12 母父母
        public required string Ketto3InfoHansyokuNum13 { get; set; }  // 3代血統情報 繁殖登録番号13 母母父
        public required string Ketto3InfoBamei13 { get; set; }        // 3代血統情報 馬名13 母母父
        public required string Ketto3InfoHansyokuNum14 { get; set; }  // 3代血統情報 繁殖登録番号14 母母母
        public required string Ketto3InfoBamei14 { get; set; }        // 3代血統情報 馬名14 母母母
        public required string TozaiCD { get; set; }                  // 東西所属コード
        public required string ChokyosiCode { get; set; }             // 調教師コード
        public required string ChokyosiRyakusyo { get; set; }         // 調教師名略称
        public required string Syotai { get; set; }                   // 招待地域名
        public required string BreederCode { get; set; }              // 生産者コード
        public required string BreederName { get; set; }              // 生産者名
        public required string SanchiName { get; set; }               // 産地名
        public required string BanusiCode { get; set; }               // 馬主コード
        public required string BanusiName { get; set; }               // 馬主名
        public required string RuikeiHonsyoHeiti { get; set; }        // 平地本賞金累計
        public required string RuikeiHonsyoSyogai { get; set; }       // 障害本賞金累計
        public required string RuikeiFukaHeichi { get; set; }         // 平地付加賞金累計
        public required string RuikeiFukaSyogai { get; set; }         // 障害付加賞金累計
        public required string RuikeiSyutokuHeichi { get; set; }      // 平地収得賞金累計
        public required string RuikeiSyutokuSyogai { get; set; }      // 障害収得賞金累計
        public required string SogoChakukaisu1 { get; set; }          // 総合着回数（中央＋地方＋海外)1着
        public required string SogoChakukaisu2 { get; set; }          // 総合着回数2着
        public required string SogoChakukaisu3 { get; set; }          // 総合着回数3着
        public required string SogoChakukaisu4 { get; set; }          // 総合着回数4着
        public required string SogoChakukaisu5 { get; set; }          // 総合着回数5着
        public required string SogoChakukaisu6 { get; set; }          // 総合着回数6着以下 
        public required string ChuoChakukaisu1 { get; set; }          // 中央合計着回数（中央のみ)1着
        public required string ChuoChakukaisu2 { get; set; }          // 中央合計着回数2着
        public required string ChuoChakukaisu3 { get; set; }          // 中央合計着回数3着
        public required string ChuoChakukaisu4 { get; set; }          // 中央合計着回数4着
        public required string ChuoChakukaisu5 { get; set; }          // 中央合計着回数5着
        public required string ChuoChakukaisu6 { get; set; }          // 中央合計着回数6着以下

        public required string Ba1Chakukaisu1 { get; set; }           // 馬場別着回数 芝直・着回数1着
        public required string Ba1Chakukaisu2 { get; set; }           // 馬場別着回数 芝直・着回数2着
        public required string Ba1Chakukaisu3 { get; set; }           // 馬場別着回数 芝直・着回数3着
        public required string Ba1Chakukaisu4 { get; set; }           // 馬場別着回数 芝直・着回数4着
        public required string Ba1Chakukaisu5 { get; set; }           // 馬場別着回数 芝直・着回数5着
        public required string Ba1Chakukaisu6 { get; set; }           // 馬場別着回数 芝直・着回数6着以下
        public required string Ba2Chakukaisu1 { get; set; }           // 馬場別着回数 芝右・着回数1着
        public required string Ba2Chakukaisu2 { get; set; }           // 馬場別着回数 芝右・着回数2着
        public required string Ba2Chakukaisu3 { get; set; }           // 馬場別着回数 芝右・着回数3着
        public required string Ba2Chakukaisu4 { get; set; }           // 馬場別着回数 芝右・着回数4着
        public required string Ba2Chakukaisu5 { get; set; }           // 馬場別着回数 芝右・着回数5着
        public required string Ba2Chakukaisu6 { get; set; }           // 馬場別着回数 芝右・着回数6着以下
        public required string Ba3Chakukaisu1 { get; set; }           // 馬場別着回数 芝左・着回数1着
        public required string Ba3Chakukaisu2 { get; set; }           // 馬場別着回数 芝左・着回数2着
        public required string Ba3Chakukaisu3 { get; set; }           // 馬場別着回数 芝左・着回数3着
        public required string Ba3Chakukaisu4 { get; set; }           // 馬場別着回数 芝左・着回数4着
        public required string Ba3Chakukaisu5 { get; set; }           // 馬場別着回数 芝左・着回数5着
        public required string Ba3Chakukaisu6 { get; set; }           // 馬場別着回数 芝左・着回数6着以下
        public required string Ba4Chakukaisu1 { get; set; }           // 馬場別着回数 ダ直・着回数1着
        public required string Ba4Chakukaisu2 { get; set; }           // 馬場別着回数 ダ直・着回数2着
        public required string Ba4Chakukaisu3 { get; set; }           // 馬場別着回数 ダ直・着回数3着
        public required string Ba4Chakukaisu4 { get; set; }           // 馬場別着回数 ダ直・着回数4着
        public required string Ba4Chakukaisu5 { get; set; }           // 馬場別着回数 ダ直・着回数5着
        public required string Ba4Chakukaisu6 { get; set; }           // 馬場別着回数 ダ直・着回数6着以下
        public required string Ba5Chakukaisu1 { get; set; }           // 馬場別着回数 ダ右・着回数1着
        public required string Ba5Chakukaisu2 { get; set; }           // 馬場別着回数 ダ右・着回数2着
        public required string Ba5Chakukaisu3 { get; set; }           // 馬場別着回数 ダ右・着回数3着
        public required string Ba5Chakukaisu4 { get; set; }           // 馬場別着回数 ダ右・着回数4着
        public required string Ba5Chakukaisu5 { get; set; }           // 馬場別着回数 ダ右・着回数5着
        public required string Ba5Chakukaisu6 { get; set; }           // 馬場別着回数 ダ右・着回数6着以下
        public required string Ba6Chakukaisu1 { get; set; }           // 馬場別着回数 ダ左・着回数1着
        public required string Ba6Chakukaisu2 { get; set; }           // 馬場別着回数 ダ左・着回数2着
        public required string Ba6Chakukaisu3 { get; set; }           // 馬場別着回数 ダ左・着回数3着
        public required string Ba6Chakukaisu4 { get; set; }           // 馬場別着回数 ダ左・着回数4着
        public required string Ba6Chakukaisu5 { get; set; }           // 馬場別着回数 ダ左・着回数5着
        public required string Ba6Chakukaisu6 { get; set; }           // 馬場別着回数 ダ左・着回数6着以下
        public required string Ba7Chakukaisu1 { get; set; }           // 馬場別着回数 障害・着回数1着
        public required string Ba7Chakukaisu2 { get; set; }           // 馬場別着回数 障害・着回数2着
        public required string Ba7Chakukaisu3 { get; set; }           // 馬場別着回数 障害・着回数3着
        public required string Ba7Chakukaisu4 { get; set; }           // 馬場別着回数 障害・着回数4着
        public required string Ba7Chakukaisu5 { get; set; }           // 馬場別着回数 障害・着回数5着
        public required string Ba7Chakukaisu6 { get; set; }           // 馬場別着回数 障害・着回数6着以下

        public required string Jyotai1Chakukaisu1 { get; set; }       // 馬場状態別着回数 芝良・着回数1着
        public required string Jyotai1Chakukaisu2 { get; set; }       // 馬場状態別着回数 芝良・着回数2着
        public required string Jyotai1Chakukaisu3 { get; set; }       // 馬場状態別着回数 芝良・着回数3着
        public required string Jyotai1Chakukaisu4 { get; set; }       // 馬場状態別着回数 芝良・着回数4着
        public required string Jyotai1Chakukaisu5 { get; set; }       // 馬場状態別着回数 芝良・着回数5着
        public required string Jyotai1Chakukaisu6 { get; set; }       // 馬場状態別着回数 芝良・着回数6着以下
        public required string Jyotai2Chakukaisu1 { get; set; }       // 馬場状態別着回数 芝稍・着回数1着
        public required string Jyotai2Chakukaisu2 { get; set; }       // 馬場状態別着回数 芝稍・着回数2着
        public required string Jyotai2Chakukaisu3 { get; set; }       // 馬場状態別着回数 芝稍・着回数3着
        public required string Jyotai2Chakukaisu4 { get; set; }       // 馬場状態別着回数 芝稍・着回数4着
        public required string Jyotai2Chakukaisu5 { get; set; }       // 馬場状態別着回数 芝稍・着回数5着
        public required string Jyotai2Chakukaisu6 { get; set; }       // 馬場状態別着回数 芝稍・着回数6着以下
        public required string Jyotai3Chakukaisu1 { get; set; }       // 馬場状態別着回数 芝重・着回数1着
        public required string Jyotai3Chakukaisu2 { get; set; }       // 馬場状態別着回数 芝重・着回数2着
        public required string Jyotai3Chakukaisu3 { get; set; }       // 馬場状態別着回数 芝重・着回数3着
        public required string Jyotai3Chakukaisu4 { get; set; }       // 馬場状態別着回数 芝重・着回数4着
        public required string Jyotai3Chakukaisu5 { get; set; }       // 馬場状態別着回数 芝重・着回数5着
        public required string Jyotai3Chakukaisu6 { get; set; }       // 馬場状態別着回数 芝重・着回数6着以下
        public required string Jyotai4Chakukaisu1 { get; set; }       // 馬場状態別着回数 芝不・着回数1着
        public required string Jyotai4Chakukaisu2 { get; set; }       // 馬場状態別着回数 芝不・着回数2着
        public required string Jyotai4Chakukaisu3 { get; set; }       // 馬場状態別着回数 芝不・着回数3着
        public required string Jyotai4Chakukaisu4 { get; set; }       // 馬場状態別着回数 芝不・着回数4着
        public required string Jyotai4Chakukaisu5 { get; set; }       // 馬場状態別着回数 芝不・着回数5着
        public required string Jyotai4Chakukaisu6 { get; set; }       // 馬場状態別着回数 芝不・着回数6着
        public required string Jyotai5Chakukaisu1 { get; set; }       // 馬場状態別着回数 ダ稍・着回数1着
        public required string Jyotai5Chakukaisu2 { get; set; }       // 馬場状態別着回数 ダ稍・着回数2着
        public required string Jyotai5Chakukaisu3 { get; set; }       // 馬場状態別着回数 ダ稍・着回数3着
        public required string Jyotai5Chakukaisu4 { get; set; }       // 馬場状態別着回数 ダ稍・着回数4着
        public required string Jyotai5Chakukaisu5 { get; set; }       // 馬場状態別着回数 ダ稍・着回数5着
        public required string Jyotai5Chakukaisu6 { get; set; }       // 馬場状態別着回数 ダ稍・着回数6着以下
        public required string Jyotai6Chakukaisu1 { get; set; }       // 馬場状態別着回数 ダ重・着回数1着
        public required string Jyotai6Chakukaisu2 { get; set; }       // 馬場状態別着回数 ダ重・着回数2着
        public required string Jyotai6Chakukaisu3 { get; set; }       // 馬場状態別着回数 ダ重・着回数3着
        public required string Jyotai6Chakukaisu4 { get; set; }       // 馬場状態別着回数 ダ重・着回数4着
        public required string Jyotai6Chakukaisu5 { get; set; }       // 馬場状態別着回数 ダ重・着回数5着
        public required string Jyotai6Chakukaisu6 { get; set; }       // 馬場状態別着回数 ダ重・着回数6着以下
        public required string Jyotai7Chakukaisu1 { get; set; }       // 馬場状態別着回数 ダ不・着回数1着
        public required string Jyotai7Chakukaisu2 { get; set; }       // 馬場状態別着回数 ダ不・着回数2着
        public required string Jyotai7Chakukaisu3 { get; set; }       // 馬場状態別着回数 ダ不・着回数3着
        public required string Jyotai7Chakukaisu4 { get; set; }       // 馬場状態別着回数 ダ不・着回数4着
        public required string Jyotai7Chakukaisu5 { get; set; }       // 馬場状態別着回数 ダ不・着回数5着
        public required string Jyotai7Chakukaisu6 { get; set; }       // 馬場状態別着回数 ダ不・着回数6着以下
        public required string Jyotai8Chakukaisu1 { get; set; }       // 馬場状態別着回数 ダ良・着回数1着
        public required string Jyotai8Chakukaisu2 { get; set; }       // 馬場状態別着回数 ダ良・着回数2着
        public required string Jyotai8Chakukaisu3 { get; set; }       // 馬場状態別着回数 ダ良・着回数3着
        public required string Jyotai8Chakukaisu4 { get; set; }       // 馬場状態別着回数 ダ良・着回数4着
        public required string Jyotai8Chakukaisu5 { get; set; }       // 馬場状態別着回数 ダ良・着回数5着
        public required string Jyotai8Chakukaisu6 { get; set; }       // 馬場状態別着回数 ダ良・着回数6着以下
        public required string Jyotai9Chakukaisu1 { get; set; }       // 馬場状態別着回数 障良・着回数1着
        public required string Jyotai9Chakukaisu2 { get; set; }       // 馬場状態別着回数 障良・着回数2着
        public required string Jyotai9Chakukaisu3 { get; set; }       // 馬場状態別着回数 障良・着回数3着
        public required string Jyotai9Chakukaisu4 { get; set; }       // 馬場状態別着回数 障良・着回数4着
        public required string Jyotai9Chakukaisu5 { get; set; }       // 馬場状態別着回数 障良・着回数5着
        public required string Jyotai9Chakukaisu6 { get; set; }       // 馬場状態別着回数 障良・着回数6着以下
        public required string Jyotai10Chakukaisu1 { get; set; }      // 馬場状態別着回数 障稍・着回数1着
        public required string Jyotai10Chakukaisu2 { get; set; }      // 馬場状態別着回数 障稍・着回数2着
        public required string Jyotai10Chakukaisu3 { get; set; }      // 馬場状態別着回数 障稍・着回数3着
        public required string Jyotai10Chakukaisu4 { get; set; }      // 馬場状態別着回数 障稍・着回数4着
        public required string Jyotai10Chakukaisu5 { get; set; }      // 馬場状態別着回数 障稍・着回数5着
        public required string Jyotai10Chakukaisu6 { get; set; }      // 馬場状態別着回数 障稍・着回数6着以下
        public required string Jyotai11Chakukaisu1 { get; set; }      // 馬場状態別着回数 障重・着回数1着
        public required string Jyotai11Chakukaisu2 { get; set; }      // 馬場状態別着回数 障重・着回数2着
        public required string Jyotai11Chakukaisu3 { get; set; }      // 馬場状態別着回数 障重・着回数3着
        public required string Jyotai11Chakukaisu4 { get; set; }      // 馬場状態別着回数 障重・着回数4着
        public required string Jyotai11Chakukaisu5 { get; set; }      // 馬場状態別着回数 障重・着回数5着
        public required string Jyotai11Chakukaisu6 { get; set; }      // 馬場状態別着回数 障重・着回数6着以下
        public required string Jyotai12Chakukaisu1 { get; set; }      // 馬場状態別着回数 障不・着回数1着
        public required string Jyotai12Chakukaisu2 { get; set; }      // 馬場状態別着回数 障不・着回数2着
        public required string Jyotai12Chakukaisu3 { get; set; }      // 馬場状態別着回数 障不・着回数3着
        public required string Jyotai12Chakukaisu4 { get; set; }      // 馬場状態別着回数 障不・着回数4着
        public required string Jyotai12Chakukaisu5 { get; set; }      // 馬場状態別着回数 障不・着回数5着
        public required string Jyotai12Chakukaisu6 { get; set; }      // 馬場状態別着回数 障不・着回数6着以下

        public required string Kyori1Chakukaisu1 { get; set; }        // 距離別着回数 芝16下・着回数1着
        public required string Kyori1Chakukaisu2 { get; set; }        // 距離別着回数 芝16下・着回数2着
        public required string Kyori1Chakukaisu3 { get; set; }        // 距離別着回数 芝16下・着回数3着
        public required string Kyori1Chakukaisu4 { get; set; }        // 距離別着回数 芝16下・着回数4着
        public required string Kyori1Chakukaisu5 { get; set; }        // 距離別着回数 芝16下・着回数5着
        public required string Kyori1Chakukaisu6 { get; set; }        // 距離別着回数 芝16下・着回数6着以下
        public required string Kyori2Chakukaisu1 { get; set; }        // 距離別着回数 芝22下・着回数1着
        public required string Kyori2Chakukaisu2 { get; set; }        // 距離別着回数 芝22下・着回数2着
        public required string Kyori2Chakukaisu3 { get; set; }        // 距離別着回数 芝22下・着回数3着
        public required string Kyori2Chakukaisu4 { get; set; }        // 距離別着回数 芝22下・着回数4着
        public required string Kyori2Chakukaisu5 { get; set; }        // 距離別着回数 芝22下・着回数5着
        public required string Kyori2Chakukaisu6 { get; set; }        // 距離別着回数 芝22下・着回数6着以下
        public required string Kyori3Chakukaisu1 { get; set; }        // 距離別着回数 芝22超・着回数1着
        public required string Kyori3Chakukaisu2 { get; set; }        // 距離別着回数 芝22超・着回数2着
        public required string Kyori3Chakukaisu3 { get; set; }        // 距離別着回数 芝22超・着回数3着
        public required string Kyori3Chakukaisu4 { get; set; }        // 距離別着回数 芝22超・着回数4着
        public required string Kyori3Chakukaisu5 { get; set; }        // 距離別着回数 芝22超・着回数5着
        public required string Kyori3Chakukaisu6 { get; set; }        // 距離別着回数 芝22超・着回数6着以下
        public required string Kyori4Chakukaisu1 { get; set; }        // 距離別着回数 ダ16下・着回数1着
        public required string Kyori4Chakukaisu2 { get; set; }        // 距離別着回数 ダ16下・着回数2着
        public required string Kyori4Chakukaisu3 { get; set; }        // 距離別着回数 ダ16下・着回数3着
        public required string Kyori4Chakukaisu4 { get; set; }        // 距離別着回数 ダ16下・着回数4着
        public required string Kyori4Chakukaisu5 { get; set; }        // 距離別着回数 ダ16下・着回数5着
        public required string Kyori4Chakukaisu6 { get; set; }        // 距離別着回数 ダ16下・着回数6着以下
        public required string Kyori5Chakukaisu1 { get; set; }        // 距離別着回数 ダ22下・着回数1着
        public required string Kyori5Chakukaisu2 { get; set; }        // 距離別着回数 ダ22下・着回数2着
        public required string Kyori5Chakukaisu3 { get; set; }        // 距離別着回数 ダ22下・着回数3着
        public required string Kyori5Chakukaisu4 { get; set; }        // 距離別着回数 ダ22下・着回数4着
        public required string Kyori5Chakukaisu5 { get; set; }        // 距離別着回数 ダ22下・着回数5着
        public required string Kyori5Chakukaisu6 { get; set; }        // 距離別着回数 ダ22下・着回数6着以下
        public required string Kyori6Chakukaisu1 { get; set; }        // 距離別着回数 ダ22超・着回数1着
        public required string Kyori6Chakukaisu2 { get; set; }        // 距離別着回数 ダ22超・着回数2着
        public required string Kyori6Chakukaisu3 { get; set; }        // 距離別着回数 ダ22超・着回数3着
        public required string Kyori6Chakukaisu4 { get; set; }        // 距離別着回数 ダ22超・着回数4着
        public required string Kyori6Chakukaisu5 { get; set; }        // 距離別着回数 ダ22超・着回数5着
        public required string Kyori6Chakukaisu6 { get; set; }        // 距離別着回数 ダ22超・着回数6着以下

        public required string Kyakusitu1 { get; set; }               // 脚質傾向1 逃げ
        public required string Kyakusitu2 { get; set; }               // 脚質傾向2 先行
        public required string Kyakusitu3 { get; set; }               // 脚質傾向3 差し
        public required string Kyakusitu4 { get; set; }               // 脚質傾向4 追込
        public required string RaceCount { get; set; }                // 登録レース数
    }
}
