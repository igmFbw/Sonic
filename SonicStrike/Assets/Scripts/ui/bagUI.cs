using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bagUI : MonoBehaviour
{
    [SerializeField] private playerBag bag;
    [SerializeField] private weaponPlot weaponPlotPrefab;
    [SerializeField] private shieldPlot shieldPlotPrefab;
    [SerializeField] private Transform itemPlotParent;
    [SerializeField] private List<itemPlots> plotList;
    private void Awake()
    {
        plotList = new List<itemPlots>();
    }
    public void openBag(int type)
    {
        cleanPlot();
        if (type == 0)
        {
            foreach(var item in bag.weaponList)
            {
                weaponPlot go = Instantiate(weaponPlotPrefab, itemPlotParent);
                go.setPlot(item.basicData.itemSprite,item);
                plotList.Add(go);
            }
        }
        else
        {
            foreach (var item in bag.shieldList)
            {
                shieldPlot go = Instantiate(shieldPlotPrefab, itemPlotParent);
                go.setPlot(item.basicData.itemSprite, item);
                plotList.Add(go);
            }
        }
    }
    private void OnDisable()
    {
        cleanPlot();
    }
    private void cleanPlot()
    {
        foreach (var item in plotList)
        {
            Destroy(item.gameObject);
        }
        plotList.Clear();
    }
}
