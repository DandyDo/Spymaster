using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardsManager : MonoBehaviour
{
    public List<Cards> cardList = new List<Cards>();
    public List<GameObject> cardObjects = new List<GameObject>();
    Cards cardToBeUsed;
    public TMP_Text confirmationText;
    public void setCardToBeUsed(Cards cardToBeUsedInput)
    {
        cardToBeUsed = cardToBeUsedInput;
        confirmationText.text = "Use " + cardToBeUsed.cardName + "?";
    }
    public void useCard()
    {
        int i = 0;
        foreach (Cards card in cardList)
        {
            if (cardToBeUsed.name == card.name)
            {
                //use card
                Debug.Log("Used " + cardToBeUsed.cardName);
                card.used = true;
                cardObjects[i].SetActive(false);//disable the card after it has been used
            }
            i++;
        }
    }
}
