using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyAnimControl : entityAnimControl
{
    #region 与玩家动画关键帧匹配
    public void setPlayerDodge(playerAnimControl pAnim)
    {
        pAnim.anim.SetBool("eDodge", true);
    }
    #endregion
}
