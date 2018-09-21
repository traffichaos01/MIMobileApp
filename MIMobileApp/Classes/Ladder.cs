using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MIMobileApp.Classes
{
    public class Ladder
	{
        //LadderItems.cs
        //Get and Set LadderItems
        public partial class LadderItems
        {
            [JsonProperty("$id")]
            public long Id { get; set; }

            [JsonProperty("intTeamID")]
            public int IntTeamId { get; set; }

            [JsonProperty("strTeamName")]
            public string StrTeamName { get; set; }

            [JsonProperty("intPoints")]
            public int IntPoints { get; set; }

            [JsonProperty("intGamesPlayed")]
            public int IntGamesPlayed { get; set; }

            [JsonProperty("intGamesWon")]
            public int IntGamesWon { get; set; }

            [JsonProperty("intGamesLost")]
            public int IntGamesLost { get; set; }

            [JsonProperty("strLogoURL")]
            public string StrLogoUrl { get; set; }
        }

        //Convert JSON string to List of Objects
        public partial class LadderItems
        {
            public static List<LadderItems> FromJson(string json)
            {
                return JsonConvert.DeserializeObject<List<LadderItems>>(json);
            }
        }
    }
}
