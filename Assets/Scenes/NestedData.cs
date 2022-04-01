using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class NestedData : MonoBehaviour
{
    public string playerName = "Henry";
    public int health = 20;
   // public int maxHealth = 50;
    public int score = 40;
   // public int maxScore = 500;
   
    [System.Serializable] //To access the whole class from editor.
    public class ToSeralizeTheData
    {
        public string playerName;
        public int health;
        //public int maxHealth;
        public int score;
       public int maxScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        ToSaveData();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.L))
        {
            LoadTheData();
        }
        
    }
    public void ToSaveData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        
         string filePath = Application.persistentDataPath + "/Jyothsna.Gajam";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        //BinaryWriter br = new BinaryWriter(File.OpenWrite(filePath));
        

        ToSeralizeTheData data = new ToSeralizeTheData();
        data.playerName = playerName;
        data.health = health;
            data.score = score;
        //data.maxScore = maxScore;
        binaryFormatter.Serialize(fs, data);
        fs.Close(); 






    }
    public void LoadTheData()
    {
        
        string filePath = Application.persistentDataPath + "/Jyothsna.Gajam";
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        ToSeralizeTheData data = binaryFormatter.Deserialize(fs) as ToSeralizeTheData;
        Debug.Log(data.playerName);
        Debug.Log(data.score);
        Debug.Log(data.health);
        // Debug.Log(data);
        string myDate = data.ToString();
       // Debug.Log(myDate);
        fs.Close();






    }

}
