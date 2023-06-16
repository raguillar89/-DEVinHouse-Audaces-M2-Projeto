using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabFashion.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeModel
    {
        Bermuda = 1,
        Biquini = 2,
        Bolsa = 3,
        Boné = 4,
        Calça = 5,
        Calçados = 6,
        Camisa = 7,
        Chapéu = 8,
        Saia = 9
    }
}
