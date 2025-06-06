﻿using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Surging.Core.CPlatform.Runtime.Server;

namespace Surging.Core.Swagger_V5.SwaggerGen
{
    public interface IParameterFilter
    {
        void Apply(OpenApiParameter parameter, ParameterFilterContext context);
    }

    public class ParameterFilterContext
    {
        public ParameterFilterContext(
            ApiParameterDescription apiParameterDescription,
            ISchemaGenerator schemaGenerator,
            SchemaRepository schemaRepository,
            PropertyInfo propertyInfo = null,
            ParameterInfo parameterInfo = null, ServiceEntry serviceEntry=null)
        {
            ApiParameterDescription = apiParameterDescription;
            SchemaGenerator = schemaGenerator;
            SchemaRepository = schemaRepository;
            PropertyInfo = propertyInfo;
            ParameterInfo = parameterInfo;
            ServiceEntry = serviceEntry;
        }

        public ServiceEntry ServiceEntry { get; set; }
        public ApiParameterDescription ApiParameterDescription { get; }

        public ISchemaGenerator SchemaGenerator { get; }

        public SchemaRepository SchemaRepository { get; }

        public PropertyInfo PropertyInfo { get; }

        public ParameterInfo ParameterInfo { get; }

        public string DocumentName => SchemaRepository.DocumentName;
    }
}
