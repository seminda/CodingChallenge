using dotnet_code_challenge.DataClients;
using dotnet_code_challenge.Model.Caulfield;
using dotnet_code_challenge.Model.Wolferhampton;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class DataReadClientTest
    {
        [Fact]
        public void ReadXmlData_Sucess()
        {
            IDataReadClient<CaulfieldRace> dataReadClient = new DataReadClient<CaulfieldRace>();

            var data = dataReadClient.ReadXmlData("Caulfield_");

            Assert.NotNull(data);
        }

        [Fact]
        public void ReadJsonData_Sucess()
        {
            IDataReadClient<WolferhamptonRace> dataReadClient = new DataReadClient<WolferhamptonRace>();

            var data = dataReadClient.ReadJsonData("Wolferhampton_");

            Assert.NotNull(data);
        }
    }
}
