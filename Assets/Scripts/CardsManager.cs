using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardsManager : MonoBehaviour
{
    public List<Cards> cardList = new List<Cards>();
    Cards cardToBeUsed;
    public TMP_Text confirmationText;
    public void setCardToBeUsed(Cards cardToBeUsedInput)
    {
        cardToBeUsed = cardToBeUsedInput;
        confirmationText.text = "Use " + cardToBeUsed.cardName + "?";
    }
    public void useCard()
    {
        foreach (Cards card in cardList)
        {
            if (cardToBeUsed.name == card.name)
            {
                //use card
                Debug.Log("Used " + cardToBeUsed.cardName);
                card.used = true;
            }
        }
    }
}
