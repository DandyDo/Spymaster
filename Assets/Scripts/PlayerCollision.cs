using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool missionFinished = false;

    public WinLoseConditions winloss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Player entered location.");
        if (collision.tag.Equals("Minsk"))
        {
            missionFinished = true;
            //winloss.increaseTeam1Score(250);
        }
    }
}
