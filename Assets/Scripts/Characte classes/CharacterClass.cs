using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

 //base calss for character classes. this will be derived form for the other classes
public class CharacterClass : MonoBehaviour
{
    //travel passes for the classes. this is the default for all
    bool hasLandTravelPass = true;
    //the inventory of the player
    public List<Item> inventory = new List<Item>();
    public List<TMP_Text> inventoryTextDisplays = new List<TMP_Text>();
    //cards  the player has
    public List<Cards> cards = new List<Cards>();

    public void loadInventory()
    {
        for (int i = 0; i < 6; i++)
        {
            inventoryTextDisplays[i].text = inventory[i].numberOfItem.ToString() + " " + inventory[i].name;
        }
    }

    TMP_Text itemTextToAdd;
    public void addItemToInventory(Item itemToAdd)
    {
        inventory.Add(itemToAdd);
        itemTextToAdd.text = itemToAdd.name;
        inventoryTextDisplays.Add(itemTextToAdd);
    }
}
