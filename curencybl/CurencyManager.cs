using CurencyModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurencyBL
{
   
    public class CurencyManager
    {
        private static string apiUrl = "https://boi.org.il/PublicApi/GetExchangeRates";
        public CurencyList GetCurrencyList()
        {
            CurencyList list = new CurencyList();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send GET request synchronously
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as string
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Parse JSON response
                        JObject data = JObject.Parse(jsonResponse);

                        // Extract and process items
                        JArray itemsArray = (JArray)data["exchangeRates"];
                        foreach (JToken item in itemsArray)
                        {
                            Curency currency = new Curency()
                            {
                                Key = item["key"].ToString(),
                                Rate = double.Parse(item["currentExchangeRate"].ToString()),
                                Change = double.Parse(item["currentChange"].ToString()),
                                Unit = int.Parse(item["unit"].ToString())
                            };
                            list.Add(currency);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return null;
                }
                return list;
            }
        }

        public double Convert(Curency c1, Curency c2, double amount)
        {
            return (c1.Rate / c1.Unit) / (c2.Rate / c2.Unit)*amount; 
        }

    }
}
