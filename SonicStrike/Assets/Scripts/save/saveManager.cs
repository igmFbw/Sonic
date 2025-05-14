using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class saveManager : MonoBehaviour
{    
    private List<ISaveManager> saveManagers;
    public gameData data;
    private fileDataHandler dataHandler;
    private void Awake()
    {
        saveManagers = findAllSaveManagers();
        dataHandler = new fileDataHandler(@"D:\gameSave", "gameData");
        data = new gameData();
        loadGame();
        if(playerEquip.instance.isBattle)
        {
            playerEquip.instance.isBattle = false;
            if (playerEquip.instance.shieldEquip != null && playerEquip.instance.shieldEquip.durability>=20)
                playerEquip.instance.shieldEquip.durability -= 20;
            if (playerEquip.instance.shieldEquip != null && playerEquip.instance.weapnEquip.durability>=20)
                playerEquip.instance.weapnEquip.durability -= 20;
            playerEquip.instance.money += playerEquip.instance.moneyAcquire;
            playerEquip.instance.levelNum = playerEquip.instance.levelNumAcquire;
            uiSthConrtol.instance.updateCoin();
        }
    }
    public void loadGame()
    {
        data = dataHandler.load();
        if (data == null)
        {
            data = new gameData();
            return;
        }
        foreach (var manager in saveManagers)
        {
            manager.loadData(data);
        }
    }
    public void saveGame()
    {
        foreach (var manager in saveManagers)
        {
            manager.saveData(ref data);
        }
        dataHandler.save(data);
    }
    private List<ISaveManager> findAllSaveManagers()
    {
        IEnumerable<ISaveManager> ISaveManagers = FindObjectsOfType<MonoBehaviour>().OfType<ISaveManager>();
        return new List<ISaveManager>(ISaveManagers);
    }
    public void OnApplicationQuit()
    {
        saveGame();
    }
}
