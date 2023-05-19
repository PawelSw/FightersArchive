using FightersArchive.Data.Entities;

namespace FightersArchive.Data.Repositories
{
    public class FighterRepository
    {
        public readonly List<Fighter> _fighters = new();

        public void Add(Fighter fighter)
        {
            fighter.Id = _fighters.Count + 1;
            _fighters.Add(fighter);
        }

        public void Save()
        {
            foreach (var fighter in _fighters)
            {
                Console.WriteLine(fighter);
            }

        }

        public Fighter GetById(int id)
        {
            return _fighters.Single(x => x.Id == id);
        }
    }
}
