using System.Xml.Serialization;

namespace dotnet_code_challenge.Model.Caulfield
{
    public class Price
    {
        [XmlElement("priceType")]
        public string PriceType { get; set; }

        [XmlArray("horses")]
        [XmlArrayItem("horse")]
        public HorsePrice[] Horses { get; set; }
    }
}
