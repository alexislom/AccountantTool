using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    public enum ContractStage
    {
        [Description("First type of contract")]
        One,
        [Description("Secound type of contract")]
        Two,
        [Description("Third type of contract")]
        Tree
    }

    [Serializable]
    public class Contract
    {
        public int Id { get; set; }

        public string NumberOfContract { get; set; }

        public string SidesOfContract { get; set; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfEnd { get; set; }

        //public ContractStage ContractStage { get; set; }
        public string ContractStage { get; set; }

        //public bool IsFulfilled { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}