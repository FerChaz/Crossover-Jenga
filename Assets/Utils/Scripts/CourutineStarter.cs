using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourutineStarter : MonoBehaviour
{
    public static CourutineStarter Instance;
    private void Awake()
    {
        Instance = this;
    }
}
