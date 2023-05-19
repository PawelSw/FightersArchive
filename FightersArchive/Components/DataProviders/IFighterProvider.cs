namespace FightersArchive.Components.DataProviders
{
    public interface IFighterProvider
    {
  
        void DisplayAllFighters();
        void DisplayInActiveFighters();
        void DisplayActiveFighters();
        void DisplayMostWinsFighter();
        void DisplayMostLosesFighter();
        void DisplayHeavyWeightFigters();
        void DisplayLightWeightFigters();
        void DisplayFightersStartsWithMLetter(string prefix);


    }
}
