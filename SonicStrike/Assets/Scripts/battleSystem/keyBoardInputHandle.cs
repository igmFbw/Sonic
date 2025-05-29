using UnityEngine;
using UnityEngine.UI;
public class keyBoardInputHandle : MonoBehaviour
{
    #region °´Å¥
    [SerializeField] private beatButton leftMoveBu;
    [SerializeField] private beatButton leftAttackBu;
    [SerializeField] private beatButton rightMoveBu;
    [SerializeField] private beatButton rightAttackBu;
    #endregion
    [SerializeField] private player mPlayer;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.D))
        {
            leftMoveBu.click();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            leftAttackBu.click();
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            rightAttackBu.click();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            rightMoveBu.click();
        }
    }
}
