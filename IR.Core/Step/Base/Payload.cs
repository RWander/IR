using System.Text.Json;

namespace IR.Core.Step
{
    internal abstract class Payload
    {
        public override string ToString()
        {
            return _ext.ToString(this);
        }
    }

    internal static class _ext
    {
        public static string ToString<T>(this T payload)
            where T : Payload
        {
            return JsonSerializer.Serialize(payload);
        }
    }
}