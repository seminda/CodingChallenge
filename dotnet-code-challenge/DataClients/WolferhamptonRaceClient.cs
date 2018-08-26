using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Model;
using dotnet_code_challenge.Model.Wolferhampton;

namespace dotnet_code_challenge.DataClients
{
   public class WolferhamptonRaceClient: IWolferhamptonRaceClient
    {
        private readonly IDataReadClient<WolferhamptonRace> _dataClient;

        public WolferhamptonRaceClient(IDataReadClient<WolferhamptonRace> dataClient)
        {
            _dataClient = dataClient;
        }

        public List<HorseDetails> GetRacesData()
        {
            return MapData(_dataClient.ReadJsonData("Wolferhampton_"));
        }

        private static List<HorseDetails> MapData(IEnumerable<WolferhamptonRace> races)
        {
            var data = new List<HorseDetails>();
            foreach (var race in races)
            {
                foreach (var market in race.RawData.Markets)
                {
                    data.AddRange(market.Selections.Select(s =>
                        new HorseDetails { Name = s.Tags.Name, Id = s.Tags.Participant, Price = s.Price }));
                }
            }

            return data;
        }
    }
}
