using System.Text.RegularExpressions;

namespace MediaTagger
{
    public class RegExEngine
    {
        public static string Replace(string text, string? pattern, string? substitute)
        {
            string output = string.Empty;

            // string input = string.Join(Environment.NewLine, text);

            if (pattern != null)
            {
                Regex regex = new(pattern, RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);

                MatchCollection matches = regex.Matches(text);

                string result;

                foreach (Match match in matches)
                {
                    if (substitute != null)
                    {
                        result = match.Result(substitute);
                    }
                    else
                    {
                        result = match.Value;
                    }

                    output += result;
                }
            }

            output = output.Replace("\r", Environment.NewLine);

            return output;
        }
    }
}