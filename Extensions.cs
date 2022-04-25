
namespace Savas.Revision;

static class Extensions
{
    public static String MapToString<T>(this IEnumerable<T> array) => array.Select(i => i + " ").Aggregate((str, i) => (str + i));
}

