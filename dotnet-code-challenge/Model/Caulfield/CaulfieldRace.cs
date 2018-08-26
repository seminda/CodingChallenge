using System.Xml.Serialization;

namespace dotnet_code_challenge.Model.Caulfield
{
    [XmlRoot("meeting")]
    public class CaulfieldRace
    {
        [XmlElement("Meetingid")]
        public int MeetingId { get; set; }

        [XmlArray("races")]
        [XmlArrayItem("race")]
        public Race[] Races { get; set; }

    }
}
