using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 
namespace PokeInfo
{
    public class WebRequest
    {
        // The second parameter is a function that returns a Dictionary of string keys to object values.
        // If an API returned an array as its top level collection the parameter type would be "Action>"
        public static async Task GetPokemonDataAsync(int PokeId, Action<Pokemon> Callback)
        {
            // Create a temporary HttpClient connection.
            using (var Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // Read in the response as a string.
                     
                    // Then parse the result into JSON and convert to a dictionary that we can use.
                    // DeserializeObject will only parse the top level object, depending on the API we may need to dig deeper and continue deserializing
                    //Dictionary<string, object> JsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(StringResponse);
                    JObject obj = JObject.Parse(StringResponse);
                    JArray typeList = obj["types"].Value<JArray>();
                    List<string> types = new List<string>();

                    foreach(JObject i in typeList)
                    {
                        types.Add(i["type"]["name"].Value<string>());
                    }
                    //Dictionary<string, string> thing = JsonConvert.DeserializeObject<List<string> types>
                    // Finally, execute our callback, passing it the response we got.
                    Pokemon PokeData = new Pokemon{
                        Name = obj["name"].Value<string>(),
                        Weight = obj["weight"].Value<long>(),
                        Height = obj["height"].Value<long>(),
                        Types = types

                    };
                    Callback(PokeData);
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}