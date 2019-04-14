
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class Tweet : MonoBehaviour {
    public string created_at;
    public string text;

    public bool truncated;

    public string screen_name;

    // empty constructor
    public Tweet(){

    }




}
