using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossChoose : MonoBehaviour
{
    [SerializeField]private GameObject BossChoose;
    [SerializeField]private Button choose;
    [SerializeField]private int bossMessage;
    [SerializeField]private bool unlock;
    private void Awake()
    {
        //BossChoose.GetComponent<GameObject>();
    }
    private void Start()
    {
        choose.onClick.AddListener(() =>
        {
            //´¥·¢
        });
    }
    public void ActiveCanvas()
    {
        //BossChoose.SetActive(true);
    }
}
