using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class shieldEquipPlot : equipPlot
{
    private shield equipItem;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        bag.openBag(1);
    }
    public void updateImage(shield item)
    {
        equipItem = item;
        itemSprite.sprite = equipItem.basicData.itemSprite;
    }
}
