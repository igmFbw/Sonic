using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uiSthConrtol : MonoBehaviour
{
    public static uiSthConrtol instance;
    public playerBag bag;
    public bagUI bagui;
    public shieldEquipPlot shieldPlot;
    public weaponEquipPlot weaponPlot;
    public shieldInformation shieldTip;
    public weaponInformation weaponTip;
    public Text powerText;
    public tipTap tip;
    public Text coinText;
    [SerializeField] private Transform tipParent;
    public GameObject blackImage;
    public List<weaponData> weaponBase;
    public List<shieldData> shieldBase;
    public saveManager saveManage;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        updateCoin();
    }
    public void OnDestroy()
    {
        instance = null;
    }
    public void setTip(string str)
    {
        tipTap go = Instantiate(tip, tipParent);
        go.setText(str);
    }
    public void updateCoin()
    {
        coinText.text = ":" + playerEquip.instance.money;
    }
}
