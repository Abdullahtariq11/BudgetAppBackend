using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    /// <summary>
    /// This class represents the error response structure. 
    /// It includes the StatusCode and Message and overrides the ToString() method to return the serialized JSON representation.
    /// </summary>
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
           return JsonSerializer.Serialize(this);
        }
    }
}