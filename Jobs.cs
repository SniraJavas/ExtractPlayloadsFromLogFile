using System;
using System.Collections.Generic;
using System.Text;

namespace ExtractPlayloadFromLogFile
{
    public class Jobs
    {
        string[] JobsTypes = new string[4];
        //Job types to look for
        string Offer = "https://asgard-au-prod.azure-api.net/digicall-aus/offer";
        string Status = "https://asgard-au-prod.azure-api.net/digicall-aus/status";
        string File = "https://asgard-au-prod.azure-api.net/digicall-aus/file";
        string Data = "https://asgard-au-prod.azure-api.net/digicall-aus/data";
        string Token = "https://asgard-au-prod.azure-api.net/digicall-aus/token";
        public Jobs() {
           
                JobsTypes[0] = Offer;
                JobsTypes[1] = Status;
                JobsTypes[2] = File;
                JobsTypes[3] = Data;
                JobsTypes[4] = Token;
        }

        

    }
}
