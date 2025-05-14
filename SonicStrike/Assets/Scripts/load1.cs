using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load1 : MonoBehaviour
{
    [Header("Progress Bar Settings")]
    public Slider progressBar; // ����UI�е�Slider���
    public float minSpeed = 0.1f; // ��С�����ٶ�
    public float maxSpeed = 0.5f; // ��������ٶ�
    public float changeInterval = 2f; // �ٶȱ仯���ʱ��

    private float currentSpeed;
    private float timer;
    private float changeSpeedTimer;

    public Image load;
    public Text math;

    public GameObject background1;
    public GameObject background2;
    public GameObject background3;

    public GameObject Tips1;
    public GameObject Tips2;
    public GameObject Tips3;

    private AsyncOperation asyncLoad;

    void Start()
    {
        background1.SetActive(false); 
        background2.SetActive(false);
        background3.SetActive(false);

        Tips1.SetActive(false);
        Tips2.SetActive(false);
        Tips3.SetActive(false);

        float ran = Random.Range(1,3);
        
        if(ran == 1)
        {
            Tips1.SetActive(true);
        }
        else if(ran == 2)
        {
            Tips2.SetActive(true);
        }
        else if(ran == 3)
        {
            Tips3.SetActive(true);
        }

        if (mainScene.choose == 1)
        {
            background1.SetActive(true);
        }
        else if(mainScene.choose == 3)
        {
            background2.SetActive(true);
        }
        else if(mainScene.choose == 2) 
        {
            background3.SetActive(true);
        }
        else
        {
            Debug.Log("Error");
        }
        mainScene.choose = 0;

        progressBar.value = 0f;
        // ���ó�ʼ����ٶ�
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        timer = 0f;
        changeSpeedTimer = 0f;

        // ��ʼ�첽����
            asyncLoad = SceneManager.LoadSceneAsync(mainScene.sceneControl);
            asyncLoad.allowSceneActivation = false; // ��ֹ�Զ��л�����
    }

    void Update()
    {
        load.fillAmount = progressBar.value;
        math.text = ( progressBar.value * 100).ToString("0.00");

        timer += Time.deltaTime;
        changeSpeedTimer += Time.deltaTime;


        if (changeSpeedTimer >= changeInterval)
        {
            currentSpeed = Random.Range(minSpeed, maxSpeed);
            changeSpeedTimer = 0f;
        }

        if (progressBar.value + currentSpeed * Time.deltaTime <= 100)
        {
            progressBar.value += currentSpeed * Time.deltaTime;
        }
        else
        {
            progressBar.value = 100f;
        }


        if (progressBar.value >= progressBar.maxValue)
        {
            
            StartCoroutine(Wait());
            asyncLoad.allowSceneActivation = true;        

            progressBar.value = progressBar.minValue;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    // ��ѡ����ӷ������ֶ���ȡ/���õ�ǰ�ٶ�
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void SetSpeedRange(float newMin, float newMax)
    {
        minSpeed = newMin;
        maxSpeed = newMax;
        // ȷ����ǰ�ٶ����·�Χ��
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }
}