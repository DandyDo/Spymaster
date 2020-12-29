using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MinutesPerDaySliderScript : MonoBehaviour
{
    public TMP_Text MinutesPerDayDsiplay;
    //int DaysAmount = 5;
    public Slider MinutesPerDaySlider;



    void Start()
    {
        MinutesPerDayDsiplay.text = MinutesPerDaySlider.value.ToString();
        GetComponent<Slider>().SetValueWithoutNotify(PlayerPrefs.GetFloat("minutesPerDay"));
    }

    //this function should be set up to be called when the value of the slider changes
    public void changeMinutesPerDay()
    {
        MinutesPerDayDsiplay.text = MinutesPerDaySlider.value.ToString();
        PlayerPrefs.SetFloat("minutesPerDay", MinutesPerDaySlider.value);

    }
}
