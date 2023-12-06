using JraVanRaceHorseTable.Models;
using Microsoft.EntityFrameworkCore;
using static JraVanRaceHorseTable.Const;
using static JVData_Struct;

namespace JraVanRaceHorseTable.Services
{
    public interface IRaceUmaService
    {
        void Add(JV_SE_RACE_UMA structRaceUma, int raceId);
        List<RaceUma> GetList(int raceId, string dataKubun);
        void DeleteAll();
    }

    public class RaceUmaService : IRaceUmaService
    {
        private readonly ApplicationDbContext _db;

        public RaceUmaService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(JV_SE_RACE_UMA structRaceUma, int raceId)
        {
            var head = structRaceUma.head;

            var raceUma = new RaceUma
            {
                RaceId = raceId,
                RecordSpec = head.RecordSpec,
                DataKubun = head.DataKubun,
                MakeDate = head.MakeDate.Year + head.MakeDate.Month + head.MakeDate.Day,
                Wakuban = structRaceUma.Wakuban,
                Umaban = structRaceUma.Umaban,
                KettoNum = structRaceUma.KettoNum,
                Bamei = structRaceUma.Bamei,
                UmaKigoCD = structRaceUma.UmaKigoCD,
                SexCD = structRaceUma.SexCD,
                HinsyuCD = structRaceUma.HinsyuCD,
                KeiroCD = structRaceUma.KeiroCD,
                Barei = structRaceUma.Barei,
                TozaiCD = structRaceUma.TozaiCD,
                ChokyosiCode = structRaceUma.ChokyosiCode,
                ChokyosiRyakusyo = structRaceUma.ChokyosiRyakusyo,
                BanusiCode = structRaceUma.BanusiCode,
                BanusiName = structRaceUma.BanusiName,
                Fukusyoku = structRaceUma.Fukusyoku,
                Reserved1 = structRaceUma.reserved1,
                Futan = structRaceUma.Futan,
                FutanBefore = structRaceUma.FutanBefore,
                Blinker = structRaceUma.Blinker,
                Reserved2 = structRaceUma.reserved2,
                KisyuCode = structRaceUma.KisyuCode,
                KisyuCodeBefore = structRaceUma.KisyuCodeBefore,
                KisyuRyakusyo = structRaceUma.KisyuRyakusyo,
                KisyuRyakusyoBefore = structRaceUma.KisyuRyakusyoBefore,
                MinaraiCD = structRaceUma.MinaraiCD,
                MinaraiCDBefore = structRaceUma.MinaraiCDBefore,
                BaTaijyu = structRaceUma.BaTaijyu,
                ZogenFugo = structRaceUma.ZogenFugo,
                ZogenSa = structRaceUma.ZogenSa,
                IJyoCD = structRaceUma.IJyoCD,
                NyusenJyuni = structRaceUma.NyusenJyuni,
                KakuteiJyuni = structRaceUma.KakuteiJyuni,
                DochakuKubun = structRaceUma.DochakuKubun,
                DochakuTosu = structRaceUma.DochakuTosu,
                Time = structRaceUma.Time,
                ChakusaCD = structRaceUma.ChakusaCD,
                ChakusaCDP = structRaceUma.ChakusaCDP,
                ChakusaCDPP = structRaceUma.ChakusaCDPP,
                Jyuni1c = structRaceUma.Jyuni1c,
                Jyuni2c = structRaceUma.Jyuni2c,
                Jyuni3c = structRaceUma.Jyuni3c,
                Jyuni4c = structRaceUma.Jyuni4c,
                Odds = structRaceUma.Odds,
                Ninki = structRaceUma.Ninki,
                Honsyokin = structRaceUma.Honsyokin,
                Fukasyokin = structRaceUma.Fukasyokin,
                Reserved3 = structRaceUma.reserved3,
                Reserved4 = structRaceUma.reserved4,
                HaronTimeL4 = structRaceUma.HaronTimeL4,
                HaronTimeL3 = structRaceUma.HaronTimeL3,
                KettoNum1 = structRaceUma.ChakuUmaInfo[0].KettoNum,
                Bamei1 = structRaceUma.ChakuUmaInfo[0].Bamei,
                KettoNum2 = structRaceUma.ChakuUmaInfo[1].KettoNum,
                Bamei2 = structRaceUma.ChakuUmaInfo[1].Bamei,
                KettoNum3 = structRaceUma.ChakuUmaInfo[2].KettoNum,
                Bamei3 = structRaceUma.ChakuUmaInfo[2].Bamei,
                TimeDiff = structRaceUma.TimeDiff,
                RecordUpKubun = structRaceUma.RecordUpKubun,
                DMKubun = structRaceUma.DMKubun,
                DMTime = structRaceUma.DMTime,
                DMGosaP = structRaceUma.DMGosaP,
                DMGosaM = structRaceUma.DMGosaM,
                DMJyuni = structRaceUma.DMJyuni,
                KyakusituKubun = structRaceUma.KyakusituKubun,
            };
            _db.Add(raceUma);
            _db.SaveChanges();
        }

        public List<RaceUma> GetList(int raceId, string dataKubun)
        {
            var query = _db.RaceUmas.Where(r => r.RaceId == raceId);

            if (!DataKind.Thursday.Equals(dataKubun))
            {
                // 出走馬名表→出馬表でいなくなった馬を除外
                query = query.Where(r => r.Umaban != "00");
            }

            var raceUmas = query
                .OrderBy(r => r.Umaban)
                .ThenBy(r => r.Bamei)
                .ToList();

            return raceUmas;
        }

        public void DeleteAll()
        {
            _db.Database.ExecuteSqlRaw("TRUNCATE TABLE RaceUmas");
        }
    }
}
