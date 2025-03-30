using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class NoteObject : MonoBehaviour
{
    public SpriteRenderer visuals;
    public Sprite[] noteSprites;
    KoreographyEvent trackedEvent;

    LaneController laneController;
    RhythmGameController gameController;
    public int hitOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isPauseState)
        {
            return;
        }

        UpdatePosition();
        GetHitOffset();
        if (transform.position.z <= laneController.targetBottomTrans.position.z)
        {
            gameController.ReturnNoteObjectToPool(this);
            ResetNote();
        }
    }
    public void Initialize(KoreographyEvent evt, int noteNum, LaneController laneCont,
        RhythmGameController gameCont, bool isLongStart, bool isLongEnd)
    {
        trackedEvent = evt;
        laneController = laneCont;
        gameController = gameCont;

        int spriteNum = noteNum;

        visuals.sprite = noteSprites[spriteNum - 1];
    }

    private void ResetNote()
    {
        trackedEvent = null;
        laneController = null;
        gameController = null;
    }

    void ReturnToPool()
    {
        gameController.ReturnNoteObjectToPool(this);
        ResetNote();
    }
    public void OnHit()
    {
        ReturnToPool();
    }
    void UpdatePosition()
    {
        Vector3 pos = laneController.TargetPosition;
        pos.z -= (gameController.DelayedSampleTime - trackedEvent.StartSample) / (float)gameController.SampleRate * gameController.noteSpeed;
        pos.y = (float)(pos.z / 36.825 * 13.5);
        transform.position = pos;
    }
    void GetHitOffset()
    {
        int curTime = gameController.DelayedSampleTime;
        int noteTime = trackedEvent.StartSample;
        int hitWindow = gameController.HitWindowSampleWidth;
        hitOffset = hitWindow - Mathf.Abs(noteTime - curTime);
    }
    public bool IsNoteMissed()
    {
        bool bMissed = true;
        if (enabled)
        {
            int curTime = gameController.DelayedSampleTime;
            int noteTime = trackedEvent.StartSample;
            int hitWindow = gameController.HitWindowSampleWidth;

            bMissed = curTime - noteTime > hitWindow;
        }
        return bMissed;
    }
    public int IsNoteHittable()
    {
        int hitLevel = 0;
        if (hitOffset >= 0)
        {
            if (hitOffset >= 0 && hitOffset <= -4000)
            {
                hitLevel = 2;
            }
            else
            {
                hitLevel = 1;
            }
        }
        else
        {
            this.enabled = false;
        }
        return hitLevel;
    }
}
