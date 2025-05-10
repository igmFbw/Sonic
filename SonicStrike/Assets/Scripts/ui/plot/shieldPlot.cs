using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class shieldPlot : itemPlots,IPointerClickHandler
{
    private shield shieldItem;

    public void OnPointerClick(PointerEventData eventData)
    {
        uiSthConrtol.instance.shieldTip.setImage(shieldItem.basicData.itemSprite,shieldItem,GetComponent<RectTransform>().position);
    }

    public void setPlot(Sprite sprite, shield itemS)
    {
        itemSprite.sprite = sprite;
        shieldItem = itemS;
    }
}
