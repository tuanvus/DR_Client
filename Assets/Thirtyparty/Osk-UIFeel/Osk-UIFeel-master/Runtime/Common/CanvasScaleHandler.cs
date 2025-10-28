using UnityEngine;
using UnityEngine.UI;

namespace OSK
{
    public class CanvasScaleHandler : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private UnityEngine.UI.CanvasScaler canvasScaler;
        [SerializeField] private bool isPortrait;

        private void Awake()
        {
            float newRatio = (float)Screen.width / Screen.height;

            if (camera == null)
                camera = GetComponent<Camera>();
            if (canvasScaler == null)
                canvasScaler = GetComponent<UnityEngine.UI.CanvasScaler>();

            SetupCanvasScaler(newRatio);
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying) return;
            if (camera != null && canvasScaler != null)
            {
                //float currentRatio = isPortrait ? 1080f / 1920 : 1920f / 1080;
                float newRatio = (float)camera.pixelWidth / camera.pixelHeight;
                SetupCanvasScaler(newRatio);
                
                // float scaleFactor = canvasScaler.referenceResolution.x / camera.pixelWidth;
                // Debug.Log("canvas Scaler Factor X: " + scaleFactor);
            }
        }

        private void SetupCanvasScaler(float ratio)
        {
            canvasScaler.matchWidthOrHeight = ratio > 0.65f ? 1 : 0;
        }
    }
}