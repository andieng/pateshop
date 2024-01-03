using Newtonsoft.Json;
using System.Collections.Generic;


namespace MyShop.Models
{
    public class ResponseObjectResult<T>:BaseModel
    {
        [JsonProperty("result")]
        public List<T> Result { get; set; }
    }
}
