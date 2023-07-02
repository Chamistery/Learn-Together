using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DictionaryManagement : MonoBehaviour
{
    [SerializeField] GameObject stay;
    [SerializeField] GameObject GameBack;
    [SerializeField] GameObject learn;
    [SerializeField] GameObject leave;
    [SerializeField] GameObject background;
    [SerializeField] GameObject backing;
    [SerializeField] GameObject clovar;
    [SerializeField] GameObject counter;
    [SerializeField] GameObject Onquit;
    [SerializeField] GameObject CancelTab;
    [SerializeField] GameObject destroy;
    //public RectTransform arrow;
    //[SerializeField] Color backgroundActiveColor;
    //[SerializeField] Color handleActiveColor;
    //[SerializeField]  Color backgroundDefaultColor;
    //[SerializeField] Color handleDefaultColor;
    //private bool Dropped;
    public GameObject NewWord;
   // public VerticalLayoutGroup Group;
    public GameObject D;
    public GameObject AddList;
    public static bool someActive;
    public GameObject dict;
    public Text text;
   // public static bool ActiveEdit;
    public static bool edit;
    public static bool del;
    public static bool _active = true;
    public bool tapped = false;
    //public Text WordShow;
    //private Text TransShow;
    public InputField Word;
    //static int num = 0;
    public InputField Translate;
    public bool IsEdit;
   // private int deleted = 0;
    public bool IsTrans;
    public Toggle Active;
    public static bool _back;
    public static int Num = 1;
    public static bool isPlaying = false;
    public static Dictionary<int, string> WordDic = new Dictionary<int, string>();
    public static Dictionary<int, string> TransDic = new Dictionary<int, string>();
    public static   Dictionary<int, GameObject> WordList = new Dictionary<int, GameObject>();
    public static Dictionary<int, string> Activies = new Dictionary<int, string>();
    public static int toDestroy = 0;
    private bool cleared;
   // private bool isLoaded;
    // Start is called before the first frame update
    private void Awake()
    {
        destroy.SetActive(false);
        toDestroy = 0; 
        Num = 1;
        dict.SetActive(true);
        Managers.Data.LoadGameState();
        //WordDic.Clear();
        //WordList.Clear();
        //TransDic.Clear();
        //Activies.Clear();
        if (WordDic.ContainsKey(1))
        {
           // isLoaded = true;
            //  Debug.Log(WordDic[1]);
            Num = WordDic.Count;
            for (int i = 1; i <= Num; i++)
            {
                if (WordDic.ContainsKey(i) && TransDic.ContainsKey(i))
                {
                    CreateWord(WordDic[i], TransDic[i], true, i);
                }
            }
            Num++;
            IsSomeActive();
        }
        //for (int i = 1; i < WordDic.Count; i++)
        //{

        //    Activies.Add(i, "true");
        //}
    }
    public void OnDestroy()
    {
        toDestroy++;
        if(toDestroy == 5)
        {
            destroy.SetActive(true);
        }
    }
    public void clear()
    {
        WordDic.Clear();
        WordList.Clear();
        TransDic.Clear();
        Activies.Clear();
        cleared = true;
        //GameObject[] des = GameObject.FindGameObjectsWithTag("Word");
        //foreach (var item in des)
        //{
        //    Destroy(item);
        //}
        Num = 1;
        toDestroy = 0;
        destroy.SetActive(false);
        IsSomeActive();
    }
    public void Canceltab()
    {
        CancelTab.SetActive(false);
        isPlaying = true;
    }
    public void OnQuit()
    {
        Onquit.SetActive(true);
    }
    public void NotQuit()
    {
        Onquit.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    void Start()
    {
        isPlaying = false;
        //for (int i = 1; i < Num; i++)
        //{
        //    Debug.Log(Activies[i] + " " + WordDic[i] + " " + i);
        //}
        stay.SetActive(false);
        GameBack.SetActive(false);
        backing.SetActive(false);
        counter.SetActive(false);
        Onquit.SetActive(false);
        D.SetActive(false);
        tapped = false;
        // Debug.Log(Num + " " + WordDic + " " + TransDic + " ");
        AddList.SetActive(false);
        IsSomeActive();
    }
    public void Back()
    {
        dropDown.clicked = false;
        CancelTab.SetActive(false); 
        _back = true;
        stay.SetActive(false);
        GameBack.SetActive(false);
        background.SetActive(true);
        clovar.SetActive(true);
        counter.SetActive(false);
        D.SetActive(false);
        leave.SetActive(true);
        learn.SetActive(true);
        backing.SetActive(false);
    }
    public void StartLearn()
    {
        Playing.Language = 3;
        _back = false;
        isPlaying = true;
        stay.SetActive(true);
        GameBack.SetActive(true);
        background.SetActive(false);
        clovar.SetActive(false);
        counter.SetActive(true);
        D.SetActive(false);
        leave.SetActive(false);
        learn.SetActive(false);
        backing.SetActive(true);

    }
    public void OpenD()
    {
        D.SetActive(true);
        leave.SetActive(false);
    }
    public void Delete()
    {
        if (!cleared) 
        {
            if (Tap.Tapped)
            {
                GameObject toDel = GameObject.FindGameObjectWithTag("ToDelete");
                int loc = toDel.GetComponent<Tap>().LocalNum;
                Destroy(toDel);
                if (Num != 2)
                {
                    for (int i = loc; i < Num - 1; i++)
                    {
                        WordDic.Remove(i);
                        TransDic.Remove(i);
                        Activies.Remove(i);
                        WordList.Remove(i);
                        // Debug.Log(WordDic[i + 1]);
                        WordDic.Add(i, WordDic[i + 1]);
                        TransDic.Add(i, TransDic[i + 1]);
                        Activies.Add(i, Activies[i + 1]);
                        WordList.Add(i, WordList[i + 1]);
                        GameObject a = (GameObject)WordList[i];
                        a.transform.Find("count").gameObject.GetComponent<Text>().text = i.ToString();
                    }
                    for (int j = 1; j < loc; j++)
                    {
                        GameObject a = (GameObject)WordList[j];
                        a.transform.position = new Vector3(0, WordList[j].transform.position.y + 200, 0);
                    }
                    // WordDic.Remove(Num);
                    WordDic.Remove(Num - 1);
                    TransDic.Remove(Num - 1);
                    WordList.Remove(Num - 1);
                    Activies.Remove(Num - 1);
                }
                else
                {
                    Debug.Log(loc);
                    WordDic.Remove(loc);
                    TransDic.Remove(loc);
                    WordList.Remove(loc);
                    Activies.Remove(loc);
                }
                // dict.GetComponent<RectTransform>().sizeDelta = new Vector2(480, 200 * Num);
                Num--;
                del = true;
                IsSomeActive();
                Tap.Tapped = false;
                Managers.Data.SaveGameState();
            }
            
        }
        else
        {
            if(GameObject.FindGameObjectWithTag("ToDelete")!= null){
                Destroy(GameObject.FindGameObjectWithTag("ToDelete"));
            }
        }
    }
    //public void Edit()
    //{
    //    AddList.SetActive(true);
    //    Word.text = GameObject.Find("Слово(clone)/WordS").GetComponent<Text>().text;
    //    Translate.text = GameObject.Find("Слово(clone)/TransS").GetComponent<Text>().text;
    //    edit = true;
    //}
    public void Activing(bool active)
    {
        _active = active;
    }
    public void OK()
    {
        AddList.SetActive(false);


        if (IsEdit && IsTrans && Edit.edit)
        {
            GameObject b = WordList[Edit.WorldNum];
            b.transform.Find("WordS").GetComponent<Text>().text = Word.text;
            b.transform.Find("TransS").GetComponent<Text>().text = Translate.text;
            b.transform.Find("Edit").GetComponent<Edit>()._active.isOn = _active;
            WordDic[Edit.WorldNum] = Word.text;
            TransDic[Edit.WorldNum] = Translate.text;
            Activies.Remove(Edit.WorldNum);
            Activies.Add(Edit.WorldNum, _active.ToString());
            IsSomeActive();
            Debug.Log(3);
         //   Debug.Log(Activies[Edit.WorldNum] + " " + Edit.WorldNum);
            Managers.Data.SaveGameState();
        }
        else if (IsTrans && Edit.edit)
        {
            GameObject b = WordList[Edit.WorldNum];
            b.transform.Find("TransS").GetComponent<Text>().text = Translate.text;
            b.transform.Find("Edit").GetComponent<Edit>()._active.isOn = _active;
            TransDic[Edit.WorldNum] = Translate.text;
            Activies.Remove(Edit.WorldNum);
            Activies.Add(Edit.WorldNum, _active.ToString());
            IsSomeActive();
            Debug.Log(2);
            Managers.Data.SaveGameState();
        }
        else if (IsEdit && Edit.edit)
        {
            GameObject b = WordList[Edit.WorldNum];
            b.transform.Find("WordS").GetComponent<Text>().text = Word.text;
            b.transform.Find("Edit").GetComponent<Edit>()._active.isOn = _active;
            Activies.Remove(Edit.WorldNum);
            WordDic[Edit.WorldNum] = Word.text;
            Activies.Add(Edit.WorldNum, _active.ToString());
            IsSomeActive();
            Debug.Log(20);
            Managers.Data.SaveGameState();
        }
        else if (Edit.edit)
        {
            WordList[Edit.WorldNum].transform.Find("Edit").GetComponent<Edit>()._active.isOn = _active;
            Activies.Remove(Edit.WorldNum);
            Activies.Add(Edit.WorldNum, _active.ToString());
            IsSomeActive();
            //   Debug.Log(Activies[Edit.WorldNum] + " " + Edit.WorldNum);
            Debug.Log(1);
            Managers.Data.SaveGameState();
        }
        else if (IsTrans && IsEdit)
        {
            CreateWord(Word.text, Translate.text, false, 0);
            IsSomeActive();
            Managers.Data.SaveGameState();
        }
        //for (int i = 1; i < Num; i++)
        //{
        //    Debug.Log(i + " " + WordDic[i]);
        //}
        Edit.edit = false;
        //IsEdit = false;
        //IsTrans = false;
    }
    private void Update()
    {
        
        if (Word.text != "")
        {
            IsEdit = true;
        }
        else
        {
            IsEdit = false;
        }
        if (Translate.text != "")
        {
            IsTrans = true;
        }
        else
        {
            IsTrans = false;
        }
    }
    public void CreateWord(string Word, string Trans, bool Load, int Count)
    {
        GameObject ThisWord = Instantiate(NewWord, new Vector3(-400, 400, 0), Quaternion.identity, dict.transform);
        ThisWord.transform.SetAsFirstSibling();
        if (Load)
        {
            ThisWord.GetComponent<Tap>().LocalNum = Count;
            ThisWord.transform.Find("Edit").GetComponent<Edit>().LocalNum = Count;
        }
        else
        {
            ThisWord.GetComponent<Tap>().LocalNum = Num;
            ThisWord.transform.Find("Edit").GetComponent<Edit>().LocalNum = Num;
        }
      //  ThisWord.transform.Find("Edit").GetComponent<Edit>().LocalNum = Num;
        ThisWord.transform.Find("Edit").GetComponent<Edit>().Word = this.Word;
        ThisWord.transform.Find("Edit").GetComponent<Edit>().Translate = Translate;
        ThisWord.transform.Find("Edit").GetComponent<Edit>().AddList = AddList;
        Debug.Log(ThisWord.GetComponent<Tap>().LocalNum);
        ThisWord.transform.Find("Edit").GetComponent<Edit>().Active = Active;
        ThisWord.transform.Find("Edit").GetComponent<Edit>()._active.isOn = _active;
        Text count = Instantiate(text, new Vector3(ThisWord.transform.position.x -180, ThisWord.transform.position.y+90, 0), Quaternion.identity, ThisWord.transform);
        Text WordS = Instantiate(text, new Vector3(ThisWord.transform.position.x, ThisWord.transform.position.y + 35, 0), Quaternion.identity, ThisWord.transform);
        Text TransS = Instantiate(text, new Vector3(ThisWord.transform.position.x, ThisWord.transform.position.y  - 65, 0), Quaternion.identity, ThisWord.transform);
        if (!WordList.ContainsKey(Num))
        {
            WordList.Add(Num, ThisWord);
        }
        else
        {
            WordList.Remove(Num);
            WordList.Add(Num, ThisWord);
        }
        if (Num != 1 && !Load)
        {
            for (int i = 1; i <= Num; i++)
            {
                if(WordList.ContainsKey(i))
                  WordList[i].transform.position = new Vector3(-100, WordList[i].transform.position.y + 200, 0);
            }
        }
        else if (Num != 1)
        {
            if(WordList.ContainsKey(Count))
                 WordList.Remove(Count);
            WordList.Add(Count, ThisWord);
            if(Activies.ContainsKey(Count))
                ThisWord.transform.Find("Edit").GetComponent<Edit>()._active.isOn = true ? Activies[Count] == "True" : false;
 //           Debug.Log(Activies[Count]);
            WordList[Count].transform.position = new Vector3(-100, WordList[Count].transform.position.y - 200, 0);
        }
        if (Load)
        {
            ThisWord.transform.Find("Edit").GetComponent<Edit>()._active.isOn = true ? Activies[Count] == "True" : false;
            count.text = Count.ToString();
        }
        else
        {
            Activies.Remove(Num);
            Activies.Add(Num, _active.ToString());
            Num++;
            count.text = ThisWord.GetComponent<Tap>().LocalNum.ToString();
        }
        count.name = "count";
        WordS.name = "WordS";
        TransS.name = "TransS";
        IsSomeActive();

        WordS.text = Word;
        TransS.text = Trans;
    }
    public static void IsSomeActive()
    {
        someActive = false;
        for (int i = 1; i < Num; i++)
        {
            if(Activies.ContainsKey(i)&& Activies[i] == "True")
               someActive = true;
            if(Activies.ContainsKey(i))
              Debug.Log(someActive + " " + i);
           // Debug.Log(Activies[i]);
        }
    }
    public void Cancel()
    {
        AddList.SetActive(false);
        IsEdit = false;
        IsTrans = false;
        Edit.edit = false;
    }
    public void Editing(string word)
    {
        if (Edit.edit)
        {
            if (word != "")
            {
                WordDic.Remove(Num);
                WordDic.Add(Num, word);
                Word.text = word;
                IsEdit = true;
            }
            else
            {
                IsEdit = false;
            }
        }
        else if (!WordDic.ContainsKey(Num))
        {
            
            if (word != "")
            {
                WordDic.Add(Num, word);
                Word.text = word;
                IsEdit = true;
            }
            else
            {
                IsEdit = false;
            }
        }
        else
        {
            
            if (word != "")
            {
                WordDic.Remove(Num);
                WordDic.Add(Num, word);
                Word.text = word;
                IsEdit = true;
            }
            else
            {
                IsEdit = false;
            }
        }
    }
    public void Translating(string trans)
    {
        if (Edit.edit)
        {
            
            if (trans != "")
            {
                TransDic.Remove(Num);
                TransDic.Add(Num, trans);
                Translate.text = trans;
                IsTrans = true;
            }
            else
            {
                IsTrans = false;
            }
        }
        else if (!TransDic.ContainsKey(Num))
        {
            
            if (trans != "")
            {
                TransDic.Add(Num, trans);
                Translate.text = trans;
                IsTrans = true;
            }
            else
            {
                IsTrans = false;
            }
        }
        else
        {
            
            if (trans != "")
            {
                TransDic.Remove(Num);
                TransDic.Add(Num, trans);
                Translate.text = trans;
                IsTrans = true;                
            }
            else
            {
                IsTrans = false;
            }
        }
    }
    public void Adding()
    {
        cleared = false;
       // Managers.Data.LoadGameState();
        Tap.Tapped = false;
        AddList.SetActive(true);
        Word.text = "";
        Translate.text = "";
        Active.isOn = true;
    } 
}
