using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Data.Entities
{
    public class Fighter : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Wins { get; set; }

        public int Lost { get; set; }

        public double Weight { get; set; }

        public bool Active { get; set; }

        public override string ToString() => $"Id:{Id,-2} Firstname: {FirstName,-9} Lastname: {LastName,-12} Wins:{Wins,-2} Lost:{Lost,-2} Weight:{Weight,6}kg  Active:{Active,-5}";
    }
}
