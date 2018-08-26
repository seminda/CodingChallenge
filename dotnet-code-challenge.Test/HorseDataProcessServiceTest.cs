using System.Collections.Generic;
using dotnet_code_challenge.Common;
using dotnet_code_challenge.DataClients;
using dotnet_code_challenge.Model;
using dotnet_code_challenge.Services;
using NSubstitute;
using Xunit;

namespace dotnet_code_challenge.Test
{
   public class HorseDataProcessServiceTest
    {
        private readonly IWolferhamptonRaceClient _wolferhamptonRaceClient;
        private readonly ICaulfieldRaceClient _caulfieldRaceClient;
        private readonly IHorseDataProcessService _service;
        public HorseDataProcessServiceTest()
        {
            _caulfieldRaceClient = Substitute.For<ICaulfieldRaceClient>();
            _wolferhamptonRaceClient = Substitute.For<IWolferhamptonRaceClient>();
            _service = new HorseDataProcessService(_caulfieldRaceClient, _wolferhamptonRaceClient);
        }

        [Fact]
        public void ReadBothRaceRaces_Withfile_Sucess()
        {
            //Arrange
            _caulfieldRaceClient.GetRacesData().Returns(CaulfieldRaceResponse());
            _wolferhamptonRaceClient.GetRacesData().Returns(WolferhamptonResponse());

            //Act
            var raceData = _service.GetHorseData(SortOrder.Ascending);

            //Assert
            Assert.NotNull(raceData);
            Assert.Equal(4, raceData.Count);
            Assert.Equal("Wolferhampton 1", raceData[0].Name);
            Assert.Equal("Caulfield 1", raceData[1].Name);
            Assert.Equal("Wolferhampton 2", raceData[2].Name);
            Assert.Equal("Caulfield 2", raceData[3].Name);

        }

        [Fact]
        public void ReadBothRaceRaces_OnlyCaulfieldRaceDataavailable_Sucess()
        {
            //Arrange
            _caulfieldRaceClient.GetRacesData().Returns(CaulfieldRaceResponse());
            _wolferhamptonRaceClient.GetRacesData().Returns(new List<HorseDetails>());

            //Act
            var raceData = _service.GetHorseData(SortOrder.Ascending);

            //Assert
            Assert.NotNull(raceData);
            Assert.Equal(2, raceData.Count);
            Assert.Equal("Caulfield 1", raceData[0].Name);
            Assert.Equal("Caulfield 2", raceData[1].Name);

        }

        [Fact]
        public void ReadBothRaceRaces_Nofiles_Sucess()
        {
            //Arrange
            _caulfieldRaceClient.GetRacesData().Returns(new List<HorseDetails>());
            _wolferhamptonRaceClient.GetRacesData().Returns(new List<HorseDetails>());

            //Act
            var raceData = _service.GetHorseData(SortOrder.Ascending);

            //Assert
            Assert.NotNull(raceData);
            Assert.Empty(raceData);

        }

        private static List<HorseDetails> CaulfieldRaceResponse()
        {
            return new List<HorseDetails>
            {
                new HorseDetails
                {
                    Price = 4.2m,
                    Id = 1,
                    Name = "Caulfield 1"
                },
                new HorseDetails
                {
                    Price = 12.4m,
                    Id = 1,
                    Name = "Caulfield 2"
                }
            };
        }

        private List<HorseDetails> WolferhamptonResponse()
        {
            return new List<HorseDetails>
            {
                new HorseDetails
                {
                    Price = 4.1m,
                    Id = 1,
                    Name = "Wolferhampton 1"
                },
                new HorseDetails
                {
                    Price = 12.1m,
                    Id = 1,
                    Name = "Wolferhampton 2"
                }
            };
        }
    }
}
