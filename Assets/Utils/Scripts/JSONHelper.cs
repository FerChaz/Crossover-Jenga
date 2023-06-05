using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JSONHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.items;
    }

    public static string FixJSON(string value)
    {
        return "{\"items\":" + value + "}";
    }
    
    [Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
