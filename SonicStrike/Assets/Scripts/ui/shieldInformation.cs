using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shieldInformation : equipInformationUI
{
    public shield item;
    protected override void equip()
    {
        uiSthConrtol.instance.bag.shieldList.Remove(item);
        if (playerEquip.instance.shieldEquip != null)
            uiSthConrtol.instance.bag.shieldList.Add(playerEquip.instance.shieldEquip);
        playerEquip.instance.shieldEquip = item;
        uiSthConrtol.instance.bagui.uodatePlots(1);
        uiSthConrtol.instance.shieldPlot.updateImage(item);
    }
}
