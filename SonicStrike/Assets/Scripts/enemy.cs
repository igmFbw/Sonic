using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy : MonoBehaviour
{
    [SerializeField] private enemyAnimControl anim;
    public enemyProperties prop;
    #region ¶¯»­×ª»»
    public void playAttack()
    {
        anim.turnAttack();
    }
    public void playDodge(Vector3 pos)
    {
        anim.turnDodge(pos);
    }
    public void playHurt()
    {
        anim.turnHurt();
    }
    #endregion
}