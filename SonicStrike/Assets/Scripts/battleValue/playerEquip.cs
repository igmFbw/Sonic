using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerEquip : MonoBehaviour,ISaveManager
{
    public static playerEquip _instance;
    public shield shieldEquip;
    public weapon weapnEquip;
    public int money;
    public int levelNum = 0;
    public bool isBattle = false;
    public int moneyAcquire;
    public static playerEquip instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<playerEquip>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("playerEquipControl");
                    _instance = go.AddComponent<playerEquip>();
                }
            }
            return _instance;
        }
    }
    public void loadData(gameData data)
    {
        money = data.money;
        levelNum = data.level;
        uiSthConrtol.instance.updateCoin();
        if (data.weaponEquip.quality == 0)
            weapnEquip = new weapon();
        else
        {
            weapon go = new weapon();
            foreach(var item in uiSthConrtol.instance.weaponBase)
            {
                if(item.quality == data.weaponEquip.quality)
                {
                    go.basicData = item;
                    break;
                }
            }
            go.level = data.weaponEquip.level;
            go.durability = data.weaponEquip.durable;
            go.power = Mathf.RoundToInt(go.basicData.basicPower) + (go.level - 1) * 5;
            go.calculateExp();
            weapnEquip = go;
        }
        if (data.shieldEquip.quality == 0)
            shieldEquip = new shield();
        else
        {
            shield go = new shield();
            foreach (var item in uiSthConrtol.instance.shieldBase)
            {
                if (item.quality == data.shieldEquip.quality)
                {
                    go.basicData = item;
                    break;
                }
            }
            go.durability = data.shieldEquip.durable;
            shieldEquip = go;
        }
    }
    public void saveData(ref gameData data)
    {
        data.money = money;
        data.level = levelNum;
        if (weapnEquip!=null&&weapnEquip.basicData != null)
        {
            weaponSaveData newWeapon = new weaponSaveData(weapnEquip.level, weapnEquip.durability, weapnEquip.basicData.quality);
            data.weaponEquip = newWeapon;
        }
        else
            data.weaponEquip = new weaponSaveData(0, 0, 0);
        if (shieldEquip != null && shieldEquip.basicData != null)
        {
            shieldSaveData newShield = new shieldSaveData(shieldEquip.basicData.quality,shieldEquip.durability);
            data.shieldEquip = newShield;
        }
        else
            data.shieldEquip = new shieldSaveData(0, 0);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}