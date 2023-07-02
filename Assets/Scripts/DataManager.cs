using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
//using UnityEditor.VersionControl;
using UnityEngine;

public class DataManager : MonoBehaviour, IGameManager
{
    //public bool Loaded { get; private set; }
    public ManagerStatus status { get; private set; }
    private string _filename;

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Data manager starting...");
        _network = service;
        _filename = Path.Combine(Application.persistentDataPath, "game.dat");
        status = ManagerStatus.Started;
    }

    public void SaveGameState() 
    {
        //for (int i = 1; i < DictionaryManagement.Num; i++)
        //{
        //    Debug.Log(DictionaryManagement.WordDic[i]);
        //}
        FileStream stream = File.Create(_filename);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, DictionaryManagement.TransDic);
        formatter.Serialize(stream, DictionaryManagement.WordDic);
        formatter.Serialize(stream, DictionaryManagement.Activies);
        //     formatter.Serialize(stream, DictionaryManagement.WordList);
        stream.Close();
        Debug.Log("Game is saved");
    }
    //public static bool Save(GameObject obj)
    //{
    //    string data;
    //    //Translate GameObject into path
    //    string assetPath = null;// = AssetDatabase.GetAssetPath();//(GameObject)data);
    //    if (assetPath == null) return false;
    //    else data = assetPath;

    //    //Encrypt Save Data (not nessecary, but nice to have)

    //    return true;
    //}

    public void LoadGameState()
    {
        if (!File.Exists(_filename))
        {
            Debug.Log("No saved game");
            return;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(_filename, System.IO.FileMode.Open);
        DictionaryManagement.TransDic = formatter.Deserialize(stream) as Dictionary<int, string>;
        DictionaryManagement.WordDic = formatter.Deserialize(stream) as Dictionary<int, string>;
        DictionaryManagement.Activies = formatter.Deserialize(stream) as Dictionary<int, string>;
        //    DictionaryManagement.WordList= formatter.Deserialize(stream) as Dictionary<int, GameObject>;
        stream.Close();

        //Loaded = true;
        Debug.Log("Game is loaded");
    }
}
