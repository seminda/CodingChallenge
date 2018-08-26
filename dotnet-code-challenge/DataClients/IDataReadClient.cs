using System.Collections.Generic;

namespace dotnet_code_challenge.DataClients
{
    public interface IDataReadClient<TModel>
    {
        List<TModel> ReadXmlData(string filePrefix);
        List<TModel> ReadJsonData(string filePrefix);
    }
}
