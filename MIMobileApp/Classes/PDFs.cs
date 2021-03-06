﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MIMobileApp.Classes
{
    //PDFs.cs
    //Get and Set PDFs
    public class PDFs
    {
		public partial class PDFItems
        {
        [JsonProperty("$id")]
        public long Id { get; set; }

        [JsonProperty("intPDFID")]
        public int IntPDFid { get; set; }

        [JsonProperty("strPDFTitle")]
        public string StrPDFTitle { get; set; }

        [JsonProperty("strPDFPhotoURL")]
        public string StrPDFPhotoUrl { get; set; }

        [JsonProperty("strPDFURL")]
        public string StrPDFURL { get; set; }

        [JsonProperty("dtPDF")]
        public DateTimeOffset DtPDF { get; set; }
        }

        //Convert JSON string to List of Objects
        public partial class PDFItems
        {
            public static List<PDFItems> FromJson(string json)
            {
                return JsonConvert.DeserializeObject<List<PDFItems>>(json);
            }
        }
    }
}
