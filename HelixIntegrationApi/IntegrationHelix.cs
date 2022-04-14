﻿using HelixIntegrationApi.Model.Shared;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelixIntegrationApi
{
    public class IntegrationHelix
    {
        private readonly HelixApi _helixApi;
        public IntegrationHelix(HelixApi api)
        {
            _helixApi = api;
        }

        /// <summary>
        /// Método reflete o endpoint POST /v2/entities' para cadastrar uma entidade no Orion Context Broker
        /// </summary>
        /// <param name="entidade">Entidade a ser cadastrada</param>
        public async Task<RestResponse> CreateEntity<T>(T entidade) where T : BaseEntity<T>
        {
            var endpoint = $"/v2/entities";
            var header = GerarHeaderBasico();

            var response = await _helixApi.ExecuteRequestAsync(endpoint, entidade, Method.Post, header);

            return response;
        }

        /// <summary>
        /// Método reflete o endpoint GET /v2/entities/ para buscar todas as entidades cadastradas
        /// </summary>
        /// <returns>Retorna o um array de Objeto do tipo T</returns>
        public async Task<T[]> ListEntities<T>() where T : BaseEntity<T>
        {
            var endpoint = $"/v2/entities/";
            var header = GerarHeaderBasico();

            var response = await _helixApi.ExecuteRequestAsync(endpoint, new Dictionary<string, string>(), Method.Get, header);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<T[]>(response.Content);

            return Array.Empty<T>();
        }

        /// <summary>
        /// Método reflete o endpoint GET /v2/entities/{entityId} para buscar uma entidade no Orion Context Broker pelo Id
        /// </summary>
        /// <param name="entityId">Id da entidade a ser buscada</param>
        /// <returns>Retorna o Objeto T caso seja encontrado</returns>
        public async Task<T> GetEntityById<T>(string entityId) where T : BaseEntity<T>
        {
            var endpoint = $"/v2/entities/{entityId}";
            var header = GerarHeaderBasico();

            var response = await _helixApi.ExecuteRequestAsync(endpoint, new Dictionary<string, string>(), Method.Get, header);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<T>(response.Content);

            return null;
        }

        /// <summary>
        /// Gera o Header basico para requisições
        /// </summary>
        private Dictionary<string, string> GerarHeaderBasico()
        {
            var listRequestHeader = new Dictionary<string, string>
            {
                { "accept", "application/json" }
            };

            return listRequestHeader;
        }
    }
}
