using UnityEngine;
#if DOTWEEN 

namespace OSK
{
    public class PulsateProvider : MonoBehaviour
    {
        public float amount = 0.1f;
        public float speed = 1f;
        public bool oneSided = false;

        public float delay;
        private float currentDelay;

        public Vector3 ratio = Vector3.one;
        private Vector3 originalScale;

        private OSK.ScaleProvider _scaleProvider;
        private ButtonEffect buttonEffect;

        private void OnEnable()
        {
            _scaleProvider = GetComponent<OSK.ScaleProvider>();
            buttonEffect = GetComponent<ButtonEffect>();

            if (_scaleProvider != null)
            {
                currentDelay = delay + _scaleProvider.settings.duration + _scaleProvider.settings.delay;
                originalScale = Vector3.one;
            }
            else
            {
                currentDelay = delay;
                originalScale = transform.localScale;
            }
        }

        private void Update()
        {
            if (buttonEffect != null && buttonEffect.IsPressed)
            {
                return;
            }

            if (currentDelay > 0)
            {
                currentDelay -= Time.deltaTime;
            }
            else
            {
                float amt = Mathf.Sin(Time.time * speed);
                amt = oneSided ? Mathf.Abs(amt) : amt;
                transform.localScale = originalScale + ratio * (amount * amt);
            }
        }
    }
}
#endif