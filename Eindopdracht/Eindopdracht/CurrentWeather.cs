﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Eindopdracht
{
    class CurrentWeather : JsonProperty
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}
