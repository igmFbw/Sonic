using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class aperture : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    private Tween te;
    private beatButton buParent;
    private buttonType apertureType;
    public bool canClick;
    private void Start()
    {
        StartCoroutine(setFps());
        canClick = false;
        te = transform.DOScale(new Vector2(.54f,.54f), .8f);
        Destroy(gameObject, .84f);
    }
    public void setBu(beatButton bu,buttonType type)
    {
        buParent = bu;
        apertureType = type;
    }
    private void OnDestroy()
    {
        te.Kill();
        buParent.removeAperture();
        levelGlobalControl.instance.addApertureIndex(apertureType);
    }
    private IEnumerator setFps()
    {
        yield return new WaitForSeconds(.5f);
        sr.color = new Color(1, .55f, .55f);
        canClick = true;
    }
}