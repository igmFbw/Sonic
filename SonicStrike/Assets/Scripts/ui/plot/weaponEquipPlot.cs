using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class weaponEquipPlot : equipPlot
{
    private weapon equipItem;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        bag.openBag(0);
    }
    public void updateImage(weapon item)
    {
        equipItem = item;
        itemSprite.sprite = equipItem.basicData.itemSprite;
    }
}
