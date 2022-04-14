using HelixIntegrationApi.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelixIntegrationApi
{
    public class HelixApi : BaseApi
    {
        private const string localUrl = "http://localhost:1026/";

        /// <summary>
        /// permite alterar o host
        /// </summary>
        /// <param name="host"></param>
        public HelixApi(string host = localUrl) : base(host) { }
    }
}
