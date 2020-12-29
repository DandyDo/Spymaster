using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsToWinScript : MonoBehaviour
{
    public TMP_Text PointsToWinDisplay;
    //int DaysAmount = 5;
    public Slider PointsToWinSlider;

    

    void Start()
    {
        PointsToWinDisplay.text = PointsToWinSlider.value.ToString();
        GetComponent<Slider>().SetValueWithoutNotify(PlayerPrefs.GetFloat("pointsToWin"));
    }

    //this function should be set up to be called when the value of the slider changes
    public void changedPointsToWin()
    {
        PointsToWinDisplay.text = PointsToWinSlider.value.ToString();
        PlayerPrefs.SetFloat("pointsToWin", PointsToWinSlider.value);
        
    }
}
