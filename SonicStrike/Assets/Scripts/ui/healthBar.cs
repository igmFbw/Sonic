using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
public class healthBar : MonoBehaviour
{
    [SerializeField] private Slider barSlider;
    [SerializeField] private Text healthText;
    public void initValue(int maxValue)
    {
        barSlider.maxValue = maxValue;
        barSlider.value = maxValue;
        healthText.text = "HP: " + maxValue.ToString();
    }
    public void updateValue(int value)
    {
        barSlider.value = value;
        healthText.text = "HP: " + value.ToString();
    }
}
