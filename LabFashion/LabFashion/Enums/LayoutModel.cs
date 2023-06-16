using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabFashion.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LayoutModel
    {
        Bordado,
        Estampa,
        Liso
    }
}
