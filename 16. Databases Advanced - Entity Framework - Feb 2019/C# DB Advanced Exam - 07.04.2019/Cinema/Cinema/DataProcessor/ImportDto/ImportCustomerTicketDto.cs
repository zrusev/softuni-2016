namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomerTicketDto
    {
        //<Customer>
        //  <FirstName>Randi</FirstName>
        //  <LastName>Ferraraccio</LastName>
        //  <Age>20</Age>
        //  <Balance>59.44</Balance>
        //  <Tickets>
        //    <Ticket>
        //      <ProjectionId>1</ProjectionId>
        //      <Price>7</Price>
        //    </Ticket>
        //</Customer>

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Range(12, 110)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Balance")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public PartTicketDto[] Tickets { get; set; }
    }
}
