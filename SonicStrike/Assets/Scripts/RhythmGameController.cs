using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;
using UnityEngine.SceneManagement;


public class RhythmGameController : MonoBehaviour
{
    [Tooltip("目标生成的轨道对应事件的ID")]
    [EventID]
    public string eventID;
    //音符速度
    public float noteSpeed = 1;
    //判定范围
    [Range(8f, 300f)]
    public float hitWindowRangeInMS;

    public float WindowSizeInUnits
    {
        get
        {
            return noteSpeed * (hitWindowRangeInMS * 0.001f);
        }
    }

    //在音乐样本中的命中窗口
    int hitWindowRangeInSamples;
    public int HitWindowSampleWidth
    {
        get
        {
            return hitWindowRangeInSamples;
        }
    }




    public int SampleRate
    {
        get
        {
            return playingKoreo.SampleRate;
        }
    }
    //引用
    Koreography playingKoreo;
    SimpleMusicPlayer simpleMusicPlayer;
    public Transform simpleMusciPlayerTrans;
    public List<LaneController> notelanes = new List<LaneController>();

    Stack<NoteObject> noteObjectPool = new Stack<NoteObject>();
    public Stack<GameObject> downEffectObjectPool = new Stack<GameObject>();
    public Stack<GameObject> hitEffectObjectPool = new Stack<GameObject>();
    public Stack<GameObject> hitLongEffectObjectPool = new Stack<GameObject>();

    //预制体资源
    //音符
    public NoteObject noteObject;
    //按下特效
    public GameObject downEffectGo;
    //击中音符特效
    public GameObject hitEffectGo;

    //击中长音符特效
    public GameObject hitLongNoteEffectGo;

    public AudioSource audioCom;


    [Tooltip("开始播放音频之前的时间")]
    public float leadInTime;

    float leadInTimeLeft;
    //音乐开始前倒计时器
    float timeLeftToPlay;

    //当前的采样时间
    public int DelayedSampleTime
    {
        get
        {
            return playingKoreo.GetLatestSampleTime() - SampleRate * (int)leadInTimeLeft;
        }
    }

    public bool isPauseState;
    public bool gameStart;
    public Koreography kgy;

    // Start is called before the first frame update

    void Start()
    {
        InitializeLeadIn();
        simpleMusicPlayer = simpleMusciPlayerTrans.GetComponent<SimpleMusicPlayer>();
        simpleMusicPlayer.LoadSong(kgy, 0, false);
        for (int i = 0; i < notelanes.Count; i++)
        {
            notelanes[i].Initialize(this);
        }
        playingKoreo = Koreographer.Instance.GetKoreographyAtIndex(0);
        KoreographyTrackBase rhythmTrack = playingKoreo.GetTrackByID(eventID);
        List<KoreographyEvent> rawEvents = rhythmTrack.GetAllEvents();
        for (int i = 0; i < rawEvents.Count; i++)
        {
            KoreographyEvent evt = rawEvents[i];
            int noteID = evt.GetIntValue();
            for (int j = 0; j < notelanes.Count; j++)
            {
                LaneController lane = notelanes[j];
                if (noteID > 4)
                {
                    noteID = noteID - 4;
                    if (noteID > 4)
                    {
                        noteID = noteID - 4;
                    }
                }
                if (lane.DoesMatch(noteID))
                {
                    lane.AddEventToLane(evt);
                    break;
                }
            }
        }
        hitWindowRangeInSamples = (int)(SampleRate * hitWindowRangeInMS * 0.001f);
    }

    void Update()
    {

        if (isPauseState)
        {
            return;
        }

        if (timeLeftToPlay > 0)
        {
            timeLeftToPlay -= Time.unscaledDeltaTime;
            if (timeLeftToPlay <= 0)
            {
                audioCom.Play();
                gameStart = true;
                timeLeftToPlay = 0;
            }
        }

        //倒数引导时间
        if (leadInTimeLeft > 0)
        {
            leadInTimeLeft = Mathf.Max(leadInTimeLeft - Time.unscaledDeltaTime, 0);
        }
        if (gameStart)
        {
            if (!simpleMusicPlayer.IsPlaying)
            {
                SceneManager.LoadScene(5);
            }
        }

    }


    /// <summary>
    /// 初始化引导时间
    /// </summary>
    void InitializeLeadIn()
    {
        if (leadInTime > 0)
        {
            leadInTimeLeft = leadInTime;
            timeLeftToPlay = leadInTime;
        }
        else
        {
            audioCom.Play();
        }
    }


    public NoteObject GetFreshNoteObject()
    {
        NoteObject retObj;
        if (noteObjectPool.Count > 0)
        {
            retObj = noteObjectPool.Pop();
        }
        else
        {
            retObj = Instantiate<NoteObject>(noteObject);
        }
        retObj.transform.position = Vector3.one * 2;
        retObj.gameObject.SetActive(true);
        retObj.enabled = true;
        return retObj;
    }
    public void ReturnNoteObjectToPool(NoteObject obj)
    {
        if (obj != null)
        {
            obj.enabled = false;
            obj.gameObject.SetActive(false);
            noteObjectPool.Push(obj);
        }
    }

    public GameObject GetFreshEffectObject(Stack<GameObject> stack, GameObject effectObject)
    {
        GameObject effectGo;
        if (stack.Count > 0)
        {
            effectGo = stack.Pop();
        }
        else
        {
            effectGo = Instantiate(downEffectGo);
        }
        effectGo.SetActive(true);
        return effectGo;
    }
    public void ReturnEffectGoToPool(GameObject effectGo, Stack<GameObject> stack)
    {
        if (effectGo != null)
        {
            effectGo.gameObject.SetActive(false);
            stack.Push(effectGo);
        }
    }

    //游戏的开始与暂停
    public void PauseMusic()
    {

        if (!gameStart)
        {
            return;
        }
        simpleMusicPlayer.Pause();
    }

    public void PlayMusic()
    {
        if (!gameStart)
        {
            return;
        }
        simpleMusicPlayer.Play();
    }
}
