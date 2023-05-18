using FightersArchive.Entities;
using FightersArchive.Repositories;


namespace FightersArchive.Components.DataProviders
{
    public class FighterProviderBasic : IFighterProvider
    {
        private readonly IRepository<Fighter> _repository;
        public FighterProviderBasic(IRepository<Fighter> repository) 
        {
            _repository = repository;
        }
        public List<Fighter> ActiveFighters()
        {
            var allFighters = _repository.GetAll();
            List<Fighter> fighters = new List<Fighter>();
            foreach (var fighter in allFighters)
            {
               if(fighter.Active == true)
                {
                    fighters.Add(fighter);
                }
            }

            return fighters;

        }

        public List<Fighter> InActiveFighters()
        {
            var allFighters = _repository.GetAll();
            List<Fighter> fighters = new List<Fighter>();
            foreach (var fighter in allFighters)
            {
                if (fighter.Active == false)
                {
                    fighters.Add(fighter);
                }
            }

            return fighters;
        }
        public void DisplayInActiveFighters()
        {
            var allFighters = _repository.GetAll();
            List<Fighter> fighters = new List<Fighter>();
            foreach (var fighter in allFighters)
            {
                if (fighter.Active == false)
                {
                    fighters.Add(fighter);
                }
            }

            foreach (var fighter in fighters)
                Console.WriteLine(fighter);
        }

        public void DisplayActiveFighters()
        {
            var allFighters = _repository.GetAll();
            List<Fighter> fighters = new List<Fighter>();
            foreach (var fighter in allFighters)
            {
                if (fighter.Active == true)
                {
                    fighters.Add(fighter);
                }
            }

            foreach (var fighter in fighters)
                Console.WriteLine(fighter);
        }


    }
}
