using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteScript : Item
{
    public TMP_Text GpsLcoationText;
    string locationTextFromGPS;
    public GameObject PlayerOnMap;
    public string locationItemIsAt;
    public CharacterClass character;
    public NoteScript thisNote;
    // Start is called before the first frame update
    void Start()
    {
        locationTextFromGPS = GpsLcoationText.text.Substring(15);
    }

    // Update is called once per frame
    void Update()
    {
        locationTextFromGPS = GpsLcoationText.text.Substring(15);

        if (thisNote.numberOfItem > 0 && locationTextFromGPS == locationItemIsAt)
        {
            character.addItemToInventory(thisNote);
            thisNote.numberOfItem -= 1;
        }

    }


}
