using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class shieldSaveData 
{
    public int quality;
    public int durable;
    public shieldSaveData(int quality, int durable)
    {
        this.quality = quality;
        this.durable = durable;
    }
}
