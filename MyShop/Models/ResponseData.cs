using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyShop.Models
{
    public class ResponseData<T> : BaseModel
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}
