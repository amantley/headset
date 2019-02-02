using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class readwrite : MonoBehaviour
{
    public GameObject head;
    public GameObject pelvis;
    StreamWriter writer;

    bool startParsing;
    StreamReader reader;

    [MenuItem("Tools/Write file")]

    void Start()
    {
        string timeNow = System.DateTime.UtcNow.ToString("HH_mm_dd_MMMM_yyyy");
        // returns "12:48 15 April, 2013"
      
        startParsing = false;
        string path = "C://Cucard_Logs/" +  "logfile_" + timeNow + ".txt";
        //asset.
        //Write some text to the test.txt file
        writer = new StreamWriter(path, true);
      
        // string path = "Assets/Captures/walk2trim.txt";

        // Read the text from directly from the test.txt file
        // reader = new StreamReader(path);


    }

    void WriteString()
    {
        System.DateTime timeSlice = System.DateTime.UtcNow;

        writer.WriteLine(timeSlice.Hour.ToString() + timeSlice.Minute.ToString() + timeSlice.Second.ToString() + timeSlice.Millisecond.ToString() + " head" + head.transform.position.ToString("F4"));
        //writer.WriteLine( head.transform.position.x.ToString("F4")+ " " + head.transform.position.y.ToString("F4")+ " " + head.transform.position.z.ToString("F4") + " " + pelvis.transform.position.x.ToString("F4") + " " + pelvis.transform.position.y.ToString("F4") + " " + pelvis.transform.position.z.ToString("F4") + " " );
        writer.WriteLine(timeSlice.Hour.ToString() + timeSlice.Minute.ToString() + timeSlice.Millisecond.ToString() + " pelvis" + pelvis.transform.position.ToString("F4"));
        //writer.Close();

        //Re-import the file to update the reference in the editor
        // AssetDatabase.ImportAsset(path);
        // TextAsset asset = Resources.Load("test");

        //Print the text from the file
        // Debug.Log(asset.text);
    }

    [MenuItem("Tools/Read file")]
    void ReadString()
    {
        Debug.Log("in the read string function");
        string nums;
        
        if (reader != null)
        {
            
                
            nums = reader.ReadLine();
            if (nums != null)
            {
                /*
                Debug.Log(count + "is the count");
                string[] values = nums.Split();
                Debug.Log(values.Length + "is the number of values");
                // fill up the array first
                */
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("m"))
        {
            startParsing = true;
        }

        if (startParsing)
        {
            // write to file
            WriteString();
            // read file
            // ReadString();
        }
        if (Input.GetKeyDown("n"))
        {
            //writer.Close();
        }
    }

    void OnApplicationQuit()
    {
        writer.Close();
        // Debug.Log("Application ending after " + Time.time + " seconds");
    }

}