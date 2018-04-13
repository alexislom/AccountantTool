using System.Collections.Generic;
using System.IO;

namespace AccountantTool.Helpers
{
    public class FileInfoEqualityComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            return y != null && x != null && x.Name == y.Name;
        }

        public int GetHashCode(FileInfo fileInfo)
        {
            var hash = 17;
            unchecked
            {
                hash = hash * 23 + fileInfo.Name.GetHashCode();
                //hash += fileInfo.FullName.GetHashCode();
            }

            return hash;
        }
    }
}