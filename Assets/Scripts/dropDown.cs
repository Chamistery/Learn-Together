using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dropDown : MonoBehaviour
{
    Button button;
    public RectTransform arrow;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;
    Color backgroundDefaultColor;
    Color handleDefaultColor;
    public static bool clicked;
    public Animator anim;
    private bool tap;
    public Text text;
    int lan = 0;
    void Awake()
    {
        WhatIs();
        //Debug.Log(this.tag);
        //Debug.Log(lan);
        Playing.Language = 3;
        button = GetComponent<Button>();

        backgroundDefaultColor = GetComponent<Image>().color;
        handleDefaultColor = text.color;

        button.onClick.AddListener(delegate { OnSwitch(clicked); });
    }
    void OnSwitch(bool on)
    {
        if (!on)
        {
            clicked = true;
            button.GetComponent<Image>().color = backgroundActiveColor;
            text.color = handleActiveColor;
            arrow.anchoredPosition = new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y + 180);
        }
        else if (clicked && !tap)
        {
            StartCoroutine(cancel(true));
           // arrow.anchoredPosition = new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y + 95);
        }
    }
    // Update is called once per frame
    private IEnumerator cancel(bool need)
    {
        clicked = false;
        yield return null;
        if (need)
        {
            clicked = true;
            button.GetComponent<Image>().color = backgroundActiveColor;
            text.color = handleActiveColor;
            arrow.anchoredPosition = new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y + 180);
        }
    }
    void WhatIs()
    {
        if (this.CompareTag("Rus"))
        {
            lan = 0;
            Playing.b = Random.Range(1, 3);
        }
        else if (this.CompareTag("Eng"))
        {
            lan = 1;
            Playing.b = Random.Range(1, 3);
        }
        else
        {
            lan = 2;

        }
    }
    //IEnumerator Check()
    //{
    //    yield return null;
    //    WhatIs();
    //    Playing.Language = lan;
    //}
    private void Update()
    {
        
        if (button.GetComponent<Image>().color == backgroundDefaultColor)
        {
            lan = 3;
            //Playing.Language = lan;
            tap = false;
            anim.SetTrigger("Normal");
            anim.ResetTrigger("Selected");
        }
        else
        {
            WhatIs();
            if(!tap)
                Playing.Language = lan;
           // Debug.Log("I dunno");
            tap = true;
            anim.ResetTrigger("Normal");
            anim.SetTrigger("Selected");
        }
        if (!clicked)
        {
            arrow.anchoredPosition = new Vector2(-1000, -5000);
            anim.SetTrigger("Normal");
            anim.ResetTrigger("Selected");
            button.GetComponent<Image>().color = backgroundDefaultColor;
            text.color = handleDefaultColor;
            //this.tag = "Word";
        }
    }
}
