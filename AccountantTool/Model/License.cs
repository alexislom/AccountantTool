using System;

namespace AccountantTool.Model
{
    public enum LicenseType
    {
        One,
        Two,
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