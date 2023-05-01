
using Newtonsoft.Json.Linq;

namespace JokeAPI;

public class Program
{

    /*
    Show choices
    Get ip from the user => string or num
    Find the value from enum according to the ip => get the value according to the number 
    add it to the url
    make the query
    */

    public static async Task Main(string[] args)
    {
        Program program = new Program();

        // develop a path string
        string jokeUrl = "https://v2.jokeapi.dev/joke/";
        string pathString = "", queryString = "", jokeType = "", searchString = "";

        program.ShowChoices<CategoriesEnum>();
        int userCategoryChoice = Convert.ToInt32(Console.ReadLine());

        if (userCategoryChoice == 2 )
        {
            program.ShowChoices<CustomCategoriesEnum>();
            userCategoryChoice = Convert.ToInt32(Console.ReadLine());
            pathString = ((CustomCategoriesEnum)userCategoryChoice).ToString();

        } else
        {
            pathString = "Any";
        }

        // ====== Query string ======

        // -- Blacklist Flags -- 
        program.ShowChoices<BlacklistFlagsEnum>();

        int userBlacklistFlagChoice = Convert.ToInt32(Console.ReadLine());

        if (userBlacklistFlagChoice != 6 )
        {
            queryString = $"?blacklistFlags={((BlacklistFlagsEnum)userBlacklistFlagChoice).ToString()}";
        }

        // -- Joke Type --
        program.ShowChoices<JokeTypeEnum>();
        int userJokeTypeChoice = Convert.ToInt32(Console.ReadLine());
        if (userJokeTypeChoice != 3 )
        {   
            jokeType = $"type={((JokeTypeEnum)userJokeTypeChoice).ToString()}";
            if (userBlacklistFlagChoice != 6 )
            {
                queryString += $"&{jokeType}";
            } else
            {
                queryString += $"?{jokeType}";
            }
        }

        // -- Joke Type --
        program.ShowChoices<EnableSearchEnum>();
        int userEnableSearchChoice = Convert.ToInt32(Console.ReadLine());
        if (userEnableSearchChoice != 2 )
        {
            searchString = Console.ReadLine();

            if (userBlacklistFlagChoice != 6 || userJokeTypeChoice != 3)
            {
                queryString += $"&contains={searchString}";
            } else
            {
                queryString += $"?contains={searchString}";
            }
        }

        // Joke URL
        jokeUrl = $"{jokeUrl}{pathString}{queryString}";
        Console.WriteLine($"Joke Url: {jokeUrl}");

        // making the API call
        JokeAPI jokeAPI = new JokeAPI();
        JObject joke = await jokeAPI.GetJoke(jokeUrl);
        Console.WriteLine($"Joke: {joke}");


        // CategoriesEnum categories = new CategoriesEnum();


    }

    public void ShowChoices<TEnum>() where TEnum : Enum
    {
        Console.WriteLine("Press: ");
        int i = 1;
        foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
        {
            Console.WriteLine($"{i++}. {enumValue}");
        }
        
    }

}

public enum CategoriesEnum
{
    Any = 1, 
    Custom
}

public enum CustomCategoriesEnum
{   
    Programming = 1,
    Miscellaneous, 
    Dark,
    Pun,
    Spooky,
    Christmas
}

public enum BlacklistFlagsEnum
{
    nsfw = 1,
    religious,
    political,
    racist, 
    sexist,
    none
}

public enum JokeTypeEnum
{
    single = 1,
    twopart,
    both
}

public enum EnableSearchEnum
{
    yes = 1,
    no
}












/*

string miscJokeUrl = "https://v2.jokeapi.dev/joke/Miscellaneous";
var miscJoke = jokeAPI.GetMiscJoke(miscJokeUrl);
Console.WriteLine($"Misc joke url : {miscJoke}");

== 2
string miscJokeUrl = "https://v2.jokeapi.dev/joke/Miscellaneous";
var miscJoke = await jokeAPI.GetMiscJoke(miscJokeUrl);
Console.WriteLine($"Misc joke url : {miscJoke}");

I know the op. How is the internal functioning.
In 2, after using await the program come back only after finishing the GetMiscJoke function. Then how it is async
 
*/



















