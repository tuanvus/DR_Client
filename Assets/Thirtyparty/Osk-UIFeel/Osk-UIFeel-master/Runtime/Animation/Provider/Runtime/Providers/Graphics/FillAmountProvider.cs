
#if DOTWEEN 

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace OSK
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class FillAmountProvider : DoTweenBaseProvider
    {
        [HideInInspector] public Image image;
        [HideInInspector] public float from;
        [HideInInspector] public float to;

        public override object GetStartValue() => from;
        public override object GetEndValue() => to;

        public override void ProgressTween(bool isPlayBackwards)
        {
            if (image.sprite == null)
            {
                Debug.LogWarning("Sprite is null");
                return;
            }

            if (image.type != Image.Type.Filled)
            {
                Debug.LogWarning("Image type is not filled");
                return;
            }

            target = image;
            image.fillAmount = from;
            tweener = DOTween.To(() => from, y => image.fillAmount = (float)y, to, settings.duration);
            base.ProgressTween(isPlayBackwards);
        }

        public override void Play()
        {
            base.Play();
        }

        public override void Stop()
        {
            base.Stop();
            image.fillAmount = from;
        }
    }
}
#endif