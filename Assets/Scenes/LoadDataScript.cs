using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; //To load and Save the data.

public class LoadDataScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name = "Happy Birthday";
    public int age = 20;
    public float floatValue = 12.9f;
    public double doubleValue = 38.9999f;
    public string nameText = "Akul";
    public string fileName = @"C:\Users\Jyothsna.Gajam\Documents\MyData\SampleData.txt";
    void Start()
    {
        /*
        if(File.Exists(fileName))
        {
            using FileStream fileStream = File.Open(fileName, FileMode.Open);
            using BinaryWriter binaryWriter = new (fileStream);
            age = binaryWriter.ReadInt32();
            print("Hello");
        }*/
        
       // BinaryWriter bw = new BinaryWriter();
     /* StreamWriter streamWriter = new StreamWriter(fileName);
        streamWriter.WriteLine(age);
       streamWriter.Close();
       
        
       

        StreamReader reader = new StreamReader(fileName);
       // Debug.Log(reader.ReadLine());
        Debug.Log(reader.ReadToEnd());
        reader.Close();*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            
            CreateText();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            ReadText();
        }


    }
    private void CreateText()
    {
        Debug.Log("W is Pressed");
        FileStream fileStream = new FileStream(fileName, FileMode.Open);
        BinaryWriter bw = new BinaryWriter(fileStream);
        bw.Write(age);
        bw.Write(Name);
        
        bw.Close();
        fileStream.Close();
    }
    private void ReadText()
    {
        Debug.Log("R is Pressed");
        FileStream fileStream = new FileStream(fileName, FileMode.Open);
        BinaryReader br = new BinaryReader(fileStream);
       Debug.Log( br.Read());
        Debug.Log( br.ReadString());
       // br.Write(Name);
        br.Close();
        fileStream.Close();
    }
}
