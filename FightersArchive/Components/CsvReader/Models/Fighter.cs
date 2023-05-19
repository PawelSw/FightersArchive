namespace FightersArchive.Components.CsvReader.Models
{
    public class Fighter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public int Lost { get; set; }
        public double Weight { get; set; }
        public bool Active { get; set; }
    }
}
