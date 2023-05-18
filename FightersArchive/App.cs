using FightersArchive.Components.DataProviders;
using FightersArchive.Entities;
using FightersArchive.Repositories;


namespace FightersArchive
{
    public class App : IApp
    {
        private readonly IRepository<Fighter> _repository;
        private readonly IFighterProvider _fighterProvider;
        public App(IRepository<Fighter> repository, IFighterProvider fighterProvider)
        {
            _repository = repository;
            _fighterProvider = fighterProvider;
        }
        public static List<Fighter> GenerateSampleFighters()
        {
            return new List<Fighter>
            {
            new Fighter { FirstName = "Muhammad", LastName = "Ali", Wins = 55, Lost = 5, Active = false, Weight = 93},
            new Fighter { FirstName = "Tyson", LastName = "Fury", Wins = 31, Lost = 0, Active = true, Weight = 126},
            new Fighter { FirstName = "Mike", LastName = "Tyson", Wins = 55, Lost = 8, Active = false, Weight = 96},
            new Fighter { FirstName = "Deontay", LastName = "Wilder", Wins = 41, Lost = 3, Active = true, Weight = 91},
            };
        }
        public void AddFighters(IEnumerable<Fighter> fighters)
        {
            foreach (var fighter in fighters)
            {
                _repository.Add(fighter);
            }
        }

        public void Run()
        {
            Console.WriteLine("I am here in Run metod");

            var allfighters = GenerateSampleFighters();
            AddFighters(allfighters);
            Console.WriteLine("Inactive fighters:");
            _fighterProvider.DisplayInActiveFighters();
            Console.WriteLine("Active fighters:");
            _fighterProvider.DisplayActiveFighters();
           


        }


    }
}
