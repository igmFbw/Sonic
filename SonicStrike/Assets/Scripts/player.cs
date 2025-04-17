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
    public playerFps playerAction;
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
    }
    public void playHurt()
    {
        anim.turnHurt();
    }
#endregion
}
