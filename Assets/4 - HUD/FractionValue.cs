using UnityEngine;
using System.Collections;
using System;

namespace HUDExamples
{
    [Serializable]
    public class FractionProperty
    {
        public Action<float, float> PropertyChanged;

        public float Value
        {
            get { return _value; }
            set
            {
                _value = Mathf.Clamp(value, 0, _max);

                if (PropertyChanged != null)
                    PropertyChanged(_value, _max);
            }
        }

        public float Max
        {
            get { return _max; }
            set
            {
                _max = value;

                if (PropertyChanged != null)
                    PropertyChanged(_value, _max);
            }
        }

        public float Normalized
        {
            get { return _value != 0 ? _value / _max : 0; }
        }

        [SerializeField]
        private float _value;
        [SerializeField]
        private float _max;

    }
}