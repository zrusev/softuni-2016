namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelDistance { get; set; }

        [XmlArray("parts")]
        public PartIdDto[] PartsId { get; set; }
    }
}
