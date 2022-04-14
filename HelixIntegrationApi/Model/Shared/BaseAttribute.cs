using System;
using System.Collections.Generic;
using System.Text;

namespace HelixIntegrationApi.Model.Shared
{
    public abstract class BaseAttribute
    {
        public string Type { get; set; }
        public double Value { get; set; }

        protected BaseAttribute(string type, double value)
        {
            Type = type;
            Value = value;
        }

        protected BaseAttribute() { }
    }
}
