using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using UnityEngine.UIElements;

public class LaneController : MonoBehaviour
{
    public KeyCode keyboardButton;
    //键盘按下视觉效果
    public Transform targetVisuals;
    //音符上下边界
    public Transform targetTopTrans;
    public Transform targetBottomTrans;
    RhythmGameController gameController;
    List<KoreographyEvent> laneEvents = new List<KoreographyEvent>();
    Queue<NoteObject> trackedNotes = new Queue<NoteObject>();
    public int laneID;
    public GameObject downVisual;
    public AudioSource audioSource;
    // 播放音效
    public void playSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }



    int pendingEventIdx = 0;

    public Vector3 TargetPosition
    {
        get
        {
            return transform.position;
        }
    }
    public bool hasLongNote;

    public float timeVal = 0;

    public GameObject longNoteHitEffectGo;

    //击中音效
    public AudioClip hitSound;

    // Update is called once per frame
    void Update()
    {
        if (gameController.isPauseState)
        {
            return;
        }
        //清除无效音符
        while (trackedNotes.Count > 0 && trackedNotes.Peek().IsNoteMissed())
        {
            trackedNotes.Dequeue();
        }
        CheckSpawnNext();
        //检测玩家输入
        if (Input.GetKeyDown(keyboardButton))
        {
            CheckNoteHit();
            downVisual.SetActive(true);
        }
        else if (Input.GetKey(keyboardButton))
        {


        }
        else if (Input.GetKeyUp(keyboardButton))
        {
            downVisual.SetActive(false);
        }
    }
    public void Initialize(RhythmGameController controller)
    {
        gameController = controller;
    }

    public bool DoesMatch(int noteID)
    {
        return noteID == laneID;
    }
    public void AddEventToLane(KoreographyEvent evt)
    {
        laneEvents.Add(evt);
    }
    //音符产生位置
    int GetSpawnSampleOffset()
    {
        //出生位置与目标点的位置
        float a = (targetTopTrans.position.z - transform.position.z) * (targetTopTrans.position.z - transform.position.z) + (targetTopTrans.position.y - transform.position.y) * (targetTopTrans.position.y - transform.position.y);
        float spawnDistToTarget = Mathf.Sqrt(a);
        //时间 
        float spawnPosToTargetTime = spawnDistToTarget / gameController.noteSpeed;
        //返回偏移量
        return (int)spawnPosToTargetTime * gameController.SampleRate;
    }
    //检测是否生成新音符
    void CheckSpawnNext()
    {
        int samplesToTarget = GetSpawnSampleOffset();
        int currentTime = gameController.DelayedSampleTime;
        while (pendingEventIdx < laneEvents.Count && laneEvents[pendingEventIdx].StartSample < currentTime + samplesToTarget)
        {
            KoreographyEvent evt = laneEvents[pendingEventIdx];
            int noteNum = evt.GetIntValue();
            NoteObject newObj = gameController.GetFreshNoteObject();
            bool isLongNoteStart = false;
            bool isLongNoteEnd = false;
            if (noteNum > 4)
            {
                isLongNoteStart = true;
                noteNum = noteNum - 4;
                if (noteNum > 4)
                {
                    isLongNoteEnd = true;
                    isLongNoteStart = false;
                    noteNum = noteNum - 4;
                }
            }

            newObj.Initialize(evt, noteNum, this, gameController, isLongNoteStart, isLongNoteEnd);

            trackedNotes.Enqueue(newObj);
            pendingEventIdx++;
        }
    }
    void CreatDownEffect()
    {
        GameObject downEffectGo = gameController.GetFreshEffectObject(gameController.downEffectObjectPool, gameController.downEffectGo);
        downEffectGo.transform.position = targetVisuals.position;
    }
    void CreatHitEffect()
    {
        GameObject hitEffectGo = gameController.GetFreshEffectObject(gameController.hitEffectObjectPool, gameController.hitEffectGo);
        hitEffectGo.transform.position = targetVisuals.position;
    }
    void CreatHitLongEffect()
    {
        GameObject hitLongNoteEffectGo = gameController.GetFreshEffectObject(gameController.hitLongEffectObjectPool, gameController.hitLongNoteEffectGo);
        hitLongNoteEffectGo.transform.position = targetVisuals.position;
    }
    public void CheckNoteHit()
    {
        if (!gameController.gameStart)
        {
            CreatDownEffect();
            return;
        }
        if (trackedNotes.Count > 0)
        {
            NoteObject noteObject = trackedNotes.Peek();
            if (noteObject.hitOffset > -4000)
            {
                trackedNotes.Dequeue();
                int hitLevel = noteObject.IsNoteHittable();
                if (hitLevel > 0)
                {

                    {
                        playSound(hitSound);
                        CreatHitEffect();
                    }
                }
                else
                {

                }
                noteObject.OnHit();
            }
            else
            {

                CreatDownEffect();
            }
        }
        else
        {
            CreatDownEffect();
        }
    }
}
