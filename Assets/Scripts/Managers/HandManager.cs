using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Manages the Hand
*/
public class HandManager {
    // data
    private List<CardElement> HandList;

    public HandManager () {
        HandList = new List<CardElement>();
    }

    /* creates a new Card (View and Controller) and adds it to our Hand, Model should already exist by now */
    public CardElement createNewCard(CardElement Card) {
        Card.instantiateElement();

        // animations
        Card.View.handleUpdate(CardConstants.DRAW_CARD_ANIM);

        return Card;
    }

    /* instantiates al the new list of cards in the current Hand */
    public List<CardElement> instanciateHandView(List<CardElement> newHandList) {
        HandList = new List<CardElement>();
        
        for (int i = 0; i < newHandList.Count; i++) {
            CardElement instantiatedCard = this.createNewCard(newHandList[i]);
            HandList.Add(instantiatedCard);
        }

        return HandList;
    }
}
