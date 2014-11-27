using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Part2
{
    public class RenderTextureGrabber : MonoBehaviour
    {
        public Camera Camera;

        private RenderTexture targetTexture;

        void Awake()
        {
            targetTexture = new RenderTexture(Screen.width, Screen.height, 0);
            targetTexture.name = "Render texture from " + Camera.gameObject.name;
            targetTexture.Create();
            Camera.targetTexture = targetTexture;

            var rawImage = GetComponent<RawImage>();
            rawImage.texture = targetTexture;
        }

        void OnApplicationQuit()
        {
            Camera.targetTexture.DiscardContents();
        }
    }
}