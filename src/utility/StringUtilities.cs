namespace MediaTagger
{
    public static class StringUtilities
    {
        public static int CountLines(this string text)
        {
            int count = 0;

            if (!string.IsNullOrEmpty(text))
            {
                count = text.Length - text.Replace(Environment.NewLine, string.Empty).Length;

                // Also count the last char of the string if it is not a newline
                if (!text[^1].Equals(Environment.NewLine))
                {
                    ++ count;
                }
            }

            return count;
        }

        public static string StringFromList(List<string> list)
        {
            string output = string.Empty;

            Console.WriteLine("List count: " + list.Count.ToString());

            for (int n = 0; n < list.Count; n++)
            {
                output += list[n];
                
                if (n < list.Count)
                {
                    output += Environment.NewLine;
                }
            }

            return output;
        }

        public static List<string> ListFromString(string text)
        {
            return text.Split(Environment.NewLine).ToList();
        }
    }
}
