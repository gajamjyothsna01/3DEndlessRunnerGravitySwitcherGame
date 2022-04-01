using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SerializeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string filePath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            LoadData();
        }
        
    }
    private void SaveData()
    {
        filePath =Application.persistentDataPath + "/MyFile.Jyothsna";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
         bw.Write("Hello!My Name is Jyothsna");
        bw.Write("My Working in XCUBE Labs");
        bw.Write("I am from Hyderabad");
        bw.Write("Secunderabad");
        bw.Write(13.9f);
        bw.Write(4);
       bw.Close();
       fs.Close();


        //fs.WriteLine("Hello! My Name is Jyothsna");


    }
    private void LoadData()
    {
        // BinaryReader br = new BinaryReader(File.OpenRead(filePath));

        filePath = Application.persistentDataPath + "/MyFile.Jyothsna";
        FileStream fs = new FileStream(filePath, FileMode.Open);
        BinaryReader br = new BinaryReader(fs);
        Debug.Log("Reading the Data");
        //br.Read();
        Debug.Log(br.Read());
        Debug.Log(br.Read()); 
        Debug.Log(br.Read());
        Debug.Log(br.Read());
             Debug.Log(br.Read());
        Debug.Log(br.ReadInt32());
        br.Close(); 
       fs.Close();
        

    }
}
