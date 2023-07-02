using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edit : MonoBehaviour
{
    public static bool edit = false;
    //private bool _edit = false;
    public int LocalNum =1;
    public Toggle Active;
    public Toggle _active;
    public InputField Word;
    public InputField Translate;
    public static int WorldNum;
    public GameObject AddList;
    public Button button;
    void Start()
    {
        edit = false;
        AddList.SetActive(false);
        button = this.GetComponent<Button>();
        button.onClick.AddListener(Add);
        _active.onValueChanged.AddListener(delegate { Changing(); });
    }
    void Changing()
    {
        Debug.Log(LocalNum + _active.isOn.ToString());
        DictionaryManagement.Activies[LocalNum] = _active.isOn.ToString();
        Managers.Data.SaveGameState();
        DictionaryManagement.IsSomeActive();
    }
    void Add()
    {
        WorldNum = LocalNum;
        Tap.Tapped = false;
        Word.text = DictionaryManagement.WordDic[WorldNum];
        Translate.text = DictionaryManagement.TransDic[WorldNum];
        AddList.SetActive(true);
        edit = true;
        Active.isOn = _active.isOn;
    }
    //IEnumerator waiting()
    //{
    //    _edit = true;
    //    while (AddList.activeSelf)
    //    {
    //        yield return null;
    //    }
    //    _edit = false;
    //}
    // Update is called once per frame
    void Update()
    {
        //if (DictionaryManagement.ActiveEdit && _edit)
        //{
        //    _active.isOn = !_active.isOn;
        //    DictionaryManagement.ActiveEdit = false;
        //}
    }
}
