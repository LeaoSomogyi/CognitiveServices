namespace CognitiveServices.Web.Extensions
{
    /// <summary>
    /// Usefull String Helpers
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Return the string with first letter ToUpper
        /// </summary>
        /// <param name="value">any string</param>
        public static string ToUpperFirst(this string value)
        {
            if (value == null)
                return value;

            return $"{value.Substring(0, 1).ToUpper()}{value.Substring(1, value.Length - 1)}";
        }
    }
}
