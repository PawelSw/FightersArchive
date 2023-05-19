using FightersArchive.Components.CsvReader.Extensions;
using FightersArchive.Components.CsvReader.Models;


namespace FightersArchive.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Fighter> ProcessFighters(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Fighter>();
            }

            var fighters =
                File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToFighter();

            return fighters.ToList();
        }
    }
}
