using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lorakon_manager
{
    [Serializable()]
    public class Settings
    {        
        public string ConnectionString { get; set; }        

        public Settings()
        {            
            ConnectionString = "Server=zyrox3;Database=nrpa_lorakon;Trusted_Connection=True;";            
        }
    }    
}
