using System;

namespace DevFuckers.Assets.Source.Scripts.Core.Mob
{
    [Serializable]
    public struct KeyValue<T1, T2>
    {
        public T1 Key;
        public T2 Value;

        public KeyValue(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }
    }
}