using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class ResponseTotalQuantitySold<T>:BaseModel
    {
        [JsonProperty("totalQuantitySold")]
        public List<T> TotalQuantitySold { get; set; }
    }
}
