using FightersArchive.Components.CsvReader;
using FightersArchive.Components.DataProviders;
using FightersArchive.Data;
using FightersArchive.Data.Entities;
using FightersArchive.Data.Repositories;


namespace FightersArchive
{
    public class App : IApp
    {
        private readonly IRepository<Fighter> _repository;
        private readonly IFighterProvider _fighterProvider;
        private readonly ICsvReader _csvReader;
        private readonly FightersArchiveDbContext _dbContext;

        public App(IRepository<Fighter> repository, IFighterProvider fighterProvider, ICsvReader csvReader,
            FightersArchiveDbContext dbContext)
        {
            _repository = repository;
            _fighterProvider = fighterProvider;
            _csvReader = csvReader;
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }
        public static List<Fighter> GenerateSampleFighters()
        {
            return new List<Fighter>
            {
            new Fighter { FirstName = "Muhammad", LastName = "Ali", Wins = 55, Lost = 5, Active = false, Weight = 93},
            new Fighter { FirstName = "Richard", LastName = "Pryor", Wins = 41, Lost = 4, Active = false, Weight = 59},
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
        public void InsertDataFromCsvToDatabase()
        {
            var fighters = _csvReader.ProcessFighters("Resources\\Files\\boxers.csv");

            foreach (var fighter in fighters)
            {
                _dbContext.Add(new Data.Entities.Fighter()
                {
                    FirstName = fighter.FirstName,
                    LastName = fighter.LastName,
                    Wins = fighter.Wins,
                    Lost = fighter.Lost,
                    Weight = fighter.Weight,
                    Active = fighter.Active,
                });
            }

            _dbContext.SaveChanges();
        }

        public void DisplayAllFighters()
        {
            var allFighters = _dbContext.Fighters.ToList();
            foreach (var fighter in allFighters)
                Console.WriteLine(fighter);
        }

        public void Run()
        {

            //InsertDataFromCsvToDatabase();

      
            //var allfighters = GenerateSampleFighters();
            //AddFighters(allfighters);
            Console.WriteLine("All fighters:");
            DisplayAllFighters();
            //Console.WriteLine("Inactive fighters:");
            //_fighterProvider.DisplayInActiveFighters();
            //Console.WriteLine("Active fighters:");
            //_fighterProvider.DisplayActiveFighters();
            //Console.WriteLine("Most wins fighter:");
            //_fighterProvider.DisplayMostWinsFighter();
            //Console.WriteLine("Most losts fighter:");
            //_fighterProvider.DisplayMostLosesFighter();
            //Console.WriteLine("Heavyweight fighters:");
            //_fighterProvider.DisplayHeavyWeightFigters();
            //Console.WriteLine("Lightweight fighters:");
            //_fighterProvider.DisplayLightWeightFigters();
            //Console.WriteLine("Fighters with firstname starts with R:");
            //_fighterProvider.DisplayFightersStartsWithMLetter("R");
        }


    }
}
