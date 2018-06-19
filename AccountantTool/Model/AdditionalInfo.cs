using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    [Serializable]
    public class AdditionalInfo
    {
        public List<AddInfoTable> AddInfoTable { get; set; }

        public Dictionary<string, string> ContractFileInfo { get; set; }

        public List<FileInfo> AttachedFiles { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class AddInfoTable
    {
        public string NumberOfContract { get; set; }

        public string Notes { get; set; }

        public string OtherParticipants { get; set; }
    }
}