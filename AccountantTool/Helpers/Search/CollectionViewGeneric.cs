using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace AccountantTool.Helpers.Search
{
    //https://github.com/bpatra/MvvMSample/blob/master/MvvMSample/ICollectionViewGeneric.cs
    //Generic realization of ICollectionView.
    public class CollectionViewGeneric<T> : ICollectionView<T>
    {
        private readonly ICollectionView _collectionView;
        private readonly object _objectLock = new object();

        public CollectionViewGeneric(ICollectionView generic) => _collectionView = generic;

        #region IEnumerable
        public IEnumerator<T> GetEnumerator() => new Enumerator(_collectionView.GetEnumerator());
        IEnumerator IEnumerable.GetEnumerator() => _collectionView.GetEnumerator();
        #endregion IEnumerable

        public bool Contains(object item) => _collectionView.Contains(item);
        public void Refresh() => _collectionView.Refresh();
        public IDisposable DeferRefresh() => _collectionView.DeferRefresh();
        public bool MoveCurrentToFirst() => _collectionView.MoveCurrentToFirst();
        public bool MoveCurrentToLast() => _collectionView.MoveCurrentToLast();
        public bool MoveCurrentToNext() => _collectionView.MoveCurrentToNext();
        public bool MoveCurrentToPrevious() => _collectionView.MoveCurrentToPrevious();
        public bool MoveCurrentTo(object item) => _collectionView.MoveCurrentTo(item);
        public bool MoveCurrentToPosition(int position) => _collectionView.MoveCurrentToPosition(position);
        public CultureInfo Culture
        {
            get => _collectionView.Culture;
            set => _collectionView.Culture = value;
        }
        public IEnumerable SourceCollection => _collectionView.SourceCollection;
        public Predicate<object> Filter
        {
            get => _collectionView.Filter;
            set => _collectionView.Filter = value;
        }
        public bool CanFilter => _collectionView.CanFilter;
        public SortDescriptionCollection SortDescriptions => _collectionView.SortDescriptions;
        public bool CanSort => _collectionView.CanSort;
        public bool CanGroup => _collectionView.CanGroup;
        public ObservableCollection<GroupDescription> GroupDescriptions => _collectionView.GroupDescriptions;
        public ReadOnlyObservableCollection<object> Groups => _collectionView.Groups;
        public bool IsEmpty => _collectionView.IsEmpty;
        public object CurrentItem => _collectionView.CurrentItem;
        public int CurrentPosition => _collectionView.CurrentPosition;
        public bool IsCurrentAfterLast => _collectionView.IsCurrentAfterLast;
        public bool IsCurrentBeforeFirst => _collectionView.IsCurrentBeforeFirst;
        public event CurrentChangingEventHandler CurrentChanging
        {
            add
            {
                lock (_objectLock)
                {
                    _collectionView.CurrentChanging += value;
                }
            }
            remove
            {
                lock (_objectLock)
                {
                    _collectionView.CurrentChanging -= value;
                }
            }
        }
        public event EventHandler CurrentChanged
        {
            add
            {
                lock (_objectLock)
                {
                    _collectionView.CurrentChanged += value;
                }
            }
            remove
            {
                lock (_objectLock)
                {
                    _collectionView.CurrentChanged -= value;
                }
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                lock (_objectLock)
                {
                    _collectionView.CollectionChanged += value;
                }
            }
            remove
            {
                lock (_objectLock)
                {
                    _collectionView.CollectionChanged -= value;
                }
            }
        }
        public IEnumerable<T> SourceCollectionGeneric => _collectionView.Cast<T>();

        #region Enumerator
        private class Enumerator : IEnumerator<T>
        {
            private readonly IEnumerator _enumerator;
            public Enumerator(IEnumerator enumerator) => _enumerator = enumerator;
            public bool MoveNext() => _enumerator.MoveNext();
            public T Current => (T)_enumerator.Current;
            object IEnumerator.Current => Current;
            public void Dispose()
            {
            }
            public void Reset() => _enumerator.Reset();
        }
        #endregion Enumerator
    }
}