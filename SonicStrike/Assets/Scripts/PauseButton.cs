using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    public GameObject Menu;

    public RhythmGameController rhythmGameController;

    Button button;



    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PauseOrPlayMusic);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PauseOrPlayMusic()
    {
        rhythmGameController.isPauseState = !rhythmGameController.isPauseState;
        if (rhythmGameController.isPauseState)
        {
            Menu.SetActive(true);
            rhythmGameController.PauseMusic();
        }
        else
        {
            Menu.SetActive(false);
            rhythmGameController.PlayMusic();
        }
    }
}
