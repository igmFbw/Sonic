using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class aperture : MonoBehaviour
{
    [SerializeField] private RectTransform rt;
    private Tween te;
    private void Start()
    {
        te = rt.DOScale(new Vector2(.7f,.7f), .8f);
        Destroy(gameObject, .84f);
    }
    private void OnDestroy()
    {
        te.Kill();
    }
}