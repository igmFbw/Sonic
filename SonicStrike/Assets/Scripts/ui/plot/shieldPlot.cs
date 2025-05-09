using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shieldPlot : itemPlots
{
    private shield shieldItem;
    public void setPlot(Sprite sprite, shield itemS)
    {
        itemSprite.sprite = sprite;
        shieldItem = itemS;
    }
}
