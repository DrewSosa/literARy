using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]

public class load_reviewslegacy: MonoBehaviour {
    public LineData[] allLines;
    public string json_filename;


    void Start()
    {

        allLines = getReviews(json_filename);
    }
        public static LineData[] getReviews(string json_filename)
    {
        string path =  Path.Combine(Application.streamingAssetsPath, json_filename);
        string json_string = File.ReadAllText(path);
        Debug.Log(json_string);
        LineData[] allLines = JsonHelper.FromJson<LineData>(json_string);
        Debug.Log(allLines[0].review);
        return allLines;
    }


    public class LineDataCollection {
    public LineData lines;
}

[System.Serializable]
    public class LineData
        {
         public string name;
        public string first_sentence;
        public string review;
        public int stars;
        public int tag;
    }


public static class JsonHelper {

    public static T[] FromJson<T>(string json) {
        Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.reviews;
    }

    public static string ToJson<T>(T[] array) {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.reviews = array;
        return UnityEngine.JsonUtility.ToJson(wrapper);
    }

    [System.Serializable]
    private class Wrapper<T> {
        public T[] reviews;
    }
}
}