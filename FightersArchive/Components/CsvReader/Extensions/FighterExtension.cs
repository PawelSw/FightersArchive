using FightersArchive.Components.CsvReader.Models;
using System.Globalization;

namespace FightersArchive.Components.CsvReader.Extensions
{
    public static class FighterExtension
    {
        public static IEnumerable<Fighter> ToFighter(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Fighter
                {

                    FirstName = columns[0],
                    LastName = columns[1],
                    Wins = int.Parse(columns[2], CultureInfo.InvariantCulture),
                    Lost = int.Parse(columns[3], CultureInfo.InvariantCulture),
                    Weight = double.Parse(columns[4], CultureInfo.InvariantCulture),
                    Active = bool.Parse(columns[5])

                };
            }
        }
    }
}
