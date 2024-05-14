using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Model
{
    public class ApplicationSettings
    {
        public CosmoDbSetting CosmoDbSetting { get; set; }
    }

    public class CosmoDbSetting
    {
        public string EndPointUrl { get; set; }
        public string DatabaseName { get; set;}
        public string PrimaryKey { get; set;}
    }
}
