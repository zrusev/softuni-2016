namespace ProductShop.Dtos.Export
{
    using Newtonsoft.Json;

    public class ProductDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        //$"{p.Seller.FirstName} {p.Seller.LastName}"
        [JsonProperty(PropertyName = "seller")]
        public string Seller { get; set; }
    }
}
