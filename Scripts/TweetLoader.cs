
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class TweetLoader : MonoBehaviour {
    public static string json;

    dynamic TweetData = JsonConvert.DeserializeObject<dynamic>(json);


        Tweet Tweet = new Tweet();
        // {
        //     Latitude = locationData.result.latitude,
        //     Longitude = locationData.result.longitude
        // };

}




