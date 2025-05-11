using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerBag : MonoBehaviour,ISaveManager
{
    public List<shield> shieldList;
    public List<weapon> weaponList;
    public void loadData(gameData data)
    {
        foreach(var item in data.shieldList)
        {
            shield go = new shield();
            foreach(var value in uiSthConrtol.instance.shieldBase)
            {
                if (value.quality == item.quality)
                    go.basicData = value;
            }
            go.durability = item.durable;
            shieldList.Add(go);
        }
        foreach (var item in data.weaponList)
        {
            weapon go = new weapon();
            foreach (var value in uiSthConrtol.instance.weaponBase)
            {
                if (value.quality == item.quality)
                    go.basicData = value;
            }
            go.durability = item.durable;
            go.level = item.level;
            go.power = Mathf.RoundToInt(go.basicData.basicPower) + (go.level - 1) * 5;
            go.calculateExp();
            weaponList.Add(go);
        }
    }
    public void saveData(ref gameData data)
    {
        data.shieldList.Clear();
        data.weaponList.Clear();
        if (shieldList.Count>0)
        {
            data.shieldList.Clear();
            foreach(var item in shieldList)
            {
                shieldSaveData go = new shieldSaveData(item.basicData.quality,item.durability);
                data.shieldList.Add(go);
            }
        }
        if (weaponList.Count > 0)
        {
            foreach (var item in weaponList)
            {
                weaponSaveData go = new weaponSaveData(item.level,item.durability,item.basicData.quality);
                data.weaponList.Add(go);
            }
        }
    }
    private void Awake()
    {
        shieldList = new List<shield>();
        weaponList = new List<weapon>();
    }
}
