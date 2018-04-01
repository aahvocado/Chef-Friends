using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Manages the Hand
*/
public class HandManager {
    // data
    private List<UIButtonElement> HandList;

    public HandManager () {
        HandList = new List<UIButtonElement>();
    }

    /* creates a new Card (View and Controller) and adds it to our Hand, Model should already exist by now */
    public UIButtonElement createNewCard(UIButtonElement Card, int index, int total) {
        Card.instantiateElement(CardConstants.handStartPosition, this.getNextPosition(index, total));

        // // animations
        // Card.View.handleUpdate(CardConstants.DRAW_CARD_ANIM);

        return Card;
    }
    public UIButtonElement createNewCard(UIButtonElement Card, int index) {
        return this.createNewCard(Card, index, 3); // TODO fix
    }
    
    /* instantiates al the new list of cards in the current Hand */
    public List<UIButtonElement> instanciateHandView(List<UIButtonElement> newHandList) {
        HandList = new List<UIButtonElement>();

        for (int i = 0; i < newHandList.Count; i++) {
            UIButtonElement instantiatedCard = this.createNewCard(newHandList[i], i);
            HandList.Add(instantiatedCard);
        }

        return HandList;
    }

    /* find next Hand position */
    public Vector3 getNextPosition(int position, int total) {
        Vector3 defaultPosition = CardConstants.handStartPosition;

        defaultPosition.y = defaultPosition.y - (CardConstants.cardSize * position);

        // Debug.Log("pos: " + defaultPosition);
        return defaultPosition;
    }
    public Vector3 getNextPosition(int position) {
        return this.getNextPosition(position, HandList.Count);
    }
}
