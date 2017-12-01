using System.Text;

namespace Audit_console.AppMainCode
{
    static class HelperMethods
    {
        /// <summary>
        /// Adds a space before each capital. This is used for creating messages from method names
        /// </summary>
        /// <param name="text">Text to analyse</param>
        /// <param name="preserveAcronyms">Setting value</param>
        /// <returns></returns>
        private static string AddSpacesToCapitals(string text, bool preserveAcronyms = false)
        {
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public static string GetMethodName (string methodName)
        {
            return string.IsNullOrWhiteSpace(methodName) ? string.Empty : AddSpacesToCapitals(methodName);
        }
    }
}
