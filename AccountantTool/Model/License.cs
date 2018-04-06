using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    public enum LicenseType
    {
        [Description("First type of license")]
        One,
        [Description("Secound type of license")]
        Two,
        [Description("Third type of license")]
        Three
    }

    [Serializable]
    public class License
    {
        public string NumberOfLicense { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime DateOfExpiration { get; set; }

        //public LicenseType LicenseType { get; set; }

        public string LicenseType { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}