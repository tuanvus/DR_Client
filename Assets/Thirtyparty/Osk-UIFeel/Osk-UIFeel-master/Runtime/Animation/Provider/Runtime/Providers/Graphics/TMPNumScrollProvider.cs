#if DOTWEEN 

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace OSK
{
    [DisallowMultipleComponent]
    public class TMPNumScrollProvider : DoTweenBaseProvider
    {
        [HideInInspector] public Text text;
        [HideInInspector] public int from;
        [HideInInspector] public int to;

        public override object GetStartValue() => from;
        public override object GetEndValue() => to;

        public override void ProgressTween(bool isPlayBackwards)
        {
            text = text ? text : GetComponent<Text>();

            target = text;
            text.text = from.ToString();
            tweener = DOTween.To(() => 0, y => text.text = y.ToString(), to, settings.duration);
            base.ProgressTween(isPlayBackwards);
        }


        public override void Play()
        {
            base.Play();
        }

        public override void Stop()
        {
            base.Stop();
            text.text = from.ToString();
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (GetComponent<TextLoadingAnimationProvider>() != null)
            {
                Debug.LogError("TextLoadingAnimationProvider is already attached to this GameObject. Please remove it before adding TextLoadingAnimationProvider.");
                enabled = false;
            }
        }
#endif
    }
}
#endif