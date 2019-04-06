namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportSuppliresDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsInporter { get; set; }
    }
}
