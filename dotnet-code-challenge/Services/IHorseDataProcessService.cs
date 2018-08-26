using System.Collections.Generic;
using dotnet_code_challenge.Common;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.Services
{
   public interface IHorseDataProcessService
    {
        List<HorseDetails> GetHorseData(SortOrder sortOrder);
    }
}
