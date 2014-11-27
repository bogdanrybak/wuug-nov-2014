using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Part3
{
    public class Example1 : MonoBehaviour
    {
        public RectTransform Prefab;

        public void InstantiatePrefab(Transform parent)
        {
            var buttonTransform = GameObject.Instantiate(Prefab) as RectTransform;

            // Need to set worldPositionStays to false to let the parent position the element
            buttonTransform.SetParent(parent, false);
        }
    }
}