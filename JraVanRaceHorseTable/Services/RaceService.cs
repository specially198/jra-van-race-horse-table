using JraVanRaceHorseTable.Models;
using JraVanRaceHorseTable.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using static JraVanRaceHorseTable.Const;
using static JVData_Struct;

namespace JraVanRaceHorseTable.Services
{
    public interface IRaceService
    {
        void InsertOrUpdate(JV_RA_RACE structRace);
        void Add(JV_RA_RACE structRace);
        int GetRaceId(string year, string monthDay, string jyoCD, string kaiji, string nichiji, string raceNum);
        List<RaceYearMonthViewModel> GetRaceYearMonthDayList();
        List<Race> GetListByYearAndMonthDay(string year, string monthDay);
        Race? GetRace(string year, string monthDay, string jyoCd, string raceNum);
        void DeleteAll();
    }

    public class RaceService : IRaceService
    {
        private readonly ApplicationDbContext _db;

        public RaceService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InsertOrUpdate(JV_RA_RACE structRace)
        {
            var structId = structRace.id;
            var race = GetRace(structId.Year, structId.MonthDay, structId.JyoCD, structId.RaceNum);

            if (race == null)
            {
                Add(structRace);
            }
            else
            {
                Update(race, structRace);
            }
        }

        public void Add(JV_RA_RACE structRace)
        {
            var head = structRace.head;
            var id = structRace.id;
            var raceInfo = structRace.RaceInfo;
            var jyokenInfo = structRace.JyokenInfo;
            var tenkoBaba = structRace.TenkoBaba;

            var race = new Race
            {
                RecordSpec = head.RecordSpec,
                DataKubun = head.DataKubun,
                MakeDate = head.MakeDate.Year + head.MakeDate.Month + head.MakeDate.Day,
                Year = id.Year,
                MonthDay = id.MonthDay,
                JyoCD = id.JyoCD,
                Kaiji = id.Kaiji,
                Nichiji = id.Nichiji,
                RaceNum = id.RaceNum,
                YoubiCD = raceInfo.YoubiCD,
                TokuNum = raceInfo.TokuNum,
                Hondai = raceInfo.Hondai,
                Fukudai = raceInfo.Fukudai,
                Kakko = raceInfo.Kakko,
                HondaiEng = raceInfo.HondaiEng,
                FukudaiEng = raceInfo.FukudaiEng,
                KakkoEng = raceInfo.KakkoEng,
                Ryakusyo10 = raceInfo.Ryakusyo10,
                Ryakusyo6 = raceInfo.Ryakusyo6,
                Ryakusyo3 = raceInfo.Ryakusyo3,
                Kubun = raceInfo.Kubun,
                Nkai = raceInfo.Nkai,
                GradeCD = structRace.GradeCD,
                GradeCDBefore = structRace.GradeCDBefore,
                SyubetuCD = jyokenInfo.SyubetuCD,
                KigoCD = jyokenInfo.KigoCD,
                JyuryoCD = jyokenInfo.JyuryoCD,
                JyokenCD1 = jyokenInfo.JyokenCD[0],
                JyokenCD2 = jyokenInfo.JyokenCD[1],
                JyokenCD3 = jyokenInfo.JyokenCD[2],
                JyokenCD4 = jyokenInfo.JyokenCD[3],
                JyokenCD5 = jyokenInfo.JyokenCD[4],
                JyokenName = structRace.JyokenName,
                Kyori = structRace.Kyori,
                KyoriBefore = structRace.KyoriBefore,
                TrackCD = structRace.TrackCD,
                TrackCDBefore = structRace.TrackCDBefore,
                CourseKubunCD = structRace.CourseKubunCD,
                CourseKubunCDBefore = structRace.CourseKubunCDBefore,
                Honsyokin1 = structRace.Honsyokin[0],
                Honsyokin2 = structRace.Honsyokin[1],
                Honsyokin3 = structRace.Honsyokin[2],
                Honsyokin4 = structRace.Honsyokin[3],
                Honsyokin5 = structRace.Honsyokin[4],
                Honsyokin6 = structRace.Honsyokin[5],
                Honsyokin7 = structRace.Honsyokin[6],
                HonsyokinBefore1 = structRace.HonsyokinBefore[0],
                HonsyokinBefore2 = structRace.HonsyokinBefore[1],
                HonsyokinBefore3 = structRace.HonsyokinBefore[2],
                HonsyokinBefore4 = structRace.HonsyokinBefore[3],
                HonsyokinBefore5 = structRace.HonsyokinBefore[4],
                Fukasyokin1 = structRace.Fukasyokin[0],
                Fukasyokin2 = structRace.Fukasyokin[1],
                Fukasyokin3 = structRace.Fukasyokin[2],
                Fukasyokin4 = structRace.Fukasyokin[3],
                Fukasyokin5 = structRace.Fukasyokin[4],
                FukasyokinBefore1 = structRace.FukasyokinBefore[0],
                FukasyokinBefore2 = structRace.FukasyokinBefore[1],
                FukasyokinBefore3 = structRace.FukasyokinBefore[2],
                HassoTime = structRace.HassoTime,
                HassoTimeBefore = structRace.HassoTimeBefore,
                TorokuTosu = structRace.TorokuTosu,
                SyussoTosu = structRace.SyussoTosu,
                NyusenTosu = structRace.NyusenTosu,
                TenkoCD = tenkoBaba.TenkoCD,
                SibaBabaCD = tenkoBaba.SibaBabaCD,
                DirtBabaCD = tenkoBaba.DirtBabaCD,
                LapTime1 = structRace.LapTime[0],
                LapTime2 = structRace.LapTime[1],
                LapTime3 = structRace.LapTime[2],
                LapTime4 = structRace.LapTime[3],
                LapTime5 = structRace.LapTime[4],
                LapTime6 = structRace.LapTime[5],
                LapTime7 = structRace.LapTime[6],
                LapTime8 = structRace.LapTime[7],
                LapTime9 = structRace.LapTime[8],
                LapTime10 = structRace.LapTime[9],
                LapTime11 = structRace.LapTime[10],
                LapTime12 = structRace.LapTime[11],
                LapTime13 = structRace.LapTime[12],
                LapTime14 = structRace.LapTime[13],
                LapTime15 = structRace.LapTime[14],
                LapTime16 = structRace.LapTime[15],
                LapTime17 = structRace.LapTime[16],
                LapTime18 = structRace.LapTime[17],
                LapTime19 = structRace.LapTime[18],
                LapTime20 = structRace.LapTime[19],
                LapTime21 = structRace.LapTime[20],
                LapTime22 = structRace.LapTime[21],
                LapTime23 = structRace.LapTime[22],
                LapTime24 = structRace.LapTime[23],
                LapTime25 = structRace.LapTime[24],
                SyogaiMileTime = structRace.SyogaiMileTime,
                HaronTimeS3 = structRace.HaronTimeS3,
                HaronTimeS4 = structRace.HaronTimeS4,
                HaronTimeL3 = structRace.HaronTimeL3,
                HaronTimeL4 = structRace.HaronTimeL4,
                Corner1 = structRace.CornerInfo[0].Corner,
                Syukaisu1 = structRace.CornerInfo[0].Syukaisu,
                Jyuni1 = structRace.CornerInfo[0].Jyuni,
                Corner2 = structRace.CornerInfo[1].Corner,
                Syukaisu2 = structRace.CornerInfo[1].Syukaisu,
                Jyuni2 = structRace.CornerInfo[1].Jyuni,
                Corner3 = structRace.CornerInfo[2].Corner,
                Syukaisu3 = structRace.CornerInfo[2].Syukaisu,
                Jyuni3 = structRace.CornerInfo[2].Jyuni,
                Corner4 = structRace.CornerInfo[3].Corner,
                Syukaisu4 = structRace.CornerInfo[3].Syukaisu,
                Jyuni4 = structRace.CornerInfo[3].Jyuni,
                RecordUpKubun = structRace.RecordUpKubun,
            };
            _db.Add(race);
            _db.SaveChanges();
        }

        public int GetRaceId(string year, string monthDay, string jyoCD, string kaiji, string nichiji, string raceNum)
        {
            var raceId = _db.Races
                .Where(r => r.Year == year)
                .Where(r => r.MonthDay == monthDay)
                .Where(r => r.JyoCD == jyoCD)
                .Where(r => r.Kaiji == kaiji)
                .Where(r => r.Nichiji == nichiji)
                .Where(r => r.RaceNum == raceNum)
                .Select(r => r.Id)
                .First();

            return raceId;
        }

        public List<RaceYearMonthViewModel> GetRaceYearMonthDayList()
        {
            // 地方、海外レースを除外
            var races = _db.Races
                .Where(r => !DataKindNarAndOverseas.Contains(r.DataKubun))
                .OrderByDescending(r => r.Year)
                .OrderByDescending(r => r.MonthDay)
                .Select(r => new RaceYearMonthViewModel()
                {
                    Year = r.Year,
                    MonthDay = r.MonthDay,
                })
                .Distinct()
                .ToList();

            return races;
        }

        public List<Race> GetListByYearAndMonthDay(string year, string monthDay)
        {
            var races = _db.Races
                .Where(r => r.Year == year)
                .Where(r => r.MonthDay == monthDay)
                .Where(r => !DataKindNarAndOverseas.Contains(r.DataKubun))
                .OrderBy(r => r.JyoCD)
                .ThenBy(r => r.RaceNum)
                .ToList();

            return races;
        }

        public Race? GetRace(string year, string monthDay, string jyoCd, string raceNum)
        {
            var race = _db.Races
                .Where(r => r.Year == year)
                .Where(r => r.MonthDay == monthDay)
                .Where(r => r.JyoCD == jyoCd)
                .Where(r => r.RaceNum == raceNum)
                .FirstOrDefault();

            return race;
        }

        public void Update(Race race, JV_RA_RACE structRace)
        {
            var head = structRace.head;
            var id = structRace.id;
            var raceInfo = structRace.RaceInfo;
            var jyokenInfo = structRace.JyokenInfo;
            var tenkoBaba = structRace.TenkoBaba;

            race.RecordSpec = head.RecordSpec;
            race.DataKubun = head.DataKubun;
            race.MakeDate = head.MakeDate.Year + head.MakeDate.Month + head.MakeDate.Day;
            race.Year = id.Year;
            race.MonthDay = id.MonthDay;
            race.JyoCD = id.JyoCD;
            race.Kaiji = id.Kaiji;
            race.Nichiji = id.Nichiji;
            race.RaceNum = id.RaceNum;
            race.YoubiCD = raceInfo.YoubiCD;
            race.TokuNum = raceInfo.TokuNum;
            race.Hondai = raceInfo.Hondai;
            race.Fukudai = raceInfo.Fukudai;
            race.Kakko = raceInfo.Kakko;
            race.HondaiEng = raceInfo.HondaiEng;
            race.FukudaiEng = raceInfo.FukudaiEng;
            race.KakkoEng = raceInfo.KakkoEng;
            race.Ryakusyo10 = raceInfo.Ryakusyo10;
            race.Ryakusyo6 = raceInfo.Ryakusyo6;
            race.Ryakusyo3 = raceInfo.Ryakusyo3;
            race.Kubun = raceInfo.Kubun;
            race.Nkai = raceInfo.Nkai;
            race.GradeCD = structRace.GradeCD;
            race.GradeCDBefore = structRace.GradeCDBefore;
            race.SyubetuCD = jyokenInfo.SyubetuCD;
            race.KigoCD = jyokenInfo.KigoCD;
            race.JyuryoCD = jyokenInfo.JyuryoCD;
            race.JyokenCD1 = jyokenInfo.JyokenCD[0];
            race.JyokenCD2 = jyokenInfo.JyokenCD[1];
            race.JyokenCD3 = jyokenInfo.JyokenCD[2];
            race.JyokenCD4 = jyokenInfo.JyokenCD[3];
            race.JyokenCD5 = jyokenInfo.JyokenCD[4];
            race.JyokenName = structRace.JyokenName;
            race.Kyori = structRace.Kyori;
            race.KyoriBefore = structRace.KyoriBefore;
            race.TrackCD = structRace.TrackCD;
            race.TrackCDBefore = structRace.TrackCDBefore;
            race.CourseKubunCD = structRace.CourseKubunCD;
            race.CourseKubunCDBefore = structRace.CourseKubunCDBefore;
            race.Honsyokin1 = structRace.Honsyokin[0];
            race.Honsyokin2 = structRace.Honsyokin[1];
            race.Honsyokin3 = structRace.Honsyokin[2];
            race.Honsyokin4 = structRace.Honsyokin[3];
            race.Honsyokin5 = structRace.Honsyokin[4];
            race.Honsyokin6 = structRace.Honsyokin[5];
            race.Honsyokin7 = structRace.Honsyokin[6];
            race.HonsyokinBefore1 = structRace.HonsyokinBefore[0];
            race.HonsyokinBefore2 = structRace.HonsyokinBefore[1];
            race.HonsyokinBefore3 = structRace.HonsyokinBefore[2];
            race.HonsyokinBefore4 = structRace.HonsyokinBefore[3];
            race.HonsyokinBefore5 = structRace.HonsyokinBefore[4];
            race.Fukasyokin1 = structRace.Fukasyokin[0];
            race.Fukasyokin2 = structRace.Fukasyokin[1];
            race.Fukasyokin3 = structRace.Fukasyokin[2];
            race.Fukasyokin4 = structRace.Fukasyokin[3];
            race.Fukasyokin5 = structRace.Fukasyokin[4];
            race.FukasyokinBefore1 = structRace.FukasyokinBefore[0];
            race.FukasyokinBefore2 = structRace.FukasyokinBefore[1];
            race.FukasyokinBefore3 = structRace.FukasyokinBefore[2];
            race.HassoTime = structRace.HassoTime;
            race.HassoTimeBefore = structRace.HassoTimeBefore;
            race.TorokuTosu = structRace.TorokuTosu;
            race.SyussoTosu = structRace.SyussoTosu;
            race.NyusenTosu = structRace.NyusenTosu;
            race.TenkoCD = tenkoBaba.TenkoCD;
            race.SibaBabaCD = tenkoBaba.SibaBabaCD;
            race.DirtBabaCD = tenkoBaba.DirtBabaCD;
            race.LapTime1 = structRace.LapTime[0];
            race.LapTime2 = structRace.LapTime[1];
            race.LapTime3 = structRace.LapTime[2];
            race.LapTime4 = structRace.LapTime[3];
            race.LapTime5 = structRace.LapTime[4];
            race.LapTime6 = structRace.LapTime[5];
            race.LapTime7 = structRace.LapTime[6];
            race.LapTime8 = structRace.LapTime[7];
            race.LapTime9 = structRace.LapTime[8];
            race.LapTime10 = structRace.LapTime[9];
            race.LapTime11 = structRace.LapTime[10];
            race.LapTime12 = structRace.LapTime[11];
            race.LapTime13 = structRace.LapTime[12];
            race.LapTime14 = structRace.LapTime[13];
            race.LapTime15 = structRace.LapTime[14];
            race.LapTime16 = structRace.LapTime[15];
            race.LapTime17 = structRace.LapTime[16];
            race.LapTime18 = structRace.LapTime[17];
            race.LapTime19 = structRace.LapTime[18];
            race.LapTime20 = structRace.LapTime[19];
            race.LapTime21 = structRace.LapTime[20];
            race.LapTime22 = structRace.LapTime[21];
            race.LapTime23 = structRace.LapTime[22];
            race.LapTime24 = structRace.LapTime[23];
            race.LapTime25 = structRace.LapTime[24];
            race.SyogaiMileTime = structRace.SyogaiMileTime;
            race.HaronTimeS3 = structRace.HaronTimeS3;
            race.HaronTimeS4 = structRace.HaronTimeS4;
            race.HaronTimeL3 = structRace.HaronTimeL3;
            race.HaronTimeL4 = structRace.HaronTimeL4;
            race.Corner1 = structRace.CornerInfo[0].Corner;
            race.Syukaisu1 = structRace.CornerInfo[0].Syukaisu;
            race.Jyuni1 = structRace.CornerInfo[0].Jyuni;
            race.Corner2 = structRace.CornerInfo[1].Corner;
            race.Syukaisu2 = structRace.CornerInfo[1].Syukaisu;
            race.Jyuni2 = structRace.CornerInfo[1].Jyuni;
            race.Corner3 = structRace.CornerInfo[2].Corner;
            race.Syukaisu3 = structRace.CornerInfo[2].Syukaisu;
            race.Jyuni3 = structRace.CornerInfo[2].Jyuni;
            race.Corner4 = structRace.CornerInfo[3].Corner;
            race.Syukaisu4 = structRace.CornerInfo[3].Syukaisu;
            race.Jyuni4 = structRace.CornerInfo[3].Jyuni;
            race.RecordUpKubun = structRace.RecordUpKubun;

            _db.SaveChanges();
        }

        public void DeleteAll()
        {
            _db.Database.ExecuteSqlRaw("DELETE FROM Races");
        }
    }
}
