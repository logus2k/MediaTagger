namespace MediaTagger
{
    public static class StringExtensions
    {
        public static int CountLines(this string text)
        {
            int count = 0;

            if (!string.IsNullOrEmpty(text))
            {
                count = text.Length - text.Replace(Environment.NewLine, string.Empty).Length;

                // If the last char of the string is not a newline, 
                // make sure to count that line too.
                if (text[text.Length - 1] != Environment.NewLine)
                {
                    ++ count;
                }
            }

            return count;
        }
    }
}