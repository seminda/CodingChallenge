using System.Xml.Serialization;

namespace dotnet_code_challenge.Model.Caulfield
{
    public class Horse
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("number")]
        public int Number { get; set; }
    }
}
