using Library.Dtos;
using Newtonsoft.Json;

namespace Library
{
    public static class Helper
    {
        public async static Task<double>  GetCurrencyByCode(string code)
        {
            string baseUrl = @"https://nbg.gov.ge/gw/api/";
            string action = @"ct/monetarypolicy/currencies/ka/json";

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);

            var response = await httpClient.GetAsync(action);
            var responseContent = await response.Content.ReadAsStringAsync();
            var correctedResponseContent = responseContent.Substring(1, responseContent.Length - 2);
            var record = JsonConvert.DeserializeObject<RootDto>(correctedResponseContent);

            var currency = record.Currencies.FirstOrDefault(c => c.Code == code);
            return currency.Rate;
        }
    }
}
