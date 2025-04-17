using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy : MonoBehaviour
{
    [SerializeField] private entityAnimControl anim;
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
