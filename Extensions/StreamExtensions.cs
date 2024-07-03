using System.Runtime.CompilerServices;

namespace KDG.Common.Extensions
{
  public static class StreamExtensions
  {
    public static string Base64Encode(this Stream stream)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        stream.CopyTo(ms);
        byte[] imageArray = ms.ToArray();
        var imgBase64Str = Convert.ToBase64String(imageArray);
        return string.IsNullOrEmpty(imgBase64Str) ? string.Empty : imgBase64Str;
      }
    }
  }
}
