using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheMovies.Models
{
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}