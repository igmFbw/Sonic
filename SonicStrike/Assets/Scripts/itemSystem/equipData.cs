using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum equipType
{
    weapon,shield
}
public class equipData : ScriptableObject
{
    public equipType type;
    public Sprite itemSprite;
    public string itemName;
    public int quality;
    public float basicPower;
}