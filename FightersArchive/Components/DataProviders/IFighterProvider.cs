using FightersArchive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersArchive.Components.DataProviders
{
    public interface IFighterProvider
    {
        List<Fighter> ActiveFighters();
        List<Fighter> InActiveFighters();

        void DisplayInActiveFighters();
        void DisplayActiveFighters();


    }
}
