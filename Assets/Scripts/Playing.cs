using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playing : MonoBehaviour
{
    public GameObject canvas;
    public GameObject word;
    public GameObject wordText;
    public GameObject CancelTab;
    public GameObject text1;
    public GameObject text2;
    public GameObject counter;
    public static int Language;
    //  public GameObject text3;
    public static int FullCount = 0;
    public static int AppCount = 0;
    int random = 0;
    GameObject _word = null;
    GameObject text;
    public static int b = 0;
  //  bool yet;
    private void Start()
    {
        FullCount = 0;
        AppCount = 0;
        CancelTab.SetActive(false);
       // Language.onValueChanged.AddListener(delegate { Changing(); });
    }
    //void Changing()
    //{
    //    if(DictionaryManagement.WordDic[1] != null && DictionaryManagement.someActive)
    //    {
    //        if (Language.value == 0)
    //        {
    //            text.GetComponent<Text>().text = DictionaryManagement.TransDic[random];
    //        }
    //        else
    //        {
    //            text.GetComponent<Text>().text = DictionaryManagement.WordDic[random];
    //        } 
    //    }
    //}
    private void Update()
    {
        if (DictionaryManagement.isPlaying && DictionaryManagement.WordDic.ContainsKey(1) && DictionaryManagement.someActive) // && DictionaryManagement.isClosed)
        {
            b = Random.Range(1, 3);
            Debug.Log("Created");
            //yet = false;
            DictionaryManagement.isPlaying = false;
            _word = Instantiate(word, new Vector3(0, -5, 0), Quaternion.identity) as GameObject;
            if(_word != null)
                FullCount++;
            counter.GetComponent<Text>().text = AppCount + "/" + FullCount;
            text = Instantiate(wordText, new Vector3(0, -5, 0), Quaternion.identity) as GameObject;
            text.GetComponent<Text>().text = " ";
            text.transform.SetParent(canvas.transform);
            text.GetComponent<TextMoving>().follow = _word;
            int a = (int)Random.Range(1, DictionaryManagement.Num);
            for (int i = 1; i < DictionaryManagement.Num; i++)
            {
                Debug.Log(i + " " + DictionaryManagement.Activies[i]);
            }
            while (DictionaryManagement.Activies[a] != "True")
            {
                a = (int)Random.Range(1, DictionaryManagement.Num);
            }
            random = a;
         //   Debug.Log(a + DictionaryManagement.WordDic[a]);
         //   Debug.Log(a + DictionaryManagement.WordDic[a]);
        }
        if (DictionaryManagement.WordDic.ContainsKey(1) && DictionaryManagement.someActive && random != 0 && text != null) 
        {
            //Debug.Log(Language + "lan");
            if (Language == 0)
            {
                text.GetComponent<Text>().text = DictionaryManagement.TransDic[random];
            }
            else if(Language == 1)
            {
                text.GetComponent<Text>().text = DictionaryManagement.WordDic[random];
            }
            else if(Language == 2)
            {
                //b = Random.Range(1, 3);
                if (b == 1)
                {
                    text.GetComponent<Text>().text = DictionaryManagement.TransDic[random];
                }
                else if(b == 2)
                {
                    text.GetComponent<Text>().text = DictionaryManagement.WordDic[random];
                }
                b = 3;
            }
            else
            {
                text.GetComponent<Text>().text = " ";
            }
        }
        if (Cancel.toDel)
        {
            Debug.Log("Deleted");
            Destroy(_word);
            Destroy(text);
            CancelTab.SetActive(true);
            text1.GetComponent<Text>().text = DictionaryManagement.WordDic[random];
          //  Debug.Log(random);
            text2.GetComponent<Text>().text = DictionaryManagement.TransDic[random];
            Cancel.toDel = false;

         //  random = (int)Random.Range(1, DictionaryManagement.Num);
        }
        if (Approve.toUp)
        {
            AppCount++;
            counter.GetComponent<Text>().text = AppCount + "/" + FullCount;
            DictionaryManagement.Activies[random] = "False";
            DictionaryManagement.WordList[random].transform.Find("Edit").GetComponent<Edit>()._active.isOn = false;
            Approve.toUp = false;
            Managers.Data.SaveGameState();
            Destroy(_word);
            Destroy(text);
            DictionaryManagement.isPlaying = true;
            DictionaryManagement.IsSomeActive();
        }
        if (DictionaryManagement._back)
        {
            Destroy(_word);
            Destroy(text);
            FullCount = 0;
            AppCount = 0;
            counter.GetComponent<Text>().text = AppCount + "/" + FullCount;
        }
    }
}
