using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MIMobileApp.Classes
{
    public class Players
    {
        public partial class PlayersItems
        {
            [JsonProperty("$id")]
            public long Id { get; set; }

            [JsonProperty("intPlayerID")]
            public int IntPlayerId { get; set; }

            [JsonProperty("strFirstName")]
            public string StrFirstName { get; set; }

            [JsonProperty("strSurname")]
            public string StrSurname { get; set; }

            [JsonProperty("intGamesPlayed")]
            public int IntGamesPlayed { get; set; }

            [JsonProperty("strPosition")]
            public string StrPosition { get; set; }

            [JsonProperty("intPlayerNumber")]
            public int IntPlayerNumber { get; set; }

            [JsonProperty("intGoals")]
            public int IntGoals { get; set; }

            [JsonProperty("intAssists")]
            public int IntAssists { get; set; }

            [JsonProperty("intPoints")]
            public int IntPoints { get; set; }

            public string StrFullName {
                get
                {
                    return StrFirstName.Trim() + " " + StrSurname.Trim();
                }
            }

        }

        public partial class PlayersItems
        {
            public static List<PlayersItems> FromJson(string json)
            {
                return JsonConvert.DeserializeObject<List<PlayersItems>>(json);
            }
        }
    }
}
