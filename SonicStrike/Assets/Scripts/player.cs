using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum playerFps
{
    idle,attack,hurt,dodge
}
public class player : MonoBehaviour
{
    [SerializeField] private playerAnimControl anim;
    [SerializeField] public playerProperties playerStat;
    public playerFps playerAction;
    public bool isDodge;
    public shieldAnimControl shieldAnim;
    private void Start()
    {
        playerAction = playerFps.idle;
    }
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
