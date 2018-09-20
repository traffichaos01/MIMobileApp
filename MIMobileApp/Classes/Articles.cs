using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace MIMobileApp.Classes
{
    public class Articles     {         public partial class ArticlesItems
        {             [JsonProperty("$id")]             public long Id { get; set; }              [JsonProperty("intArticleID")]             public string intArticleId { get; set; }              [JsonProperty("strArticleTitle")]             public string strArticleTitle { get; set; }              [JsonProperty("strArticlePhotoUrl")]             public string strArticlePhotoUrl { get; set; }              [JsonProperty("strArticleURL")]             public string strArticleURL { get; set; }         }          public partial class ArticlesItems
        {             public static List<ArticlesItems> FromJson(string json)             {                 return JsonConvert.DeserializeObject<List<ArticlesItems>>(json);             }         }     }
}
