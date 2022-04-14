using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelixIntegrationApi.Model.Shared
{
    public abstract class BaseEntity<T> where T : class
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type => typeof(T).Name;
    }
}
