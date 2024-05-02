namespace Library.Dtos
{
    //new comment added
    public class Currency
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("rateFormated")]
        public string RateFormated { get; set; }

        [JsonProperty("diffFormated")]
        public string DiffFormated { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("diff")]
        public double Diff { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("validFromDate")]
        public DateTime ValidFromDate { get; set; }
    }

    public class RootDto
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("currencies")]
        public List<Currency> Currencies { get; set; }
    }
}
