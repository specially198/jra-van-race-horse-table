using JraVanRaceHorseTable.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static JraVanRaceHorseTable.Const;
using static JVData_Struct;

namespace JraVanRaceHorseTable.Services
{
    public interface IRaceUmaService
    {
        void InsertOrUpdate(JV_SE_RACE_UMA structRaceUma, int raceId);
        void Add(JV_SE_RACE_UMA structRaceUma, int raceId);
        List<RaceUma> GetList(int raceId, string dataKubun);
        List<RaceUma> GetListByHorse(string kettoNum);
        RaceUma? GetRaceUma(int raceId, string kettoNum);
        void Update(RaceUma raceUma, JV_SE_RACE_UMA structRaceUma);
        void DeleteAll();
    }

    public class RaceUmaService : IRaceUmaService
    {
        private readonly ApplicationDbContext _db;

        public RaceUmaService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InsertOrUpdate(JV_SE_RACE_UMA structRaceUma, int raceId)
        {
            var raceUma = GetRaceUma(raceId, structRaceUma.KettoNum);

            if (raceUma == null)
            {
                Add(structRaceUma, raceId);
            }
            else
            {
                Update(raceUma, structRaceUma);
            }
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

        public List<RaceUma> GetListByHorse(string kettoNum)
        {
            var raceUmas = _db.RaceUmas
                .Include(r => r.Race)
                .Join(
                    _db.Races,
                    raceUma => raceUma.RaceId,
                    race => race.Id,
                    (raceUma, race) => new { raceUma, race })
                .Where(x => x.raceUma.KettoNum == kettoNum)
                .Where(x => DataKindResult.Contains(x.raceUma.DataKubun))
                .OrderByDescending(x => x.race.Year)
                .ThenByDescending(x => x.race.MonthDay)
                .Select(x => x.raceUma)
                .ToList();

            return raceUmas;
        }

        public RaceUma? GetRaceUma(int raceId, string kettoNum)
        {
            var raceUma = _db.RaceUmas
                .Where(r => r.RaceId == raceId)
                .Where(r => r.KettoNum == kettoNum)
                .FirstOrDefault();

            return raceUma;
        }

        public void Update(RaceUma raceUma, JV_SE_RACE_UMA structRaceUma)
        {
            var head = structRaceUma.head;

            raceUma.RecordSpec = head.RecordSpec;
            raceUma.DataKubun = head.DataKubun;
            raceUma.MakeDate = head.MakeDate.Year + head.MakeDate.Month + head.MakeDate.Day;
            raceUma.Wakuban = structRaceUma.Wakuban;
            raceUma.Umaban = structRaceUma.Umaban;
            raceUma.KettoNum = structRaceUma.KettoNum;
            raceUma.Bamei = structRaceUma.Bamei;
            raceUma.UmaKigoCD = structRaceUma.UmaKigoCD;
            raceUma.SexCD = structRaceUma.SexCD;
            raceUma.HinsyuCD = structRaceUma.HinsyuCD;
            raceUma.KeiroCD = structRaceUma.KeiroCD;
            raceUma.Barei = structRaceUma.Barei;
            raceUma.TozaiCD = structRaceUma.TozaiCD;
            raceUma.ChokyosiCode = structRaceUma.ChokyosiCode;
            raceUma.ChokyosiRyakusyo = structRaceUma.ChokyosiRyakusyo;
            raceUma.BanusiCode = structRaceUma.BanusiCode;
            raceUma.BanusiName = structRaceUma.BanusiName;
            raceUma.Fukusyoku = structRaceUma.Fukusyoku;
            raceUma.Reserved1 = structRaceUma.reserved1;
            raceUma.Futan = structRaceUma.Futan;
            raceUma.FutanBefore = structRaceUma.FutanBefore;
            raceUma.Blinker = structRaceUma.Blinker;
            raceUma.Reserved2 = structRaceUma.reserved2;
            raceUma.KisyuCode = structRaceUma.KisyuCode;
            raceUma.KisyuCodeBefore = structRaceUma.KisyuCodeBefore;
            raceUma.KisyuRyakusyo = structRaceUma.KisyuRyakusyo;
            raceUma.KisyuRyakusyoBefore = structRaceUma.KisyuRyakusyoBefore;
            raceUma.MinaraiCD = structRaceUma.MinaraiCD;
            raceUma.MinaraiCDBefore = structRaceUma.MinaraiCDBefore;
            raceUma.BaTaijyu = structRaceUma.BaTaijyu;
            raceUma.ZogenFugo = structRaceUma.ZogenFugo;
            raceUma.ZogenSa = structRaceUma.ZogenSa;
            raceUma.IJyoCD = structRaceUma.IJyoCD;
            raceUma.NyusenJyuni = structRaceUma.NyusenJyuni;
            raceUma.KakuteiJyuni = structRaceUma.KakuteiJyuni;
            raceUma.DochakuKubun = structRaceUma.DochakuKubun;
            raceUma.DochakuTosu = structRaceUma.DochakuTosu;
            raceUma.Time = structRaceUma.Time;
            raceUma.ChakusaCD = structRaceUma.ChakusaCD;
            raceUma.ChakusaCDP = structRaceUma.ChakusaCDP;
            raceUma.ChakusaCDPP = structRaceUma.ChakusaCDPP;
            raceUma.Jyuni1c = structRaceUma.Jyuni1c;
            raceUma.Jyuni2c = structRaceUma.Jyuni2c;
            raceUma.Jyuni3c = structRaceUma.Jyuni3c;
            raceUma.Jyuni4c = structRaceUma.Jyuni4c;
            raceUma.Odds = structRaceUma.Odds;
            raceUma.Ninki = structRaceUma.Ninki;
            raceUma.Honsyokin = structRaceUma.Honsyokin;
            raceUma.Fukasyokin = structRaceUma.Fukasyokin;
            raceUma.Reserved3 = structRaceUma.reserved3;
            raceUma.Reserved4 = structRaceUma.reserved4;
            raceUma.HaronTimeL4 = structRaceUma.HaronTimeL4;
            raceUma.HaronTimeL3 = structRaceUma.HaronTimeL3;
            raceUma.KettoNum1 = structRaceUma.ChakuUmaInfo[0].KettoNum;
            raceUma.Bamei1 = structRaceUma.ChakuUmaInfo[0].Bamei;
            raceUma.KettoNum2 = structRaceUma.ChakuUmaInfo[1].KettoNum;
            raceUma.Bamei2 = structRaceUma.ChakuUmaInfo[1].Bamei;
            raceUma.KettoNum3 = structRaceUma.ChakuUmaInfo[2].KettoNum;
            raceUma.Bamei3 = structRaceUma.ChakuUmaInfo[2].Bamei;
            raceUma.TimeDiff = structRaceUma.TimeDiff;
            raceUma.RecordUpKubun = structRaceUma.RecordUpKubun;
            raceUma.DMKubun = structRaceUma.DMKubun;
            raceUma.DMTime = structRaceUma.DMTime;
            raceUma.DMGosaP = structRaceUma.DMGosaP;
            raceUma.DMGosaM = structRaceUma.DMGosaM;
            raceUma.DMJyuni = structRaceUma.DMJyuni;
            raceUma.KyakusituKubun = structRaceUma.KyakusituKubun;

            _db.SaveChanges();
        }


        public void DeleteAll()
        {
            _db.Database.ExecuteSqlRaw("TRUNCATE TABLE RaceUmas");
        }
    }
}
