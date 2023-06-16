﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabFashion.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeUser
    {
        Administrador,
        Gerente,
        Criador,
        Outro
    }
}
