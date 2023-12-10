using JraVanRaceHorseTable.Models;
using Microsoft.EntityFrameworkCore;
using static JVData_Struct;

namespace JraVanRaceHorseTable.Services
{
    public interface IUmaService
    {
        void InsertOrUpdate(JV_UM_UMA structUma);
        void Add(JV_UM_UMA structUma);
        List<Uma> GetList(List<string> kettoNumList);
        Uma? GetUma(string kettoNum);
        void Update(Uma uma, JV_UM_UMA structUma);
        void DeleteAll();
    }

    public class UmaService : IUmaService
    {
        private readonly ApplicationDbContext _db;

        public UmaService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InsertOrUpdate(JV_UM_UMA structUma)
        {
            var uma = GetUma(structUma.KettoNum);

            if (uma == null)
            {
                Add(structUma);
            }
            else
            {
                Update(uma, structUma);
            }
        }

        public void Add(JV_UM_UMA structUma)
        {
            var head = structUma.head;

            var uma = new Uma
            {
                RecordSpec = head.RecordSpec,
                DataKubun = head.DataKubun,
                MakeDate = head.MakeDate.Year + head.MakeDate.Month + head.MakeDate.Day,
                KettoNum = structUma.KettoNum,
                DelKubun = structUma.DelKubun,
                RegDate = structUma.RegDate.Year + structUma.RegDate.Month + structUma.RegDate.Day,
                DelDate = structUma.DelDate.Year + structUma.DelDate.Month + structUma.DelDate.Day,
                BirthDate = structUma.BirthDate.Year + structUma.BirthDate.Month + structUma.BirthDate.Day,
                Bamei = structUma.Bamei,
                BameiKana = structUma.BameiKana,
                BameiEng = structUma.BameiEng,
                ZaikyuFlag = structUma.ZaikyuFlag,
                Reserved = structUma.Reserved,
                UmaKigoCD = structUma.UmaKigoCD,
                SexCD = structUma.SexCD,
                HinsyuCD = structUma.HinsyuCD,
                KeiroCD = structUma.KeiroCD,
                Ketto3InfoHansyokuNum1 = structUma.Ketto3Info[0].HansyokuNum,
                Ketto3InfoBamei1 = structUma.Ketto3Info[0].Bamei,
                Ketto3InfoHansyokuNum2 = structUma.Ketto3Info[1].HansyokuNum,
                Ketto3InfoBamei2 = structUma.Ketto3Info[1].Bamei,
                Ketto3InfoHansyokuNum3 = structUma.Ketto3Info[2].HansyokuNum,
                Ketto3InfoBamei3 = structUma.Ketto3Info[2].Bamei,
                Ketto3InfoHansyokuNum4 = structUma.Ketto3Info[3].HansyokuNum,
                Ketto3InfoBamei4 = structUma.Ketto3Info[3].Bamei,
                Ketto3InfoHansyokuNum5 = structUma.Ketto3Info[4].HansyokuNum,
                Ketto3InfoBamei5 = structUma.Ketto3Info[4].Bamei,
                Ketto3InfoHansyokuNum6 = structUma.Ketto3Info[5].HansyokuNum,
                Ketto3InfoBamei6 = structUma.Ketto3Info[5].Bamei,
                Ketto3InfoHansyokuNum7 = structUma.Ketto3Info[6].HansyokuNum,
                Ketto3InfoBamei7 = structUma.Ketto3Info[6].Bamei,
                Ketto3InfoHansyokuNum8 = structUma.Ketto3Info[7].HansyokuNum,
                Ketto3InfoBamei8 = structUma.Ketto3Info[7].Bamei,
                Ketto3InfoHansyokuNum9 = structUma.Ketto3Info[8].HansyokuNum,
                Ketto3InfoBamei9 = structUma.Ketto3Info[8].Bamei,
                Ketto3InfoHansyokuNum10 = structUma.Ketto3Info[9].HansyokuNum,
                Ketto3InfoBamei10 = structUma.Ketto3Info[9].Bamei,
                Ketto3InfoHansyokuNum11 = structUma.Ketto3Info[10].HansyokuNum,
                Ketto3InfoBamei11 = structUma.Ketto3Info[10].Bamei,
                Ketto3InfoHansyokuNum12 = structUma.Ketto3Info[11].HansyokuNum,
                Ketto3InfoBamei12 = structUma.Ketto3Info[11].Bamei,
                Ketto3InfoHansyokuNum13 = structUma.Ketto3Info[12].HansyokuNum,
                Ketto3InfoBamei13 = structUma.Ketto3Info[12].Bamei,
                Ketto3InfoHansyokuNum14 = structUma.Ketto3Info[13].HansyokuNum,
                Ketto3InfoBamei14 = structUma.Ketto3Info[13].Bamei,
                TozaiCD = structUma.TozaiCD,
                ChokyosiCode = structUma.ChokyosiCode,
                ChokyosiRyakusyo = structUma.ChokyosiRyakusyo,
                Syotai = structUma.Syotai,
                BreederCode = structUma.BreederCode,
                BreederName = structUma.BreederName,
                SanchiName = structUma.SanchiName,
                BanusiCode = structUma.BanusiCode,
                BanusiName = structUma.BanusiName,
                RuikeiHonsyoHeiti = structUma.RuikeiHonsyoHeiti,
                RuikeiHonsyoSyogai = structUma.RuikeiHonsyoSyogai,
                RuikeiFukaHeichi = structUma.RuikeiFukaHeichi,
                RuikeiFukaSyogai = structUma.RuikeiFukaSyogai,
                RuikeiSyutokuHeichi = structUma.RuikeiSyutokuHeichi,
                RuikeiSyutokuSyogai = structUma.RuikeiSyutokuSyogai,
                SogoChakukaisu1 = structUma.ChakuSogo.ChakuKaisu[0],
                SogoChakukaisu2 = structUma.ChakuSogo.ChakuKaisu[1],
                SogoChakukaisu3 = structUma.ChakuSogo.ChakuKaisu[2],
                SogoChakukaisu4 = structUma.ChakuSogo.ChakuKaisu[3],
                SogoChakukaisu5 = structUma.ChakuSogo.ChakuKaisu[4],
                SogoChakukaisu6 = structUma.ChakuSogo.ChakuKaisu[5],
                ChuoChakukaisu1 = structUma.ChakuChuo.ChakuKaisu[0],
                ChuoChakukaisu2 = structUma.ChakuChuo.ChakuKaisu[1],
                ChuoChakukaisu3 = structUma.ChakuChuo.ChakuKaisu[2],
                ChuoChakukaisu4 = structUma.ChakuChuo.ChakuKaisu[3],
                ChuoChakukaisu5 = structUma.ChakuChuo.ChakuKaisu[4],
                ChuoChakukaisu6 = structUma.ChakuChuo.ChakuKaisu[5],
                Ba1Chakukaisu1 = structUma.ChakuKaisuBa[0].ChakuKaisu[0],
                Ba1Chakukaisu2 = structUma.ChakuKaisuBa[0].ChakuKaisu[1],
                Ba1Chakukaisu3 = structUma.ChakuKaisuBa[0].ChakuKaisu[2],
                Ba1Chakukaisu4 = structUma.ChakuKaisuBa[0].ChakuKaisu[3],
                Ba1Chakukaisu5 = structUma.ChakuKaisuBa[0].ChakuKaisu[4],
                Ba1Chakukaisu6 = structUma.ChakuKaisuBa[0].ChakuKaisu[5],
                Ba2Chakukaisu1 = structUma.ChakuKaisuBa[1].ChakuKaisu[0],
                Ba2Chakukaisu2 = structUma.ChakuKaisuBa[1].ChakuKaisu[1],
                Ba2Chakukaisu3 = structUma.ChakuKaisuBa[1].ChakuKaisu[2],
                Ba2Chakukaisu4 = structUma.ChakuKaisuBa[1].ChakuKaisu[3],
                Ba2Chakukaisu5 = structUma.ChakuKaisuBa[1].ChakuKaisu[4],
                Ba2Chakukaisu6 = structUma.ChakuKaisuBa[1].ChakuKaisu[5],
                Ba3Chakukaisu1 = structUma.ChakuKaisuBa[2].ChakuKaisu[0],
                Ba3Chakukaisu2 = structUma.ChakuKaisuBa[2].ChakuKaisu[1],
                Ba3Chakukaisu3 = structUma.ChakuKaisuBa[2].ChakuKaisu[2],
                Ba3Chakukaisu4 = structUma.ChakuKaisuBa[2].ChakuKaisu[3],
                Ba3Chakukaisu5 = structUma.ChakuKaisuBa[2].ChakuKaisu[4],
                Ba3Chakukaisu6 = structUma.ChakuKaisuBa[2].ChakuKaisu[5],
                Ba4Chakukaisu1 = structUma.ChakuKaisuBa[3].ChakuKaisu[0],
                Ba4Chakukaisu2 = structUma.ChakuKaisuBa[3].ChakuKaisu[1],
                Ba4Chakukaisu3 = structUma.ChakuKaisuBa[3].ChakuKaisu[2],
                Ba4Chakukaisu4 = structUma.ChakuKaisuBa[3].ChakuKaisu[3],
                Ba4Chakukaisu5 = structUma.ChakuKaisuBa[3].ChakuKaisu[4],
                Ba4Chakukaisu6 = structUma.ChakuKaisuBa[3].ChakuKaisu[5],
                Ba5Chakukaisu1 = structUma.ChakuKaisuBa[4].ChakuKaisu[0],
                Ba5Chakukaisu2 = structUma.ChakuKaisuBa[4].ChakuKaisu[1],
                Ba5Chakukaisu3 = structUma.ChakuKaisuBa[4].ChakuKaisu[2],
                Ba5Chakukaisu4 = structUma.ChakuKaisuBa[4].ChakuKaisu[3],
                Ba5Chakukaisu5 = structUma.ChakuKaisuBa[4].ChakuKaisu[4],
                Ba5Chakukaisu6 = structUma.ChakuKaisuBa[4].ChakuKaisu[5],
                Ba6Chakukaisu1 = structUma.ChakuKaisuBa[5].ChakuKaisu[0],
                Ba6Chakukaisu2 = structUma.ChakuKaisuBa[5].ChakuKaisu[1],
                Ba6Chakukaisu3 = structUma.ChakuKaisuBa[5].ChakuKaisu[2],
                Ba6Chakukaisu4 = structUma.ChakuKaisuBa[5].ChakuKaisu[3],
                Ba6Chakukaisu5 = structUma.ChakuKaisuBa[5].ChakuKaisu[4],
                Ba6Chakukaisu6 = structUma.ChakuKaisuBa[5].ChakuKaisu[5],
                Ba7Chakukaisu1 = structUma.ChakuKaisuBa[6].ChakuKaisu[0],
                Ba7Chakukaisu2 = structUma.ChakuKaisuBa[6].ChakuKaisu[1],
                Ba7Chakukaisu3 = structUma.ChakuKaisuBa[6].ChakuKaisu[2],
                Ba7Chakukaisu4 = structUma.ChakuKaisuBa[6].ChakuKaisu[3],
                Ba7Chakukaisu5 = structUma.ChakuKaisuBa[6].ChakuKaisu[4],
                Ba7Chakukaisu6 = structUma.ChakuKaisuBa[6].ChakuKaisu[5],
                Jyotai1Chakukaisu1 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[0],
                Jyotai1Chakukaisu2 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[1],
                Jyotai1Chakukaisu3 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[2],
                Jyotai1Chakukaisu4 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[3],
                Jyotai1Chakukaisu5 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[4],
                Jyotai1Chakukaisu6 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[5],
                Jyotai2Chakukaisu1 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[0],
                Jyotai2Chakukaisu2 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[1],
                Jyotai2Chakukaisu3 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[2],
                Jyotai2Chakukaisu4 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[3],
                Jyotai2Chakukaisu5 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[4],
                Jyotai2Chakukaisu6 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[5],
                Jyotai3Chakukaisu1 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[0],
                Jyotai3Chakukaisu2 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[1],
                Jyotai3Chakukaisu3 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[2],
                Jyotai3Chakukaisu4 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[3],
                Jyotai3Chakukaisu5 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[4],
                Jyotai3Chakukaisu6 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[5],
                Jyotai4Chakukaisu1 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[0],
                Jyotai4Chakukaisu2 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[1],
                Jyotai4Chakukaisu3 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[2],
                Jyotai4Chakukaisu4 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[3],
                Jyotai4Chakukaisu5 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[4],
                Jyotai4Chakukaisu6 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[5],
                Jyotai5Chakukaisu1 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[0],
                Jyotai5Chakukaisu2 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[1],
                Jyotai5Chakukaisu3 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[2],
                Jyotai5Chakukaisu4 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[3],
                Jyotai5Chakukaisu5 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[4],
                Jyotai5Chakukaisu6 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[5],
                Jyotai6Chakukaisu1 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[0],
                Jyotai6Chakukaisu2 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[1],
                Jyotai6Chakukaisu3 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[2],
                Jyotai6Chakukaisu4 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[3],
                Jyotai6Chakukaisu5 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[4],
                Jyotai6Chakukaisu6 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[5],
                Jyotai7Chakukaisu1 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[0],
                Jyotai7Chakukaisu2 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[1],
                Jyotai7Chakukaisu3 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[2],
                Jyotai7Chakukaisu4 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[3],
                Jyotai7Chakukaisu5 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[4],
                Jyotai7Chakukaisu6 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[5],
                Jyotai8Chakukaisu1 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[0],
                Jyotai8Chakukaisu2 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[1],
                Jyotai8Chakukaisu3 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[2],
                Jyotai8Chakukaisu4 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[3],
                Jyotai8Chakukaisu5 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[4],
                Jyotai8Chakukaisu6 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[5],
                Jyotai9Chakukaisu1 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[0],
                Jyotai9Chakukaisu2 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[1],
                Jyotai9Chakukaisu3 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[2],
                Jyotai9Chakukaisu4 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[3],
                Jyotai9Chakukaisu5 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[4],
                Jyotai9Chakukaisu6 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[5],
                Jyotai10Chakukaisu1 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[0],
                Jyotai10Chakukaisu2 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[1],
                Jyotai10Chakukaisu3 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[2],
                Jyotai10Chakukaisu4 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[3],
                Jyotai10Chakukaisu5 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[4],
                Jyotai10Chakukaisu6 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[5],
                Jyotai11Chakukaisu1 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[0],
                Jyotai11Chakukaisu2 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[1],
                Jyotai11Chakukaisu3 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[2],
                Jyotai11Chakukaisu4 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[3],
                Jyotai11Chakukaisu5 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[4],
                Jyotai11Chakukaisu6 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[5],
                Jyotai12Chakukaisu1 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[0],
                Jyotai12Chakukaisu2 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[1],
                Jyotai12Chakukaisu3 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[2],
                Jyotai12Chakukaisu4 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[3],
                Jyotai12Chakukaisu5 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[4],
                Jyotai12Chakukaisu6 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[5],
                Kyori1Chakukaisu1 = structUma.ChakuKaisuKyori[0].ChakuKaisu[0],
                Kyori1Chakukaisu2 = structUma.ChakuKaisuKyori[0].ChakuKaisu[1],
                Kyori1Chakukaisu3 = structUma.ChakuKaisuKyori[0].ChakuKaisu[2],
                Kyori1Chakukaisu4 = structUma.ChakuKaisuKyori[0].ChakuKaisu[3],
                Kyori1Chakukaisu5 = structUma.ChakuKaisuKyori[0].ChakuKaisu[4],
                Kyori1Chakukaisu6 = structUma.ChakuKaisuKyori[0].ChakuKaisu[5],
                Kyori2Chakukaisu1 = structUma.ChakuKaisuKyori[1].ChakuKaisu[0],
                Kyori2Chakukaisu2 = structUma.ChakuKaisuKyori[1].ChakuKaisu[1],
                Kyori2Chakukaisu3 = structUma.ChakuKaisuKyori[1].ChakuKaisu[2],
                Kyori2Chakukaisu4 = structUma.ChakuKaisuKyori[1].ChakuKaisu[3],
                Kyori2Chakukaisu5 = structUma.ChakuKaisuKyori[1].ChakuKaisu[4],
                Kyori2Chakukaisu6 = structUma.ChakuKaisuKyori[1].ChakuKaisu[5],
                Kyori3Chakukaisu1 = structUma.ChakuKaisuKyori[2].ChakuKaisu[0],
                Kyori3Chakukaisu2 = structUma.ChakuKaisuKyori[2].ChakuKaisu[1],
                Kyori3Chakukaisu3 = structUma.ChakuKaisuKyori[2].ChakuKaisu[2],
                Kyori3Chakukaisu4 = structUma.ChakuKaisuKyori[2].ChakuKaisu[3],
                Kyori3Chakukaisu5 = structUma.ChakuKaisuKyori[2].ChakuKaisu[4],
                Kyori3Chakukaisu6 = structUma.ChakuKaisuKyori[2].ChakuKaisu[5],
                Kyori4Chakukaisu1 = structUma.ChakuKaisuKyori[3].ChakuKaisu[0],
                Kyori4Chakukaisu2 = structUma.ChakuKaisuKyori[3].ChakuKaisu[1],
                Kyori4Chakukaisu3 = structUma.ChakuKaisuKyori[3].ChakuKaisu[2],
                Kyori4Chakukaisu4 = structUma.ChakuKaisuKyori[3].ChakuKaisu[3],
                Kyori4Chakukaisu5 = structUma.ChakuKaisuKyori[3].ChakuKaisu[4],
                Kyori4Chakukaisu6 = structUma.ChakuKaisuKyori[3].ChakuKaisu[5],
                Kyori5Chakukaisu1 = structUma.ChakuKaisuKyori[4].ChakuKaisu[0],
                Kyori5Chakukaisu2 = structUma.ChakuKaisuKyori[4].ChakuKaisu[1],
                Kyori5Chakukaisu3 = structUma.ChakuKaisuKyori[4].ChakuKaisu[2],
                Kyori5Chakukaisu4 = structUma.ChakuKaisuKyori[4].ChakuKaisu[3],
                Kyori5Chakukaisu5 = structUma.ChakuKaisuKyori[4].ChakuKaisu[4],
                Kyori5Chakukaisu6 = structUma.ChakuKaisuKyori[4].ChakuKaisu[5],
                Kyori6Chakukaisu1 = structUma.ChakuKaisuKyori[5].ChakuKaisu[0],
                Kyori6Chakukaisu2 = structUma.ChakuKaisuKyori[5].ChakuKaisu[1],
                Kyori6Chakukaisu3 = structUma.ChakuKaisuKyori[5].ChakuKaisu[2],
                Kyori6Chakukaisu4 = structUma.ChakuKaisuKyori[5].ChakuKaisu[3],
                Kyori6Chakukaisu5 = structUma.ChakuKaisuKyori[5].ChakuKaisu[4],
                Kyori6Chakukaisu6 = structUma.ChakuKaisuKyori[5].ChakuKaisu[5],
                Kyakusitu1 = structUma.Kyakusitu[0],
                Kyakusitu2 = structUma.Kyakusitu[1],
                Kyakusitu3 = structUma.Kyakusitu[2],
                Kyakusitu4 = structUma.Kyakusitu[3],
                RaceCount = structUma.RaceCount,
            };
            _db.Add(uma);
            _db.SaveChanges();
        }

        public List<Uma> GetList(List<string> kettoNumList)
        {
            var umas = _db.Umas
                .Where(r => kettoNumList.Contains(r.KettoNum))
                .ToList();

            return umas;
        }

        public Uma? GetUma(string kettoNum)
        {
            var uma = _db.Umas
                .Where(r => r.KettoNum == kettoNum)
                .FirstOrDefault();

            return uma;
        }

        public void Update(Uma uma, JV_UM_UMA structUma)
        {
            var head = structUma.head;

            uma.RecordSpec = head.RecordSpec;
            uma.DataKubun = head.DataKubun;
            uma.MakeDate = head.MakeDate.Year + head.MakeDate.Month + head.MakeDate.Day;
            uma.KettoNum = structUma.KettoNum;
            uma.DelKubun = structUma.DelKubun;
            uma.RegDate = structUma.RegDate.Year + structUma.RegDate.Month + structUma.RegDate.Day;
            uma.DelDate = structUma.DelDate.Year + structUma.DelDate.Month + structUma.DelDate.Day;
            uma.BirthDate = structUma.BirthDate.Year + structUma.BirthDate.Month + structUma.BirthDate.Day;
            uma.Bamei = structUma.Bamei;
            uma.BameiKana = structUma.BameiKana;
            uma.BameiEng = structUma.BameiEng;
            uma.ZaikyuFlag = structUma.ZaikyuFlag;
            uma.Reserved = structUma.Reserved;
            uma.UmaKigoCD = structUma.UmaKigoCD;
            uma.SexCD = structUma.SexCD;
            uma.HinsyuCD = structUma.HinsyuCD;
            uma.KeiroCD = structUma.KeiroCD;
            uma.Ketto3InfoHansyokuNum1 = structUma.Ketto3Info[0].HansyokuNum;
            uma.Ketto3InfoBamei1 = structUma.Ketto3Info[0].Bamei;
            uma.Ketto3InfoHansyokuNum2 = structUma.Ketto3Info[1].HansyokuNum;
            uma.Ketto3InfoBamei2 = structUma.Ketto3Info[1].Bamei;
            uma.Ketto3InfoHansyokuNum3 = structUma.Ketto3Info[2].HansyokuNum;
            uma.Ketto3InfoBamei3 = structUma.Ketto3Info[2].Bamei;
            uma.Ketto3InfoHansyokuNum4 = structUma.Ketto3Info[3].HansyokuNum;
            uma.Ketto3InfoBamei4 = structUma.Ketto3Info[3].Bamei;
            uma.Ketto3InfoHansyokuNum5 = structUma.Ketto3Info[4].HansyokuNum;
            uma.Ketto3InfoBamei5 = structUma.Ketto3Info[4].Bamei;
            uma.Ketto3InfoHansyokuNum6 = structUma.Ketto3Info[5].HansyokuNum;
            uma.Ketto3InfoBamei6 = structUma.Ketto3Info[5].Bamei;
            uma.Ketto3InfoHansyokuNum7 = structUma.Ketto3Info[6].HansyokuNum;
            uma.Ketto3InfoBamei7 = structUma.Ketto3Info[6].Bamei;
            uma.Ketto3InfoHansyokuNum8 = structUma.Ketto3Info[7].HansyokuNum;
            uma.Ketto3InfoBamei8 = structUma.Ketto3Info[7].Bamei;
            uma.Ketto3InfoHansyokuNum9 = structUma.Ketto3Info[8].HansyokuNum;
            uma.Ketto3InfoBamei9 = structUma.Ketto3Info[8].Bamei;
            uma.Ketto3InfoHansyokuNum10 = structUma.Ketto3Info[9].HansyokuNum;
            uma.Ketto3InfoBamei10 = structUma.Ketto3Info[9].Bamei;
            uma.Ketto3InfoHansyokuNum11 = structUma.Ketto3Info[10].HansyokuNum;
            uma.Ketto3InfoBamei11 = structUma.Ketto3Info[10].Bamei;
            uma.Ketto3InfoHansyokuNum12 = structUma.Ketto3Info[11].HansyokuNum;
            uma.Ketto3InfoBamei12 = structUma.Ketto3Info[11].Bamei;
            uma.Ketto3InfoHansyokuNum13 = structUma.Ketto3Info[12].HansyokuNum;
            uma.Ketto3InfoBamei13 = structUma.Ketto3Info[12].Bamei;
            uma.Ketto3InfoHansyokuNum14 = structUma.Ketto3Info[13].HansyokuNum;
            uma.Ketto3InfoBamei14 = structUma.Ketto3Info[13].Bamei;
            uma.TozaiCD = structUma.TozaiCD;
            uma.ChokyosiCode = structUma.ChokyosiCode;
            uma.ChokyosiRyakusyo = structUma.ChokyosiRyakusyo;
            uma.Syotai = structUma.Syotai;
            uma.BreederCode = structUma.BreederCode;
            uma.BreederName = structUma.BreederName;
            uma.SanchiName = structUma.SanchiName;
            uma.BanusiCode = structUma.BanusiCode;
            uma.BanusiName = structUma.BanusiName;
            uma.RuikeiHonsyoHeiti = structUma.RuikeiHonsyoHeiti;
            uma.RuikeiHonsyoSyogai = structUma.RuikeiHonsyoSyogai;
            uma.RuikeiFukaHeichi = structUma.RuikeiFukaHeichi;
            uma.RuikeiFukaSyogai = structUma.RuikeiFukaSyogai;
            uma.RuikeiSyutokuHeichi = structUma.RuikeiSyutokuHeichi;
            uma.RuikeiSyutokuSyogai = structUma.RuikeiSyutokuSyogai;
            uma.SogoChakukaisu1 = structUma.ChakuSogo.ChakuKaisu[0];
            uma.SogoChakukaisu2 = structUma.ChakuSogo.ChakuKaisu[1];
            uma.SogoChakukaisu3 = structUma.ChakuSogo.ChakuKaisu[2];
            uma.SogoChakukaisu4 = structUma.ChakuSogo.ChakuKaisu[3];
            uma.SogoChakukaisu5 = structUma.ChakuSogo.ChakuKaisu[4];
            uma.SogoChakukaisu6 = structUma.ChakuSogo.ChakuKaisu[5];
            uma.ChuoChakukaisu1 = structUma.ChakuChuo.ChakuKaisu[0];
            uma.ChuoChakukaisu2 = structUma.ChakuChuo.ChakuKaisu[1];
            uma.ChuoChakukaisu3 = structUma.ChakuChuo.ChakuKaisu[2];
            uma.ChuoChakukaisu4 = structUma.ChakuChuo.ChakuKaisu[3];
            uma.ChuoChakukaisu5 = structUma.ChakuChuo.ChakuKaisu[4];
            uma.ChuoChakukaisu6 = structUma.ChakuChuo.ChakuKaisu[5];
            uma.Ba1Chakukaisu1 = structUma.ChakuKaisuBa[0].ChakuKaisu[0];
            uma.Ba1Chakukaisu2 = structUma.ChakuKaisuBa[0].ChakuKaisu[1];
            uma.Ba1Chakukaisu3 = structUma.ChakuKaisuBa[0].ChakuKaisu[2];
            uma.Ba1Chakukaisu4 = structUma.ChakuKaisuBa[0].ChakuKaisu[3];
            uma.Ba1Chakukaisu5 = structUma.ChakuKaisuBa[0].ChakuKaisu[4];
            uma.Ba1Chakukaisu6 = structUma.ChakuKaisuBa[0].ChakuKaisu[5];
            uma.Ba2Chakukaisu1 = structUma.ChakuKaisuBa[1].ChakuKaisu[0];
            uma.Ba2Chakukaisu2 = structUma.ChakuKaisuBa[1].ChakuKaisu[1];
            uma.Ba2Chakukaisu3 = structUma.ChakuKaisuBa[1].ChakuKaisu[2];
            uma.Ba2Chakukaisu4 = structUma.ChakuKaisuBa[1].ChakuKaisu[3];
            uma.Ba2Chakukaisu5 = structUma.ChakuKaisuBa[1].ChakuKaisu[4];
            uma.Ba2Chakukaisu6 = structUma.ChakuKaisuBa[1].ChakuKaisu[5];
            uma.Ba3Chakukaisu1 = structUma.ChakuKaisuBa[2].ChakuKaisu[0];
            uma.Ba3Chakukaisu2 = structUma.ChakuKaisuBa[2].ChakuKaisu[1];
            uma.Ba3Chakukaisu3 = structUma.ChakuKaisuBa[2].ChakuKaisu[2];
            uma.Ba3Chakukaisu4 = structUma.ChakuKaisuBa[2].ChakuKaisu[3];
            uma.Ba3Chakukaisu5 = structUma.ChakuKaisuBa[2].ChakuKaisu[4];
            uma.Ba3Chakukaisu6 = structUma.ChakuKaisuBa[2].ChakuKaisu[5];
            uma.Ba4Chakukaisu1 = structUma.ChakuKaisuBa[3].ChakuKaisu[0];
            uma.Ba4Chakukaisu2 = structUma.ChakuKaisuBa[3].ChakuKaisu[1];
            uma.Ba4Chakukaisu3 = structUma.ChakuKaisuBa[3].ChakuKaisu[2];
            uma.Ba4Chakukaisu4 = structUma.ChakuKaisuBa[3].ChakuKaisu[3];
            uma.Ba4Chakukaisu5 = structUma.ChakuKaisuBa[3].ChakuKaisu[4];
            uma.Ba4Chakukaisu6 = structUma.ChakuKaisuBa[3].ChakuKaisu[5];
            uma.Ba5Chakukaisu1 = structUma.ChakuKaisuBa[4].ChakuKaisu[0];
            uma.Ba5Chakukaisu2 = structUma.ChakuKaisuBa[4].ChakuKaisu[1];
            uma.Ba5Chakukaisu3 = structUma.ChakuKaisuBa[4].ChakuKaisu[2];
            uma.Ba5Chakukaisu4 = structUma.ChakuKaisuBa[4].ChakuKaisu[3];
            uma.Ba5Chakukaisu5 = structUma.ChakuKaisuBa[4].ChakuKaisu[4];
            uma.Ba5Chakukaisu6 = structUma.ChakuKaisuBa[4].ChakuKaisu[5];
            uma.Ba6Chakukaisu1 = structUma.ChakuKaisuBa[5].ChakuKaisu[0];
            uma.Ba6Chakukaisu2 = structUma.ChakuKaisuBa[5].ChakuKaisu[1];
            uma.Ba6Chakukaisu3 = structUma.ChakuKaisuBa[5].ChakuKaisu[2];
            uma.Ba6Chakukaisu4 = structUma.ChakuKaisuBa[5].ChakuKaisu[3];
            uma.Ba6Chakukaisu5 = structUma.ChakuKaisuBa[5].ChakuKaisu[4];
            uma.Ba6Chakukaisu6 = structUma.ChakuKaisuBa[5].ChakuKaisu[5];
            uma.Ba7Chakukaisu1 = structUma.ChakuKaisuBa[6].ChakuKaisu[0];
            uma.Ba7Chakukaisu2 = structUma.ChakuKaisuBa[6].ChakuKaisu[1];
            uma.Ba7Chakukaisu3 = structUma.ChakuKaisuBa[6].ChakuKaisu[2];
            uma.Ba7Chakukaisu4 = structUma.ChakuKaisuBa[6].ChakuKaisu[3];
            uma.Ba7Chakukaisu5 = structUma.ChakuKaisuBa[6].ChakuKaisu[4];
            uma.Ba7Chakukaisu6 = structUma.ChakuKaisuBa[6].ChakuKaisu[5];
            uma.Jyotai1Chakukaisu1 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[0];
            uma.Jyotai1Chakukaisu2 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[1];
            uma.Jyotai1Chakukaisu3 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[2];
            uma.Jyotai1Chakukaisu4 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[3];
            uma.Jyotai1Chakukaisu5 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[4];
            uma.Jyotai1Chakukaisu6 = structUma.ChakuKaisuJyotai[0].ChakuKaisu[5];
            uma.Jyotai2Chakukaisu1 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[0];
            uma.Jyotai2Chakukaisu2 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[1];
            uma.Jyotai2Chakukaisu3 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[2];
            uma.Jyotai2Chakukaisu4 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[3];
            uma.Jyotai2Chakukaisu5 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[4];
            uma.Jyotai2Chakukaisu6 = structUma.ChakuKaisuJyotai[1].ChakuKaisu[5];
            uma.Jyotai3Chakukaisu1 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[0];
            uma.Jyotai3Chakukaisu2 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[1];
            uma.Jyotai3Chakukaisu3 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[2];
            uma.Jyotai3Chakukaisu4 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[3];
            uma.Jyotai3Chakukaisu5 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[4];
            uma.Jyotai3Chakukaisu6 = structUma.ChakuKaisuJyotai[2].ChakuKaisu[5];
            uma.Jyotai4Chakukaisu1 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[0];
            uma.Jyotai4Chakukaisu2 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[1];
            uma.Jyotai4Chakukaisu3 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[2];
            uma.Jyotai4Chakukaisu4 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[3];
            uma.Jyotai4Chakukaisu5 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[4];
            uma.Jyotai4Chakukaisu6 = structUma.ChakuKaisuJyotai[3].ChakuKaisu[5];
            uma.Jyotai5Chakukaisu1 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[0];
            uma.Jyotai5Chakukaisu2 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[1];
            uma.Jyotai5Chakukaisu3 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[2];
            uma.Jyotai5Chakukaisu4 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[3];
            uma.Jyotai5Chakukaisu5 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[4];
            uma.Jyotai5Chakukaisu6 = structUma.ChakuKaisuJyotai[4].ChakuKaisu[5];
            uma.Jyotai6Chakukaisu1 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[0];
            uma.Jyotai6Chakukaisu2 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[1];
            uma.Jyotai6Chakukaisu3 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[2];
            uma.Jyotai6Chakukaisu4 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[3];
            uma.Jyotai6Chakukaisu5 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[4];
            uma.Jyotai6Chakukaisu6 = structUma.ChakuKaisuJyotai[5].ChakuKaisu[5];
            uma.Jyotai7Chakukaisu1 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[0];
            uma.Jyotai7Chakukaisu2 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[1];
            uma.Jyotai7Chakukaisu3 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[2];
            uma.Jyotai7Chakukaisu4 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[3];
            uma.Jyotai7Chakukaisu5 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[4];
            uma.Jyotai7Chakukaisu6 = structUma.ChakuKaisuJyotai[6].ChakuKaisu[5];
            uma.Jyotai8Chakukaisu1 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[0];
            uma.Jyotai8Chakukaisu2 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[1];
            uma.Jyotai8Chakukaisu3 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[2];
            uma.Jyotai8Chakukaisu4 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[3];
            uma.Jyotai8Chakukaisu5 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[4];
            uma.Jyotai8Chakukaisu6 = structUma.ChakuKaisuJyotai[7].ChakuKaisu[5];
            uma.Jyotai9Chakukaisu1 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[0];
            uma.Jyotai9Chakukaisu2 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[1];
            uma.Jyotai9Chakukaisu3 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[2];
            uma.Jyotai9Chakukaisu4 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[3];
            uma.Jyotai9Chakukaisu5 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[4];
            uma.Jyotai9Chakukaisu6 = structUma.ChakuKaisuJyotai[8].ChakuKaisu[5];
            uma.Jyotai10Chakukaisu1 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[0];
            uma.Jyotai10Chakukaisu2 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[1];
            uma.Jyotai10Chakukaisu3 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[2];
            uma.Jyotai10Chakukaisu4 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[3];
            uma.Jyotai10Chakukaisu5 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[4];
            uma.Jyotai10Chakukaisu6 = structUma.ChakuKaisuJyotai[9].ChakuKaisu[5];
            uma.Jyotai11Chakukaisu1 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[0];
            uma.Jyotai11Chakukaisu2 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[1];
            uma.Jyotai11Chakukaisu3 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[2];
            uma.Jyotai11Chakukaisu4 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[3];
            uma.Jyotai11Chakukaisu5 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[4];
            uma.Jyotai11Chakukaisu6 = structUma.ChakuKaisuJyotai[10].ChakuKaisu[5];
            uma.Jyotai12Chakukaisu1 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[0];
            uma.Jyotai12Chakukaisu2 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[1];
            uma.Jyotai12Chakukaisu3 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[2];
            uma.Jyotai12Chakukaisu4 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[3];
            uma.Jyotai12Chakukaisu5 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[4];
            uma.Jyotai12Chakukaisu6 = structUma.ChakuKaisuJyotai[11].ChakuKaisu[5];
            uma.Kyori1Chakukaisu1 = structUma.ChakuKaisuKyori[0].ChakuKaisu[0];
            uma.Kyori1Chakukaisu2 = structUma.ChakuKaisuKyori[0].ChakuKaisu[1];
            uma.Kyori1Chakukaisu3 = structUma.ChakuKaisuKyori[0].ChakuKaisu[2];
            uma.Kyori1Chakukaisu4 = structUma.ChakuKaisuKyori[0].ChakuKaisu[3];
            uma.Kyori1Chakukaisu5 = structUma.ChakuKaisuKyori[0].ChakuKaisu[4];
            uma.Kyori1Chakukaisu6 = structUma.ChakuKaisuKyori[0].ChakuKaisu[5];
            uma.Kyori2Chakukaisu1 = structUma.ChakuKaisuKyori[1].ChakuKaisu[0];
            uma.Kyori2Chakukaisu2 = structUma.ChakuKaisuKyori[1].ChakuKaisu[1];
            uma.Kyori2Chakukaisu3 = structUma.ChakuKaisuKyori[1].ChakuKaisu[2];
            uma.Kyori2Chakukaisu4 = structUma.ChakuKaisuKyori[1].ChakuKaisu[3];
            uma.Kyori2Chakukaisu5 = structUma.ChakuKaisuKyori[1].ChakuKaisu[4];
            uma.Kyori2Chakukaisu6 = structUma.ChakuKaisuKyori[1].ChakuKaisu[5];
            uma.Kyori3Chakukaisu1 = structUma.ChakuKaisuKyori[2].ChakuKaisu[0];
            uma.Kyori3Chakukaisu2 = structUma.ChakuKaisuKyori[2].ChakuKaisu[1];
            uma.Kyori3Chakukaisu3 = structUma.ChakuKaisuKyori[2].ChakuKaisu[2];
            uma.Kyori3Chakukaisu4 = structUma.ChakuKaisuKyori[2].ChakuKaisu[3];
            uma.Kyori3Chakukaisu5 = structUma.ChakuKaisuKyori[2].ChakuKaisu[4];
            uma.Kyori3Chakukaisu6 = structUma.ChakuKaisuKyori[2].ChakuKaisu[5];
            uma.Kyori4Chakukaisu1 = structUma.ChakuKaisuKyori[3].ChakuKaisu[0];
            uma.Kyori4Chakukaisu2 = structUma.ChakuKaisuKyori[3].ChakuKaisu[1];
            uma.Kyori4Chakukaisu3 = structUma.ChakuKaisuKyori[3].ChakuKaisu[2];
            uma.Kyori4Chakukaisu4 = structUma.ChakuKaisuKyori[3].ChakuKaisu[3];
            uma.Kyori4Chakukaisu5 = structUma.ChakuKaisuKyori[3].ChakuKaisu[4];
            uma.Kyori4Chakukaisu6 = structUma.ChakuKaisuKyori[3].ChakuKaisu[5];
            uma.Kyori5Chakukaisu1 = structUma.ChakuKaisuKyori[4].ChakuKaisu[0];
            uma.Kyori5Chakukaisu2 = structUma.ChakuKaisuKyori[4].ChakuKaisu[1];
            uma.Kyori5Chakukaisu3 = structUma.ChakuKaisuKyori[4].ChakuKaisu[2];
            uma.Kyori5Chakukaisu4 = structUma.ChakuKaisuKyori[4].ChakuKaisu[3];
            uma.Kyori5Chakukaisu5 = structUma.ChakuKaisuKyori[4].ChakuKaisu[4];
            uma.Kyori5Chakukaisu6 = structUma.ChakuKaisuKyori[4].ChakuKaisu[5];
            uma.Kyori6Chakukaisu1 = structUma.ChakuKaisuKyori[5].ChakuKaisu[0];
            uma.Kyori6Chakukaisu2 = structUma.ChakuKaisuKyori[5].ChakuKaisu[1];
            uma.Kyori6Chakukaisu3 = structUma.ChakuKaisuKyori[5].ChakuKaisu[2];
            uma.Kyori6Chakukaisu4 = structUma.ChakuKaisuKyori[5].ChakuKaisu[3];
            uma.Kyori6Chakukaisu5 = structUma.ChakuKaisuKyori[5].ChakuKaisu[4];
            uma.Kyori6Chakukaisu6 = structUma.ChakuKaisuKyori[5].ChakuKaisu[5];
            uma.Kyakusitu1 = structUma.Kyakusitu[0];
            uma.Kyakusitu2 = structUma.Kyakusitu[1];
            uma.Kyakusitu3 = structUma.Kyakusitu[2];
            uma.Kyakusitu4 = structUma.Kyakusitu[3];
            uma.RaceCount = structUma.RaceCount;

            _db.SaveChanges();
        }


        public void DeleteAll()
        {
            _db.Database.ExecuteSqlRaw("TRUNCATE TABLE Umas");
        }
    }
}
