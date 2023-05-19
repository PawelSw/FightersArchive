using FightersArchive.Data.Entities;
using FightersArchive.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Components.DataProviders
{
    public class FighterProvider : IFighterProvider
    {
        private readonly IRepository<Fighter> _repository;
        public FighterProvider(IRepository<Fighter> repository)
        {
            _repository = repository;
            
        }
        public List<Fighter> ActiveFighters()
        {
            var list = _repository.GetAll();
            var active  = list.Where(x => x.Active == true).ToList();
            return active;
        }

        public void DisplayActiveFighters()
        {
            var list = _repository.GetAll();
            var active = list.Where(x => x.Active == true).ToList();
            foreach ( var item in active ) 
            {
                Console.WriteLine(item);
            }          
        }

        public void DisplayAllFighters()
        {
            var list = _repository.GetAll();
            foreach ( var item in list )
                Console.WriteLine(item);
        }

        public void DisplayInActiveFighters()
        {
            var list = _repository.GetAll();
            var active = list.Where(x => x.Active == false).ToList();
            foreach (var item in active)
            {
                Console.WriteLine(item);
            }
        }

        public void DisplayMostWinsFighter()
        {
            var list = _repository.GetAll();
            var mostWinsFighter = list.OrderBy(x => x.Wins).Last();
            Console.WriteLine(mostWinsFighter);
        }

        public void DisplayMostLosesFighter()
        {
            var list = _repository.GetAll();
            var mostLostsFighter = list.OrderBy(x => x.Lost).Last();
            Console.WriteLine(mostLostsFighter);
        }

        public void DisplayHeavyWeightFigters()
        {
            var list = _repository.GetAll();
            var heavy = list.Where(x => x.Weight > 100).ToList();
            foreach (var item in heavy)
            {
                Console.WriteLine(item);
            }
        }
        public void DisplayLightWeightFigters()
        {
            var list = _repository.GetAll();
            var light = list.Where(x => x.Weight < 60).ToList();
            foreach (var item in light)
            {
                Console.WriteLine(item);
            }
        }

        public void DisplayFightersStartsWithMLetter(string prefix)
        {
            var list = _repository.GetAll();
            var startWithM = list.Where(x => x.FirstName.StartsWith(prefix)).ToList();
            foreach (var item in startWithM)
            {
                Console.WriteLine(item);
            }
        }
    }
}
