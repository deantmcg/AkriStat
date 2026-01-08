using System.Globalization;
using System.Text;

namespace AkriStat.Helpers
{
    public static class Normalizer
    {
        /* Converts accented characters to standard
           e.g. Ødegaard > Odegaard */
        public static string NormalizeString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToUpper();
        }
    }
}
