using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player : MonoBehaviour
{
    [SerializeField] private playerAnimControl anim;
    [SerializeField] public playerProperties playerStat;
    public bool isDodge;
    public shieldAnimControl shieldAnim;
    #region ¶¯»­×ª»»
    public void playAttack()
    {
        anim.turnAttack();
    }
    public void playDodge()
    {
        anim.turnDodge();
        isDodge = true;
    }
    public void playHurt()
    {
        anim.turnHurt();
    }
#endregion
}
