using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyAnimControl : entityAnimControl
{
    #region ����Ҷ����ؼ�֡ƥ��
    public void setPlayerDodge(playerAnimControl pAnim)
    {
        pAnim.anim.SetBool("eDodge", true);
    }
    #endregion
}
