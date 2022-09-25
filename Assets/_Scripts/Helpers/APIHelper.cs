using System.Net;
using System.IO;
using UnityEngine;

public class APIHelper
{
    public static Joke GetJoke()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Joke>(json);
    }
}
