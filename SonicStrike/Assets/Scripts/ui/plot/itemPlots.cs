using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class itemPlots : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected Image itemSprite;
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
