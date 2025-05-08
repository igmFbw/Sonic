using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum actType
{
    idle,leftAttack,leftMove,rightMove,rightAttack
}
public class levelGlobalControl : MonoBehaviour
{
    public static levelGlobalControl instance;
    public player player;
    public enemy enemy;
    public actType actFps;
    public GameObject currentAperture;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        actFps = actType.idle;
    }
    private void OnDestroy()
    {
        instance = null;
    }
    public void setActType(actType type)
    {
        actFps = type;
        Invoke("clearCurrentFps", .419f);
    }
    public void clearCurrentFps()
    {
        actFps = actType.idle;
    }
}
