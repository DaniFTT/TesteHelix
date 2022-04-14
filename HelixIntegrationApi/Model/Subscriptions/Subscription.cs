using HelixIntegrationApi.Model.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelixIntegrationApi.Model.Subscriptions
{
    public class Subscription<T> where T : class
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description")]
        public Subject<T> Subject { get; set; }

        [JsonProperty("expires")]
        public string Expires => "2023-01-01T14:00:00.00Z";
    }

    public class Subject<T> where T : class
    {
        [JsonProperty("entities")]
        public List<BaseEntity<T>> Entities { get; set; }

        [JsonProperty("condition")]
        public ConditionSubscriptionModel Condition { get; set; }

        [JsonProperty("notification")]
        public NotificationSubscriptionModel Notification { get; set; }
    }
    public class NotificationSubscriptionModel
    {
        [JsonProperty("http")]
        public HttpSubscriptionModel Http { get; set; }

        [JsonProperty("attrs")]
        public string[] AttributesNames { get; set; }

    }
    public class HttpSubscriptionModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ConditionSubscriptionModel
    {
        [JsonProperty("attrs")]
        public List<BaseAttribute> Attributes { get; set; }
    }
}
