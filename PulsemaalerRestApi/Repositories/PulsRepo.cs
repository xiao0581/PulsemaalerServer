using PulsemaalerRestApi.Model;
using System.Xml.Linq;
using PulsemaalerRestApi.Controllers;

namespace PulsemaalerRestApi.Repositories
{
    public class PulsRepo
    {
        private int _nextId = 1;
        private static readonly List<Pulse> PulsList = new()
        {
            //dette skal forbindes med DB'en så pulslisten bliver lavet af pulser der bliver målt
        };

        public IEnumerable<Pulse> GetAll()
        {
            return PulsList;
        }

        public Pulse? GetById(int id)
        {
            return PulsList.Find(puls => puls.id == id);
        }

        public Pulse? AddPuls(Pulse newPuls)
        {
            newPuls.id = _nextId++;
            PulsList.Add(newPuls);
            return newPuls;
        }

        public Pulse? DeletePuls(int id)
        {
            Pulse? puls = GetById(id);
            if (puls == null)
            {
                return null;
            }
            PulsList.Remove(puls);
            return puls;
        }
    }
}
