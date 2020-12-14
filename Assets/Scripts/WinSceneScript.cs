using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinSceneScript : MonoBehaviour
{
    public TMP_Text WinLossLabel;
    // Start is called before the first frame update
    void Start()
    {
       if(WinLoseConditions.WL.team1won) //if the player won
        {
            WinLossLabel.text = "You Won!";
        }
       else if (WinLoseConditions.WL.team2won)
        {
            WinLossLabel.text = "You Lost :(";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
