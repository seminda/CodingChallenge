using System.Collections.Generic;
using dotnet_code_challenge.DataClients;
using dotnet_code_challenge.Model.Wolferhampton;
using NSubstitute;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class WolferhamptonRaceClientTest
    {
        private readonly IDataReadClient<WolferhamptonRace> _dataClient;
        private IWolferhamptonRaceClient _wolferhamptonRaceClient;

        public WolferhamptonRaceClientTest()
        {
            _dataClient = Substitute.For<IDataReadClient<WolferhamptonRace>>();
            _wolferhamptonRaceClient = new WolferhamptonRaceClient(_dataClient);
        }

        [Fact]
        public void ReadWolferhamptonRace_Withfile_Sucess()
        {
            //Arrange
            _dataClient.ReadJsonData(Arg.Any<string>()).Returns(RaceResponse());

            //Act
            var raceData = _wolferhamptonRaceClient.GetRacesData();

            //Assert
            Assert.NotNull(raceData);
            Assert.Single(raceData);
            Assert.Equal(1, raceData[0].Id);
            Assert.Equal("Test Horse 1", raceData[0].Name);
            Assert.Equal(5.6m, raceData[0].Price);

        }

        [Fact]
        public void ReadWolferhamptonRace_Nofiles_Sucess()
        {
            //Arrange
            _dataClient.ReadJsonData(Arg.Any<string>()).Returns(new List<WolferhamptonRace>());

            //Act
            var raceData = _wolferhamptonRaceClient.GetRacesData();

            //Assert
            Assert.NotNull(raceData);
            Assert.Empty(raceData);

        }

        private static List<WolferhamptonRace> RaceResponse()
        {
            var data = new List<WolferhamptonRace>
            {
                new WolferhamptonRace
                {
                   RawData=new RawData
                   {
                       Markets=new List<Market>
                       {
                           new Market
                           {
                               Selections = new List<Selection>
                               {
                                   new Selection
                                   {
                                       Price=5.6m,
                                       Id="abc1234",
                                       Tags=new Tag
                                       {
                                           Name="Test Horse 1",
                                           Participant= 1
                                       }
                                   }
                               }
                           }
                       }
                   }
                }
            };


            return data;
        }
    }
}