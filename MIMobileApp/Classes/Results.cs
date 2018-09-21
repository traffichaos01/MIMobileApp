using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace MIMobileApp.Classes
{
    public class Results
    {
        //Results.cs
        //Get and Set ResultsItems
        public partial class ResultsItems
        {
            [JsonProperty("$id")]
            public long Id { get; set; }

            [JsonProperty("intResultID")]
            public int IntResultId { get; set; }

            [JsonProperty("strHomeTeam")]
            public string StrHomeTeam { get; set; }

            [JsonProperty("strAwayTeam")]
            public string StrAwayTeam { get; set; }

            [JsonProperty("intHomeTeamGoals")]
            public int IntHomeTeamGoals { get; set; }

            [JsonProperty("intAwayTeamGoals")]
            public int IntAwayTeamGoals { get; set; }

            [JsonProperty("dtDate")]
            public DateTimeOffset DtDate { get; set; }

            public string StrScore{
                get{
                    return IntHomeTeamGoals.ToString() + " vs " + IntAwayTeamGoals.ToString();
                }
            }
        }

        //Convert JSON string to List of Objects
        public partial class ResultsItems
		{
            public static List<ResultsItems> FromJson(string json)
            {
                return JsonConvert.DeserializeObject<List<ResultsItems>>(json);
            }
		}


    }
}
