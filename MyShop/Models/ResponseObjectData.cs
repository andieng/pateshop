using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class ResponseObjectData<T> : BaseModel
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
