﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabFashion.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SystemStatus
    {
        Ativo = 1,
        Inativo = 2
    }
}
