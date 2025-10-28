using System;
#if DOTWEEN && ODIN_INSPECTOR

using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace OSK
{
    public class EventProvider : DoTweenBaseProvider
    {
        public override object GetStartValue() => null;
        public override object GetEndValue() => null;
        

        public override void ProgressTween(bool isPlayBackwards)
        { 
            base.ProgressTween(isPlayBackwards);
        }

        
        public override void Play()
        {
            base.Play();
        }


        public override void Stop()
        {
            base.Stop();
        }
    }
}
#endif