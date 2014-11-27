using UnityEngine;
using System.Collections;

namespace Misc
{
    public delegate void ObservablePropertyEventHandler(float value);

    public class ObservableProperty
    {
        public event ObservablePropertyEventHandler PropertyChanged;

        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged(value);
            }
        }

        private float _value;
    }
}