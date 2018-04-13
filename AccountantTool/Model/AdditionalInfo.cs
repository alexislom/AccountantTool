using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    [Serializable]
    public class AdditionalInfo
    {
        public string Notes { get; set; }

        public List<FileInfo> AttachedFiles { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}