using System.Collections.Generic;

namespace AccountantTool.Helpers
{
    public class ListWrapper<T>
    {
        public List<T> Context { get; }

        public ListWrapper(List<T> context) => Context = context;
    }
}