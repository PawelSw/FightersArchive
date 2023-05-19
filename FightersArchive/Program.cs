
using FightersArchive;
using FightersArchive.Components.CsvReader;
using FightersArchive.Components.DataProviders;
using FightersArchive.Data.Entities;
using FightersArchive.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IRepository<Fighter>, ListRepository<Fighter>>();
services.AddSingleton<IFighterProvider, FighterProvider>();
services.AddSingleton<ICsvReader, CsvReader>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();
 
//using FightersArchive.Data;
//using FightersArchive.Entities;
//using FightersArchive.Repositories;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
        //var repository = new GenericRepository<Fighter>();
        //repository.Add(new Fighter { FirstName = "Mike", LastName = "Tyson", Wins = 50, Lost = 8, Weight = 105, Active = false });
        //repository.Add(new Fighter {  FirstName = "Lennox", LastName = "Lewis", Wins = 44, Lost = 2, Weight = 115, Active = false });
        //Fighter Holy = new Fighter { FirstName = "Evander", LastName = "Holyfield", Wins = 55, Lost = 12, Weight = 104, Active = false };
        //repository.Add(Holy);
        //Fighter TommyGun = new Fighter { FirstName = "Tommy", LastName = "Morrison", Wins = 44, Lost = 12, Weight = 114, Active = false };
        //repository.Add(TommyGun);
        //repository.Remove(Holy);



        //var genericRepoWithRemove = new GenericRepositoryWithRemove<Fighter>();
        //genericRepoWithRemove.Add(new Fighter { FirstName = "Tyson", LastName = "Fury", Wins = 33, Lost = 0, Weight = 125, Active = true });
        //genericRepoWithRemove.Add(new Fighter { FirstName = "Deontay", LastName = "Wilder", Wins = 43, Lost = 3, Weight = 95, Active = true });

        //Fighter Anthony = new Fighter { FirstName = "Anthony", LastName = "Joshua", Wins = 30, Lost = 2, Weight = 125, Active = true };
        //genericRepoWithRemove.Add(Anthony);

        //genericRepoWithRemove.Remove(Anthony);
        //genericRepoWithRemove.Add(Anthony);
        //genericRepoWithRemove.Save();

        //var sqlRepository = new SqlRepository<Fighter>(new FightersArchiveDbContext());
        //Fighter Holy = new Fighter { FirstName = "Evander", LastName = "Holyfield", Wins = 55, Lost = 12, Weight = 104, Active = false };
        //sqlRepository.Add(Holy);
        //Fighter TommyGun = new Fighter { FirstName = "Tommy", LastName = "Morrison", Wins = 44, Lost = 12, Weight = 114, Active = false };
        //sqlRepository.Add(TommyGun);
        //Fighter Anthony = new Fighter { FirstName = "Anthony", LastName = "Joshua", Wins = 30, Lost = 2, Weight = 125, Active = true };
        //sqlRepository.Add(Anthony);
        //sqlRepository.Save();
        //sqlRepository.Display();
  


//    }
//}