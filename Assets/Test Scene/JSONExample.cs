using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONExample : MonoBehaviour
{
    //serialize data to a JSON file

    SampleData sample = new SampleData();

    void Start()
    {
        SampleData sample = new SampleData();
        sample.name = "Mike";
        sample.score = 10.0f;

        string data = JsonUtility.ToJson(sample);
        Debug.Log(data);

        //deserialization JSON to data 
        string JSON = "{\n\t\"name";
      }
}
