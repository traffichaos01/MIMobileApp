using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MIMobileApp.Classes
{
    public class Fixtures
    {
        //Fixtures.cs
        //Get and Set FixturesItems
        public partial class FixturesItems
        {
            [JsonProperty("$id")]
            public long Id { get; set; }

            [JsonProperty("intFixtureID")]
            public int IntFixtureId { get; set; }

            [JsonProperty("strHomeTeam")]
            public string StrHomeTeam { get; set; }

            [JsonProperty("strAwayTeam")]
            public string StrAwayTeam { get; set; }

            [JsonProperty("intTime")]
            public int IntTime { get; set; }

            [JsonProperty("dtDate")]
            public DateTimeOffset DtDate { get; set; }

            [JsonProperty("strLocation")]
            public string StrLocation { get; set; }

            public string StrGameDate {
                 get
                 {
                    return DtDate.ToString("dd-MM-yyyy");
                 }

            }
        
        }

        //Convert JSON string to List of Objects
        public partial class FixturesItems
        {
            public static List<FixturesItems> FromJson(string json)
            {
                return JsonConvert.DeserializeObject<List<FixturesItems>>(json);
            }
        }

    }
}
