using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace Part2
{
    // Here's a list of all the interfaces that can be implemented
    // https://bitbucket.org/Unity-Technologies/ui/src/ee188cc9dc2659e5404a912dd1344ade0855e6d0/UnityEngine.UI/EventSystem/EventInterfaces.cs?at=4.6
    public class ExampleOnHoverInterface : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Hovered");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked");
        }
    }
}