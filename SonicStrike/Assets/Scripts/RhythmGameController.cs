using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;
using UnityEngine.SceneManagement;


public class RhythmGameController : MonoBehaviour
{
    [Tooltip("Ŀ�����ɵĹ����Ӧ�¼���ID")]
    [EventID]
    public string eventID;
    //�����ٶ�
    public float noteSpeed = 1;
    //�ж���Χ
    [Range(8f, 300f)]
    public float hitWindowRangeInMS;

    public float WindowSizeInUnits
    {
        get
        {
            return noteSpeed * (hitWindowRangeInMS * 0.001f);
        }
    }

    //�����������е����д���
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
    //����
    Koreography playingKoreo;
    SimpleMusicPlayer simpleMusicPlayer;
    public Transform simpleMusciPlayerTrans;
    public List<LaneController> notelanes = new List<LaneController>();

    Stack<NoteObject> noteObjectPool = new Stack<NoteObject>();
    public Stack<GameObject> downEffectObjectPool = new Stack<GameObject>();
    public Stack<GameObject> hitEffectObjectPool = new Stack<GameObject>();
    public Stack<GameObject> hitLongEffectObjectPool = new Stack<GameObject>();

    //Ԥ������Դ
    //����
    public NoteObject noteObject;
    //������Ч
    public GameObject downEffectGo;
    //����������Ч
    public GameObject hitEffectGo;

    //���г�������Ч
    public GameObject hitLongNoteEffectGo;

    public AudioSource audioCom;


    [Tooltip("��ʼ������Ƶ֮ǰ��ʱ��")]
    public float leadInTime;

    float leadInTimeLeft;
    //���ֿ�ʼǰ����ʱ��
    float timeLeftToPlay;

    //��ǰ�Ĳ���ʱ��
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

        //��������ʱ��
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
    /// ��ʼ������ʱ��
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

    //��Ϸ�Ŀ�ʼ����ͣ
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
