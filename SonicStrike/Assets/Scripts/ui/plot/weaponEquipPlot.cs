using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
public class weaponEquipPlot : equipPlot
{
    private weapon equipItem;
    private void Start()
    {
        if (playerEquip.instance.weapnEquip != null && playerEquip.instance.weapnEquip.basicData != null)
        {
            updateImage(playerEquip.instance.weapnEquip);
            uiSthConrtol.instance.powerText.text = (10 + equipItem.power).ToString();
        }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!bag.gameObject.activeSelf)
        {
            bag.gameObject.SetActive(true);
            bag.openBag(0);
        }
        else
        {
            if (equipItem == null || equipItem.basicData == null)
                return;
            playerEquip.instance.weapnEquip = null;
            itemSprite.sprite = whiteSprite;
            uiSthConrtol.instance.powerText.text = "10";
            uiSthConrtol.instance.bag.weaponList.Add(equipItem);
            bag.uodatePlots(0);
            equipItem = null;
        }
    }
    public void updateImage(weapon item)
    {
        equipItem = item;
        itemSprite.sprite = equipItem.basicData.itemSprite;
    }
}
