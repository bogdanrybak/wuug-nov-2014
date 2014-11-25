using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

namespace Part2
{
    public class Example4 : MonoBehaviour
    {
        public Text TextArea;

        private RectTransform rectTransform;

        void Awake()
        {
            rectTransform = transform as RectTransform;
        }

        void OnEnable()
        {
            SetTextContainerHeight(TextArea);
        }

        void SetTextContainerHeight(Text textArea)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, textArea.preferredHeight);
        }

        public void RandomizeText()
        {
            var text = TextArea.text;

            for (var i = 0; i < Random.Range(100, 300); i++)
            {
                if (Random.value > 0.5f)
                    text += (char)('a' + Random.Range(0, 26));
                else
                {
                    text = text.Remove(0, 1);
                }
            }

            TextArea.text = new string(text.OrderBy(c => (Random.value > 0.5)).ToArray());

            SetTextContainerHeight(TextArea);
        }
    }
}
