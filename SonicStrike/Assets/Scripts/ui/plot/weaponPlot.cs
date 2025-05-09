using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class weaponPlot : itemPlots
{
    private weapon weaponItem;
    public void setPlot(Sprite sprite, weapon itemS)
    {
        itemSprite.sprite = sprite;
        weaponItem = itemS;
    }
}
