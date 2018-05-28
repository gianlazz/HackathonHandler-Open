using HackathonManager.PocoModels;
using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager
{
    class PinGenerator
    {
        private readonly IRepository _Db;
        private readonly Random _random = new Random();

        public PinGenerator(IRepository db)
        {
            _Db = db;
        }

        //SHOULD GET TEST COVERAGE FOR THIS!
        public int Generate(Team team, int length = 4)
        {
            int proposedPin;
            do
            {
                proposedPin = GenerateRandomNo(length);
            } while (_Db.All<Team>().Where(x => x.PinNumber == proposedPin).Any());

            return proposedPin;
        }

        private int GenerateRandomNo(int length)
        {
            string maxString = string.Empty;
            for (int i = 0; i < length; i++)
            {
                maxString += "9";
            }

            int max = int.Parse(maxString);
            return int.Parse(_random.Next(0, max).ToString("D4"));
        }

        //public int GenerateRandomNo()
        //{
        //    int _min = 1000;
        //    int _max = 9999;
        //    Random _rdm = new Random();
        //    return _rdm.Next(_min, _max);
        //}

    }
}
