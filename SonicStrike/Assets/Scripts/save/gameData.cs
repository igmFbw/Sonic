using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class gameData
{
    public List<weaponSaveData> weaponList;
    public List<shieldSaveData> shieldList;
    public shieldSaveData shieldEquip;
    public weaponSaveData weaponEquip;
    public int level;
    public int money;
    public gameData()
    {
        weaponList = new List<weaponSaveData>();
        shieldList = new List<shieldSaveData>();
    }
}
