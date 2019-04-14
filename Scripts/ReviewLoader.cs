
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]

public class ReviewLoader
{
    public Review[] allReviews;

    public string json_filename;


    public void setReviews(string json_filename)
    {

        string path = Path.Combine(Application.streamingAssetsPath, "json_reviews/" + json_filename);
        // If file exists, return the review objects, if not return an empty review object
        if (File.Exists(path))
        {
            string json_string = File.ReadAllText(path);
            Debug.Log(json_string);
            this.allReviews = JsonHelper.FromJson<Review>(json_string);
            //reminder -- call allLines[i].review/name/whatever


        }
        else
        {
            Debug.Log("HEY YALLL HE OUT HERE EATIN BEANS");
            allReviews = new Review[0];
        }


    }




    // revcieved this wrapper code from
    // https://stackoverflow.com/questions/39982677/parsing-json-string-into-objects-then-into-list-using-litjson
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.reviews;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.reviews = array;
            return UnityEngine.JsonUtility.ToJson(wrapper);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] reviews;
        }
    }
}