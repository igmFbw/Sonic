using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class uiSthConrtol : MonoBehaviour
{
    public static uiSthConrtol instance;
    private void Awake()
    {
        instance = this;
    }
}
