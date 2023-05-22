using FightersArchive.Components.CsvReader;
using FightersArchive.Components.DataProviders;
using FightersArchive.Data;
using FightersArchive.Data.Entities;
using FightersArchive.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
        private void DisplayMostWinsFighter()
        {
            var mostWinFighter = _dbContext.Fighters.OrderBy(x => x.Wins).Last();
            Console.WriteLine("Most wins fighter:");
            Console.WriteLine(mostWinFighter);
        }
        private void DisplayHeavyWeightFigters()
        {
            var heavyWeightFighters = _dbContext.Fighters.Where(x => x.Weight >= 100);
            Console.WriteLine("Heavyweight fighters:");

            foreach (var heavyWeighFighter in heavyWeightFighters)
            {
                Console.WriteLine(heavyWeighFighter);
            }
        }
        private void DisplayLightWeightFigters()
        {
            var lightWeightFighters = _dbContext.Fighters.Where(x => x.Weight <= 60);
            Console.WriteLine("Lightweight fighters:");

            foreach (var lightWeighFighter in lightWeightFighters)
            {
                Console.WriteLine(lightWeighFighter);
            }
        }
        private void DisplayMostLostsFighter()
        {
            var mostLostFighter = _dbContext.Fighters.OrderBy(x => x.Lost).Last();
            Console.WriteLine("Most losts fighter:");
            Console.WriteLine(mostLostFighter);
        }
        private void DisplayActiveFighters()
        {
            var activeFighters = _dbContext.Fighters.Where(x => x.Active == true).ToList();
            Console.WriteLine("Active fighters:");

            foreach (var activeFighter in activeFighters)
            {
                Console.WriteLine(activeFighter);
            }
        }
        private void DisplayInactiveFighters()
        {
            var inactiveFighters = _dbContext.Fighters.Where(x => x.Active == false).ToList();
            Console.WriteLine("Inactive fighters:");

            foreach (var inactiveFighter in inactiveFighters)
            {
                Console.WriteLine(inactiveFighter);
            }
        }
        private Fighter? ReadFirst(string name)
        {
            return _dbContext.Fighters.FirstOrDefault(x => x.FirstName == name);
        }

        private void DeleteChosenFighter()
        {
            Console.WriteLine("Type the name of the fighter to delete:");
            var inputUser = Console.ReadLine();
            var fighterChosen = this.ReadFirst(inputUser);

            try
            {
                _dbContext.Fighters.Remove(fighterChosen);
                _dbContext.SaveChanges();
                Console.WriteLine("Fighter deleted succesfully.");
            }
            catch
            {
                Console.WriteLine("The name does not exist, try again.");
            }
        }
        private void UpdateNameOfChosenFighter()
        {
            var updatedFighter = new Fighter();
            Console.WriteLine("Type the name of the fighter to update:");
            string inputUser = Console.ReadLine();
            if (inputUser.Length > 0)
            {

                updatedFighter = this.ReadFirst(inputUser);
                if(updatedFighter == null) 
                {
                    Console.WriteLine("Fighter does not exist, try again.");
                }
                else
                {
                    Console.WriteLine(updatedFighter);
                    Console.WriteLine("Type new name of chosen fighter to update:");
                    var newName = Console.ReadLine();
                    updatedFighter.FirstName = newName;
                    _dbContext.SaveChanges();
                    Console.WriteLine($"Name was updated successfully to: {updatedFighter.FirstName}.");
                }
            }
            else
            {
                Console.WriteLine("Name can not be empty.");
            }
        }

        private void CreateNewFighter()
        {
            Console.WriteLine("Type the Firstname of the new fighter:");
            var newFighter = new Fighter();
        goBackToFirstName:
            string newFirstName = Console.ReadLine();

            while (true)
            {

                if (newFirstName.Length <= 0)
                {
                    Console.WriteLine("Field Firstname can not be empty,try again.");
                    goto goBackToFirstName;

                }
                else
                {
                    newFighter.FirstName = newFirstName;
                    _dbContext.Add(newFighter);
                    break;
                }
            }



            Console.WriteLine("Type the Lastname of the new fighter:");
        goBackToLastName:
            string newLastName = Console.ReadLine();

            while (true)
            {
                if (newLastName.Length <= 0)
                {
                    Console.WriteLine("Field LastName can not be empty,try again.");
                    goto goBackToLastName;
                }
                else
                {
                    newFighter.LastName = newLastName;
                    _dbContext.Add(newFighter);
                    break;
                }
            }


            while (true)
            {
                Console.WriteLine("Type the number of wins:");
                var wins = Console.ReadLine();

                try
                {
                    int winsfromstring = int.Parse(wins);
                    if (winsfromstring >= 0)
                    {
                        newFighter.Wins = winsfromstring;
                        _dbContext.Add(newFighter);
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Number of wins must be greater or equal 0.");
                    };
                }

                catch (Exception)
                {
                    Console.WriteLine("Number of wins must be a digit.");
                }
            }

            while (true)
            {
                Console.WriteLine("Type the number of loses:");
                var loses = Console.ReadLine();

                try
                {

                    int losesfromstring = int.Parse(loses);
                    if (losesfromstring >= 0)
                    {
                        newFighter.Lost = losesfromstring;
                        _dbContext.Add(newFighter);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Number of loses must be greater or equal 0.");
                    };
                }

                catch
                {
                    Console.WriteLine("Number of loses must be a digit.");
                }

            }

            while (true)
            {
                Console.WriteLine("Type the weight:");
                var weight = Console.ReadLine();

                try
                {

                    int weightFromString = int.Parse(weight);
                    if (weightFromString >= 0)
                    {
                        newFighter.Lost = weightFromString;
                        _dbContext.Add(newFighter);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Weight must be greater then 0.");
                    };
                }

                catch (Exception)
                {
                    Console.WriteLine("Weight must be a digit.");
                }

            }
            while (true)
            {
                Console.WriteLine("Type the True or False for active status:");
                var status = Console.ReadLine();

                try
                {
                    bool statusfromString = bool.Parse(status);
                    newFighter.Active = statusfromString;
                    _dbContext.Add(newFighter);
                    _dbContext.SaveChanges();
                    break;
                }

                catch (Exception)
                {
                    Console.WriteLine("Please type only True or False for status.");
                }

            }

            Console.WriteLine($"Fighter : {newFighter.FirstName} {newFighter.LastName} was added successfully!");
        }

        public void Run()
        {
            //InsertDataFromCsvToDatabase();
            bool CloseApp = false;

            while (!CloseApp)
            {
                Console.WriteLine(
                    "|-----------Menu------------|\n" +
                    "1 - Display all fighters\n" +
                    "2 - Display most wins fighter\n" +
                    "3 - Display HeavyWeight fighters\n" +
                    "4 - Display LightWeight fighters\n" +
                    "5 - Display most losts fighter\n" +
                    "6 - Delete the chosen Fighter\n" +
                    "7 - Update the name of chosen fighter\n" +
                    "8 - Display active fighters\n" +
                    "9 - Display inactive fighters\n" +
                    "10 - Create new fighter\n" +
                    "X - Close app\n");

                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        DisplayAllFighters();
                        break;

                    case "2":
                        DisplayMostWinsFighter();
                        break;

                    case "3":
                        DisplayHeavyWeightFigters();
                        break;

                    case "4":
                        DisplayLightWeightFigters();
                        break;

                    case "5":
                        DisplayMostLostsFighter();
                        break;

                    case "6":
                        DeleteChosenFighter();
                        break;

                    case "7":
                        UpdateNameOfChosenFighter();
                        break;

                    case "8":
                        DisplayActiveFighters();
                        break;

                    case "9":
                        DisplayInactiveFighters();
                        break;

                    case "10":
                        CreateNewFighter();
                        break;

                    case "X":
                        CloseApp = true;
                        break;

                    default:
                        System.Console.WriteLine("Invalid operation.\n");
                        continue;
                }
            }
        }
    }
}
