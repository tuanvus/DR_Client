using UnityEngine;


#if DOTWEEN && ODIN_INSPECTOR

using DG.Tweening;

namespace OSK
{
    [DisallowMultipleComponent, RequireComponent(typeof(RectTransform))]
    public class RectDeltaSizeProvider : DoTweenBaseProvider
    {
        [HideInInspector] public Vector3 to = Vector3.zero;
        [HideInInspector] public Vector3 from = Vector3.zero;
        
        public override object GetStartValue() => from;
        public override object GetEndValue() => to;
        
        public override void ProgressTween(bool isPlayBackwards)
        {
            RootRectTransform.sizeDelta = from;
            target = RootRectTransform;
            tweener = RootRectTransform.DOSizeDelta(from,settings. duration);
            base.ProgressTween(isPlayBackwards);
        }
 
        public override void Play()
        {
            base.Play();
        }
 
        public override void Stop()
        {
            base.Stop();
            RootRectTransform.sizeDelta = from;
        }
    }
}
#endif