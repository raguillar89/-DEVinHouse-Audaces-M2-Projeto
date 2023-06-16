using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabFashion.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeModel
    {
        Bermuda,
        Biquini,
        Bolsa,
        Boné,
        Calça,
        Calçados,
        Camisa,
        Chapéu,
        Saia
    }
}
