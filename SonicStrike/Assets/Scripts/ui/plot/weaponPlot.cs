using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class weaponPlot : itemPlots,IPointerClickHandler
{
    private weapon weaponItem;
    public void setPlot(Sprite sprite, weapon itemS)
    {
        itemSprite.sprite = sprite;
        weaponItem = itemS;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        uiSthConrtol.instance.weaponTip.setImage(weaponItem.basicData.itemSprite, weaponItem, GetComponent<RectTransform>().position);
    }
}
