using System.Collections.Generic;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.DataClients
{
    public interface ICaulfieldRaceClient
    {
        List<HorseDetails> GetRacesData();
    }
}
