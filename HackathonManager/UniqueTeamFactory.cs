using HackathonManager.PocoModels;
using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager
{
    public class UniqueTeamFactory
    {
        private int _pinNumber;
        public UniqueTeamFactory(IRepository repository)
        {
            _pinNumber = new PinGenerator(repository).GenerateNewPin(new Team());
        }

        public Team InstantiateUniquely()
        {
            return new Team() { PinNumber = _pinNumber };
        }
    }
}
