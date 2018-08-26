using System.Xml.Serialization;

namespace dotnet_code_challenge.Model.Caulfield
{
    public class Race
    {
        [XmlArray("horses")]
        [XmlArrayItem("horse")]
        public Horse[] Horses { get; set; }

        [XmlArray("prices")]
        [XmlArrayItem("price")]
        public Price[] Prices { get; set; }

    }
}
