using System.Xml.Serialization;

namespace dotnet_code_challenge.Model.Caulfield
{
    public class HorsePrice
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("Price")]
        public decimal Price { get; set; }
    }
}
