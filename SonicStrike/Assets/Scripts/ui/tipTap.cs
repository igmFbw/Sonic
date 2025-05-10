using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class tipTap : MonoBehaviour
{
    [SerializeField] private Text tipText;
    public RectTransform rt;
    [SerializeField] private CanvasGroup cg;
    public void setText(string str)
    {
        Invoke("end",3.2f);
        tipText.text = str; Sequence se = DOTween.Sequence();
        se.Append(rt.DOAnchorPos(new Vector2(0, -600), 1).SetRelative());
        se.Append(cg.DOFade(0, 2));
    }
    private void OnDestroy()
    {
        DOTween.Kill(rt);
        DOTween.Kill(cg);
    }
    private void end()
    {
        Destroy(gameObject);
    }
}
