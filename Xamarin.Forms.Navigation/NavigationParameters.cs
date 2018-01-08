///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Xamarin.Forms.Navigation
{
    public class NavigationParameters : IEnumerable<KeyValuePair<string, object>>
    {
        private readonly List<KeyValuePair<string, object>> _entries = new List<KeyValuePair<string, object>>();
        public int Count
        {
            get
            {
                return _entries.Count;
            }
        }
        public object this[string key]
        {
            get
            {
                foreach (var kvp in _entries)
                {
                    if (string.Compare(kvp.Key, key, StringComparison.Ordinal) == 0)
                    {
                        return kvp.Value;
                    }
                }

                return null;
            }
        }
        public IEnumerable<string> Keys
        {
            get { return _entries.Select(x => x.Key); }
        }
        public T GetValue<T>(string key)
        {
            foreach (var kvp in _entries)
            {
                if (string.Compare(kvp.Key, key, StringComparison.Ordinal) == 0)
                {
                    if (kvp.Value == null)
                        return default(T);
                    else if (kvp.Value.GetType() == typeof(T))
                        return (T)kvp.Value;
                    else if (typeof(T).GetTypeInfo().IsAssignableFrom(kvp.Value.GetType().GetTypeInfo()))
                        return (T)kvp.Value;
                    else
                        return (T)Convert.ChangeType(kvp.Value, typeof(T));
                }
            }

            return default(T);
        }
        public bool ContainsKey(string key)
        {
            foreach (var kvp in _entries)
            {
                if (string.Compare(kvp.Key, key, StringComparison.Ordinal) == 0)
                {
                    return true;
                }
            }

            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(string key, object value)
        {
            _entries.Add(new KeyValuePair<string, object>(key, value));
        }
        public IEnumerable<T> GetValues<T>(string key)
        {
            List<T> values = new List<T>();

            foreach (var kvp in _entries)
            {
                if (string.Compare(kvp.Key, key, StringComparison.Ordinal) == 0)
                {
                    if (kvp.Value == null)
                        values.Add(default(T));
                    else if (kvp.Value.GetType() == typeof(T))
                        values.Add((T)kvp.Value);
                    else if (typeof(T).GetTypeInfo().IsAssignableFrom(kvp.Value.GetType().GetTypeInfo()))
                        values.Add((T)kvp.Value);
                    else
                        values.Add((T)Convert.ChangeType(kvp.Value, typeof(T)));
                }
            }

            return values.AsEnumerable();
        }
        public bool TryGetValue<T>(string key, out T value)
        {
            foreach (var kvp in _entries)
            {
                if (string.Compare(kvp.Key, key, StringComparison.Ordinal) == 0)
                {
                    if (kvp.Value == null)
                        value = default(T);
                    else if (kvp.Value.GetType() == typeof(T))
                        value = (T)kvp.Value;
                    else if (typeof(T).GetTypeInfo().IsAssignableFrom(kvp.Value.GetType().GetTypeInfo()))
                        value = (T)kvp.Value;
                    else
                        value = (T)Convert.ChangeType(kvp.Value, typeof(T));

                    return true;
                }
            }

            value = default(T);
            return false;
        }
        public override string ToString()
        {
            var queryBuilder = new StringBuilder();

            if (_entries.Count > 0)
            {
                queryBuilder.Append('?');
                var first = true;

                foreach (var kvp in _entries)
                {
                    if (!first)
                    {
                        queryBuilder.Append('&');
                    }
                    else
                    {
                        first = false;
                    }

                    queryBuilder.Append(Uri.EscapeDataString(kvp.Key));
                    queryBuilder.Append('=');
                    queryBuilder.Append(Uri.EscapeDataString(kvp.Value.ToString()));
                }
            }

            return queryBuilder.ToString();
        }
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _entries.GetEnumerator();
        }
    }
}
