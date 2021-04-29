using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[Serializable]
public class playerProgress
{
    public bool[] starsActive;
    public bool[] levelUnlocked;
    public int gems;
}
public class PlayerProgress : MonoBehaviour
{


    public static PlayerProgress _PlayerProgress;
    public playerProgress _playerProgress;



   
    void Awake()
    {
        
        if (_PlayerProgress == null)
        {
            DontDestroyOnLoad(this.gameObject);
            _PlayerProgress = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Load();
    }


    private void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/settings.dat", FileMode.Create);
        playerProgress data = new playerProgress();
        data = _playerProgress;
        formatter.Serialize(file, data);
        file.Close();


    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/settings.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/settings.dat", FileMode.Open);
            _playerProgress = formatter.Deserialize(file) as playerProgress;
            file.Close();
        }
        else
        {
            
            for(int i = 0; i < _playerProgress.starsActive.Length; i++)
            {
                _playerProgress.starsActive[i] = false;
            }
            _playerProgress.levelUnlocked[0] = true;
        }

    }
}
