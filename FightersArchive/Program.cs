
using FightersArchive;
using FightersArchive.Components.CsvReader;
using FightersArchive.Components.DataProviders;
using FightersArchive.Data;
using FightersArchive.Data.Entities;
using FightersArchive.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IRepository<Fighter>, ListRepository<Fighter>>();
services.AddSingleton<IFighterProvider, FighterProvider>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<FightersArchiveDbContext>(options => options
       .UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = FightersArchiveAppStorage; Integrated Security = True;Encrypt=False;" +
       "TrustServerCertificate=True;MultipleActiveResultSets=True"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();
 
