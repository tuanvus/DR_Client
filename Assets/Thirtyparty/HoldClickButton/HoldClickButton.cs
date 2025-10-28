using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/Hold Click Button")]
public class HoldClickButton : Button, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onHoldClick;
    [Range(0f, 5f)] public float holdDuration = 0.05f;
    private bool isPointerDown;

    public override void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        timeCheck = 0;

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        ResetClick();
    }

    private void ResetClick()
    {
        isPointerDown = false;
        timeCheck = 0;
    }

    float timeCheck = 0;

    private void Update()
    {
        if (isPointerDown)
        {
            timeCheck += Time.deltaTime;

            if (onHoldClick != null && timeCheck >= holdDuration)
            {
                onHoldClick.Invoke();
                timeCheck = 0;
            }
        }
    }

    protected override void OnDisable()
    {
        ResetClick();
        base.OnDisable();
    }
}