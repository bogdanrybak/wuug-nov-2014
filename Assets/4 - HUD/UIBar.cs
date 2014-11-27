using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace HUDExamples
{
    public class UIBar : MonoBehaviour
    {
        public FractionProperty Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    if (_value != null)
                        _value.PropertyChanged -= OnPropertyChanged;

                    _value = value;

                    if (_value != null)
                    {
                        _value.PropertyChanged += OnPropertyChanged;
                        OnPropertyChanged(_value.Value, _value.Max);
                    }
                }
                else
                    ClearBar();
            }
        }
        private FractionProperty _value;

        private Slider slider;
        
        void Awake()
        {
            slider = GetComponent<Slider>();
        }

        void OnPropertyChanged(float value, float max)
        {
            slider.maxValue = max;
            slider.value = value;
        }

        void ClearBar()
        {
            slider.value = 0;
        }
    }
}