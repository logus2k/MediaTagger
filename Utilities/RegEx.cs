using System.Text.RegularExpressions;

namespace MediaTagger
{
    public class RegExHelper
    {
        public static List<string> Replace(List<string> input, string pattern, string substitute)
        {
            List<string> outcome = new();

            foreach (Match match in Regex.Matches(input, pattern))
            {
                string result = match.Result(substitute);

                if (result.Length > 0 && !result.Equals(" - "))
                {
                    Console.WriteLine(string.Concat(result.AsSpan(0, 2), " - ", result.AsSpan(2)));
                }
            }

            return outcome;
        }
    }
}