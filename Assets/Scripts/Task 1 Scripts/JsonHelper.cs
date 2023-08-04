//P.S.: Used this script to parse nested JSON objects since it was not possible to do it with Unity's built-in JSON parser.
using System.Text.RegularExpressions;

public class JsonHelper
{
    public static string GetJsonObject(string jsonString, string handle)
    {
        string pattern = "\"" + handle + "\"\\s*:\\s*\\{";

        Regex regx = new Regex(pattern);

        Match match = regx.Match(jsonString);

        if (match.Success)
        {
            int bracketCount = 1;
            int i;
            int startOfObj = match.Index + match.Length;
            for (i = startOfObj; bracketCount > 0; i++)
            {
                if (jsonString[i] == '{')
                    bracketCount++;
                else if (jsonString[i] == '}')
                    bracketCount--;
            }
            return "{" + jsonString.Substring(startOfObj, i - startOfObj);
        }

        //no match, return null
        return null;
    }
}
