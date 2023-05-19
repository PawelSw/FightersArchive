using FightersArchive.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Fighter> ProcessFighters(string filePath);
    }
}
