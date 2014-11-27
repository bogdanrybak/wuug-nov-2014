using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.ComponentModel;

namespace Misc
{
    public class BenchmarkSubject : MonoBehaviour
    {
        public Slider Slider;

        public ObservableProperty ObservableProperty
        {
            get { return _observableProperty; }
            set
            {
                if (_observableProperty != null)
                    _observableProperty.PropertyChanged -= OnPropertyChanged;

                _observableProperty = value;

                if (_observableProperty != null)
                {
                    _observableProperty.PropertyChanged += OnPropertyChanged;
                }
            }
        }

        private ObservableProperty _observableProperty;

        void OnPropertyChanged(float value)
        {
            Slider.value = value;
        }

        public void SetScrollbarValue(float value)
        {
            Slider.value = value;
        }
    }
}