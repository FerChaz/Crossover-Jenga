using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIGateway
{
    private const string apiUrl = Configuration.APIURL; 

    public IEnumerator GetDataFromApi(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.ConnectionError)
            {
                callback?.Invoke(www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error retrieving data from the API:" + www.error);
            }
        }
    }
}
