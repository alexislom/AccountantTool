using System;
using System.ComponentModel;

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

    public class License
    {
        public int Id { get; set; }

        public int NumberOfLicense { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime DateOfExpiration { get; set; }

        public LicenseType LicenseType { get; set; }
    }
}