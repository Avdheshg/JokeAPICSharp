using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeAPI;


public class JokeAPI
{
    private static readonly HttpClient httpClient = new HttpClient();

    public async Task<JObject> GetJoke(string jokeUrl)
    {
        var joke = await httpClient.GetStringAsync(jokeUrl);
        return JObject.Parse(joke);
    }
    
    // for returning string
    /*public async Task<string> GetJoke(string jokeUrl)
    {
        var joke = await httpClient.GetStringAsync(jokeUrl);
        return joke;
    }*/
}

