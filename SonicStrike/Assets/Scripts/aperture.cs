using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class aperture : MonoBehaviour
{
    [SerializeField] private RectTransform rt;
    private void Start()
    {
        rt.DOScale(new Vector2(.7f,.7f), .8f);
        Destroy(gameObject, .84f);
    }
    private void OnDestroy()
    {
        DOTween.KillAll(gameObject);
    }
}