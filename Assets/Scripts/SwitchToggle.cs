using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;
    [SerializeField] GameObject handle;

    Image backgroundImage, handleImage;
    Color backgroundDefaultColor, handleDefaultColor;

    Toggle toggle;

    Vector2 handlePosition;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = new Vector2(uiHandleRectTransform.anchoredPosition.x, uiHandleRectTransform.anchoredPosition.y);
        handle.transform.position = handlePosition;
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
        {
            OnSwitch(true);
        }
        else
        {
            OnSwitch(false);
        }
    }

    void OnSwitch(bool on)
    {
        if (on)
        {
            uiHandleRectTransform.anchoredPosition = new Vector2(handlePosition.x + 160, handlePosition.y);
            //  handle.transform.position = Vector3.MoveTowards(uiHandleRectTransform.anchoredPosition, new Vector2(handlePosition.x + 1000, handlePosition.y+ 200), 1);
        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
            // handle.transform.position = Vector3.MoveTowards(uiHandleRectTransform.anchoredPosition, handlePosition, 1);
        }
        //    uiHandleRectTransform.DOMove(on ? new Vector2(handlePosition.x + 38, handlePosition.y) : handlePosition, 0.4f, true);
        //     uiHandleRectTransform.DOMoveX(on? handlePosition.x + 277 : uiHandleRectTransform.anchoredPosition.x, .4f, true); //DOMove(on? (handlePosition.x + 38, handlePosition.y): uiHandleRectTransform.anchoredPosition);
        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
        handleImage.color = on ? handleActiveColor : handleDefaultColor;
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
