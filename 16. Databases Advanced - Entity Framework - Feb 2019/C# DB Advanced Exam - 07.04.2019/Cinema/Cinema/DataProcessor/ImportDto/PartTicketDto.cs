namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class PartTicketDto
    {
        [Required]
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }


        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
