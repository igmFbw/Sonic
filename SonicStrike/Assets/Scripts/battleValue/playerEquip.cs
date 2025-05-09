using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerEquip : MonoBehaviour
{
    public static playerEquip _instance;
    public shield shieldEquip;
    public weapon weapnEquip;
    public int money;
    public static playerEquip instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<playerEquip>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("playerEquipControl");
                    _instance = go.AddComponent<playerEquip>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}