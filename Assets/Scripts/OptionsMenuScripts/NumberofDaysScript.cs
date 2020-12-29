using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberofDaysScript : MonoBehaviour
{
    public TMP_Text NumberOfDaysDisplay;
    //int DaysAmount = 5;
    public Slider NumberOfDaysSlider;



    void Start()
    {
        NumberOfDaysDisplay.text = NumberOfDaysSlider.value.ToString();
        GetComponent<Slider>().SetValueWithoutNotify(PlayerPrefs.GetFloat("numberOfDays"));
    }

    //this function should be set up to be called when the value of the slider changes
    public void changeNumberOfDays()
    {
        NumberOfDaysDisplay.text = NumberOfDaysSlider.value.ToString();
        PlayerPrefs.SetFloat("numberOfDays", NumberOfDaysSlider.value);

    }
}
