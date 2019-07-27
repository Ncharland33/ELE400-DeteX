using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELE400_DeteX_WebApp.models
{   /* TO-DO:  Rework Data Response model:  Table of Tables, with Device ID and Messages in Response and Errors in others.*/
    public class Data
    {
        public string DeviceId { get; set; }
        public int Date { get; set; }               // Need to verify datatype + response.
        public string RawData { get; set; }         // Need to rename type appropriately.
    }
}
