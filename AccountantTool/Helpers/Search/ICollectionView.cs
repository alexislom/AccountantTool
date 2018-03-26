using System.Collections.Generic;
using System.ComponentModel;

namespace AccountantTool.Helpers.Search
{
    public interface ICollectionView<out T> : IEnumerable<T>, ICollectionView
    {
        IEnumerable<T> SourceCollectionGeneric { get; }
        //Add here your "generic methods" e.g.
        //e.g. Predicate<T> Filter {get;set;} etc.
    }
}