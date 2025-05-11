using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class weaponSaveData
{
    public int level;
    public int durable;
    public int quality;
    public weaponSaveData(int level, int durable, int quality)
    {
        this.level = level;
        this.durable = durable;
        this.quality = quality;
    }
}
