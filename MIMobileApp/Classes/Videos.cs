using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MIMobileApp.Classes
{
    public class Videos
    {
        public partial class VideosItems
        {
            [JsonProperty("$id")]
            public long Id { get; set; }

            [JsonProperty("intVideoID")]
            public int IntVideoId { get; set; }

            [JsonProperty("strVideoTitle")]
            public string StrVideoTitle { get; set; }

            [JsonProperty("strVideoURL")]
            public string StrVideoURL { get; set; }

            [JsonProperty("strVideoPhotoUrl")]
            public string StrVideoPhotoUrl { get; set; }
        }

        public partial class VideosItems
        {
            public static List<VideosItems> FromJson(string json)
            {
                return JsonConvert.DeserializeObject<List<VideosItems>>(json);
            }
        }

    }
}
