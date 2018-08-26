using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Common;
using dotnet_code_challenge.DataClients;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.Services
{
    public class HorseDataProcessService:IHorseDataProcessService
    {
        private readonly IWolferhamptonRaceClient _wolferhamptonRaceClient;
        private readonly ICaulfieldRaceClient _caulfieldRaceClient;
        public HorseDataProcessService(ICaulfieldRaceClient caulfieldRaceClient, IWolferhamptonRaceClient wolferhamptonRaceClient)
        {
            _caulfieldRaceClient = caulfieldRaceClient;
            _wolferhamptonRaceClient = wolferhamptonRaceClient;
        }
  
        public List<HorseDetails> GetHorseData(SortOrder sortOrder)
        {
            var data = _wolferhamptonRaceClient.GetRacesData();
            data.AddRange(_caulfieldRaceClient.GetRacesData());
            return sortOrder == SortOrder.Ascending ? data.OrderBy(s => s.Price).ToList() : data.OrderByDescending(s => s.Price).ToList();
        }
    }
}
