using HelixIntegrationApi.Model.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelixIntegrationApi.Model.Entities
{
    public class PontoDeSensoriamento : BaseEntity<PontoDeSensoriamento>
    {
        [JsonProperty("nivelDaAgua")]
        public NivelDaAgua NivelDaAgua { get; set; }

        [JsonProperty("vazaoDaAgua")]
        public VazaoDaAgua VazaoDaAgua { get; set; }
    }
    public class NivelDaAgua : BaseAttribute
    {
        public NivelDaAgua(double value) : base("float", value) { }
    }
    public class VazaoDaAgua : BaseAttribute
    {
        public VazaoDaAgua(double value) : base("float", value) { }
    }
}
