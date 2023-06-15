using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabFashion.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeUser
    {
        Administrador = 1,
        Gerente = 2,
        Criador = 3,
        Outro = 4
    }
}
