using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataLoggerScript : MonoBehaviour
{
    public string filename = "log.txt";
    
    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        OnApplicationStart();
    }

    // Update is called once per frame
    void Update()
    {
        using (StreamWriter writer = File.AppendText(filename))
        {
            if (Input.GetKeyDown("space"))
            {
                DateTime now = DateTime.Now;
                writer.WriteLine(now.ToString() + "     Spacebar pressed");
            }
        }
 
    }

    public void OnClick()
    {
        using (StreamWriter writer = File.AppendText(filename))
        {
            DateTime now = DateTime.Now;
            writer.WriteLine(now.ToString() + "     Button clicked");
        }
    }
    private void OnApplicationStart()
    {
        //writes current time to file
        using (StreamWriter writer = new StreamWriter(filename))
        {
            DateTime now = DateTime.Now;
            writer.WriteLine(now.ToString() + "     Application opened");
        }
    }

    private void OnApplicationQuit()
    {
        using (StreamWriter writer = File.AppendText(filename))
        {
            DateTime now = DateTime.Now;
            writer.WriteLine(now.ToString() + "     Application closed");
        }
    }

    private void CreateFile()
    {
        if(!File.Exists(filename))
        {
            File.Create(filename).Close();
        }
    }


    
}
