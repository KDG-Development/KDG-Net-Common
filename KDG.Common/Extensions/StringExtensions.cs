namespace KDG.Common.Extensions
{
  public static class StringExtensions
  {
    public static string Wordify(this string text)
    {
      string wordified = string.Empty;

      foreach (var value in text)
      {
        if (char.IsUpper(value))
          wordified += $" {value}";
        else
          wordified += value;
      }

      return wordified.Trim();
    }

    // todo: this should be probably be in a zoho specific file/namespace/lib?
    public static IEnumerable<string> SplitZohoMultiFieldValue(this string? value)
    {
      var newLineValue = "\n";

      if (string.IsNullOrEmpty(value))
        return new string[0];
      else if (value.Contains(Environment.NewLine))
        value = value.Replace(Environment.NewLine, newLineValue);

      var delimiter = value.Contains(newLineValue) ? newLineValue : ",";
      var results = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());

      return results;
    }
  }
}
