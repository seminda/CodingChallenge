using System.Collections.Generic;
using dotnet_code_challenge.DataClients;
using dotnet_code_challenge.Model.Caulfield;
using NSubstitute;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class CaulfieldRaceClientTest
    {
        private readonly IDataReadClient<CaulfieldRace> _dataClient;
        private ICaulfieldRaceClient _caulfieldRaceClient;
        public CaulfieldRaceClientTest()
        {
            _dataClient = Substitute.For<IDataReadClient<CaulfieldRace>>();
            _caulfieldRaceClient = new CaulfieldRaceClient(_dataClient);
        }

        [Fact]
        public void ReadCaulfieldRace_Withfile_Sucess()
        {
            //Arrange
            _dataClient.ReadXmlData(Arg.Any<string>()).Returns(RaceResponse());

            //Act
            var caulfieldRaceData = _caulfieldRaceClient.GetRacesData();

            //Assert
            Assert.NotNull(caulfieldRaceData);
            Assert.Single(caulfieldRaceData);
            Assert.Equal(1, caulfieldRaceData[0].Id);
            Assert.Equal("Test Horse 1", caulfieldRaceData[0].Name);
            Assert.Equal(4.2m, caulfieldRaceData[0].Price);

        }

        [Fact]
        public void ReadCaulfieldRace_Nofiles_Sucess()
        {
            //Arrange
            _dataClient.ReadXmlData(Arg.Any<string>()).Returns(new List<CaulfieldRace>());

            //Act
            var caulfieldRaceData = _caulfieldRaceClient.GetRacesData();

            //Assert
            Assert.NotNull(caulfieldRaceData);
            Assert.Empty(caulfieldRaceData);

        }

        private List<CaulfieldRace> RaceResponse()
        {
            var data = new List<CaulfieldRace>
            {
                new CaulfieldRace
                {
                    MeetingId=1,
                    Races=new Race[]
                    {
                        new Race
                        {
                            Horses=new Horse[]
                            {
                                new Horse()
                                {
                                    Number=1,
                                    Name = "Test Horse 1"
                                }
                            },
                            Prices=new Price[]
                            {
                                new Price
                                {
                                    Horses = new HorsePrice[]
                                    {
                                        new HorsePrice
                                        {
                                            Number = 1,
                                            Price= 4.2m
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
