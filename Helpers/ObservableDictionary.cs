using System.Collections.Generic;

namespace Mikron_MOAB_HMI.Helpers
{
    public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public delegate void DictionaryUpdateHandler();

        public event DictionaryUpdateHandler DictionaryUpdated;

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            //Log.Info(string.Join(", ", base.Keys));
            OnDictionaryUpdated();
        }

        public new void Remove(TKey key)
        {
            base.Remove(key);
            OnDictionaryUpdated();
        }

        public new TValue this[TKey key]
        {
            get => base[key];
            set
            {
                base[key] = value;
                OnDictionaryUpdated();
            }
        }

        protected virtual void OnDictionaryUpdated()
        {
            DictionaryUpdated?.Invoke();
        }
    }
}