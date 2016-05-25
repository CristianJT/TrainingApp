﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var DefFormatter = new Newtonsoft.Json.JsonSerializerSettings();

            DefFormatter.Formatting = Newtonsoft.Json.Formatting.None;
            DefFormatter.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            DefFormatter.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            DefFormatter.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            Newtonsoft.Json.JsonConvert.DefaultSettings = () => DefFormatter;
            config.Formatters.JsonFormatter.SerializerSettings = DefFormatter;

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Remove XML Formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
