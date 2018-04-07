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

    public UIButtonElement createNewElement(UIButtonElement Element, int index, int total) {
        Element.instantiateElement(CardConstants.handStartPosition, this.getNextPosition(index, total));
        return Element;
    }
    public UIButtonElement createNewElement(UIButtonElement Element, int index) {
        return this.createNewElement(Element, index, 3); // TODO fix
    }
    
    /* instantiates al the new list of cards in the current Hand */
    public List<UIButtonElement> instanciateHandView(List<UIButtonElement> newHandList) {
        HandList = new List<UIButtonElement>();

        for (int i = 0; i < newHandList.Count; i++) {
            UIButtonElement instantiatedElement = this.createNewElement(newHandList[i], i);
            HandList.Add(instantiatedElement);
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
