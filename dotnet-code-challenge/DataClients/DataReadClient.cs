using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace dotnet_code_challenge.DataClients
{
    public class DataReadClient<TModel>:IDataReadClient<TModel>
    {
        public List<TModel> ReadXmlData(string filePrefix)
        {
            var files = GetAllFiles(filePrefix, "xml");
            if (files == null) throw new IOException("data couldn't find");
            var data = new List<TModel>();
            foreach (var path in files)
            {
                var serializer = new XmlSerializer(typeof(TModel));
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    data.Add((TModel)serializer.Deserialize(fileStream));
                }
            }
            return data;
        }

        public List<TModel> ReadJsonData(string filePrefix)
        {
            var files = GetAllFiles(filePrefix, "json");
            if (files == null) throw new IOException("data couldn't find");
            var data = new List<TModel>();
            foreach (var path in files)
            {
                var fileData = File.ReadAllText(path);
                data.Add(JsonConvert.DeserializeObject<TModel>(fileData));
            }
            return data;
        }

        private static List<string> GetAllFiles(string filePrefix, string fileExtention)
        {
            var files = new List<string>();
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo == null) return files;

            var path = Path.Combine(Directory.GetParent(directoryInfo.FullName).FullName, "FeedData");
            var folder = new DirectoryInfo(path);
            var filesInDir = folder.GetFiles($"{filePrefix}*.{fileExtention}");

            files.AddRange(filesInDir.Select(foundFile => foundFile.FullName));
            return files;
        }
    }
}
