﻿using Swashbuckle.AspNetCore.Swagger;

namespace WebApplication2
{
    internal class OpenApiInfo : Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public object Contact { get; set; }
    }
}