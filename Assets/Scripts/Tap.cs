using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tap : MonoBehaviour
{
    public int LocalNum;
   // public int num;
    public Button button;
    public static bool Tapped;
    private bool tap;
    Color StartColor = new Color(0.5566038f, 0.4799395f, 0.4799395f);
    //public void ShowNum()
    //{
    //  //  LocalNum--;
    //    DictionaryManagement.del = false;
    //}
    private void Start()
    {
        //Debug.Log(LocalNum);
        button = this.GetComponent<Button>();
        button.onClick.AddListener(delegate { TaskOnClick(Tapped); });
    }
    void TaskOnClick(bool tapped)
    {
        //if (!tapped)
        //{
        if (!tapped) {
            Tapped = true;
            button.GetComponent<Image>().color = Color.black;
            this.tag = "ToDelete";
        }
        else if(tapped && tap)
        {
            StartCoroutine(cancel(false));
        }
        else if(tapped && !tap)
        { 
            StartCoroutine(cancel(true));
        }
    }
    private IEnumerator cancel(bool need)
    {
        Tapped = false;
        yield return null;
        if (need)
        {
            Tapped = true;
            button.GetComponent<Image>().color = Color.black;
            this.tag = "ToDelete";
        }
    }
    private void Update()
    {
        if (button.GetComponent<Image>().color == StartColor)
        {
            tap = false;
        }
        else
        {
            tap = true;
        }
        if (!Tapped)
        {
            button.GetComponent<Image>().color = StartColor;
            this.tag = "Word";
        }
    }
}
