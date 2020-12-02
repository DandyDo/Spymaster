using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 //base calss for character classes. this will be derived form for the other classes
public class CharacterClass : MonoBehaviour
{
    //travel passes for the classes. this is the default for all
    bool hasLandTravelPass = true;
    //the inventory of the player
    List<Item> inventory = new List<Item>();
    //cards  the player has
    List<Cards> cards = new List<Cards>();

}
