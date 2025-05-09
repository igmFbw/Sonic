using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class uiSthConrtol : MonoBehaviour
{
    public static uiSthConrtol instance;
    public playerBag bag;
    public bagUI bagui;
    public shieldEquipPlot shieldPlot;
    public weaponEquipPlot weaponPlot;
    private void Awake()
    {
        instance = this;
    }
    public void OnDestroy()
    {
        instance = null;
    }
}
