using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class equipPlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected bagUI bag;
    [SerializeField] protected Image itemSprite;
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        bag.gameObject.SetActive(true);
    }
}
