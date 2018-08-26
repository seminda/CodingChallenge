using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Model;
using dotnet_code_challenge.Model.Caulfield;

namespace dotnet_code_challenge.DataClients
{
   public class CaulfieldRaceClient:ICaulfieldRaceClient
    {
        private readonly IDataReadClient<CaulfieldRace> _dataClient;
        public CaulfieldRaceClient(IDataReadClient<CaulfieldRace> dataClient)
        {
            _dataClient = dataClient;
        }
        public List<HorseDetails> GetRacesData()
        {
            return MapData(_dataClient.ReadXmlData("Caulfield_"));
        }

        private static List<HorseDetails> MapData(IEnumerable<CaulfieldRace> races)
        {
            var data = new List<HorseDetails>();
            foreach (var caulfieldRace in races)
            {
                data.AddRange(from race in caulfieldRace.Races
                    from horse in race.Horses
                    from price in race.Prices
                    from priceHorse in price.Horses
                    where priceHorse.Number == horse.Number
                    select new HorseDetails
                    {
                        Price = priceHorse.Price,
                        Id = priceHorse.Number,
                        Name = horse.Name
                    });
            }

            return data;
        }
    }
}
