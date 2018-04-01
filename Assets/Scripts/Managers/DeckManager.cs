using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class that handles Deck
*/
public class DeckManager {
    // data
    private List<UIButtonElement> completeDeck; // original complete deck
    private List<UIButtonElement> currentDeck; // currently in the deck
    private List<UIButtonElement> discardDeck; // discard pile
    private List<UIButtonElement> unknownList; // cards in neither currentDeck nor discardDeck, probably in Hand

    public DeckManager () {
        completeDeck = this.createDeck(CardConstants.defaultDeckList); // make a new deck and set default to it
        this.handleResetDeck(); // sets up currentDeck and discardDeck
    }

    /* draws the next card in the currentDeck */
    public UIButtonElement drawCard() {
        if (currentDeck.Count <= 0) {
            this.handleShuffleDiscardToDeck();
            return this.drawCard();
        } else {
            // todo: implement a pop() method?
            UIButtonElement card = currentDeck[0]; // get the top card
            unknownList.Add(card);
            currentDeck.Remove(card); // remove it from current deck
            return card;
        }
    }

    /* puts given card into discardDeck */
    public List<UIButtonElement> discardCard(UIButtonElement card) {
        discardDeck.Add(card);

        // remove it from our unknown list
        UIButtonElement cardInUnknown = getCardInUnknownList(card);
        if (cardInUnknown != null) {
            unknownList.Remove(cardInUnknown);
        }

        return discardDeck;
    }

    /* creates the initial list of Card Elements for a new deck */
    public List<UIButtonElement> createDeck(List<string> cardList) {
        List<UIButtonElement> tempDeck = new List<UIButtonElement>();
        for (int i = 0; i < cardList.Count; i++) {
            string newCardType = cardList[i];
            UIButtonElement newCard = new UIButtonElement();

            // set stuff to be created
            newCard.ID = "id-" + i;
            newCard.CardType = cardList[i];

            tempDeck.Add(newCard);
        };
        return tempDeck;
    }

    /* reorders everything inside current deck */
    public List<UIButtonElement> shuffleCurrentDeck() {
        List<UIButtonElement> tempDeck = currentDeck;
        int n = tempDeck.Count;
        for (int i = 0; i < tempDeck.Count; i++) {
            int k = Random.Range(i, tempDeck.Count - 1);
            UIButtonElement tempCard = tempDeck[k];
            tempDeck[k] = tempDeck[i];
            tempDeck[i] = tempCard;
        }
        return tempDeck;
    }

    /* shuffles discardDeck into currentDeck */
    public List<UIButtonElement> handleShuffleDiscardToDeck() {
        List<UIButtonElement> tempCurrentDeck = currentDeck;
        List<UIButtonElement> tempDiscardDeck = discardDeck;
        foreach(UIButtonElement card in tempDiscardDeck) {
            tempCurrentDeck.Add(card);
        };
        discardDeck = new List<UIButtonElement>(); // clear discard list
        currentDeck = tempCurrentDeck;
        return this.shuffleCurrentDeck();
    }

    /* sets the current deck to the original deck then shuffles it, clears the discard list */
    public List<UIButtonElement> handleResetDeck () {
        unknownList = new List<UIButtonElement>(); // clear this mystery list
        discardDeck = new List<UIButtonElement>(); // clear discard list
        currentDeck = completeDeck.GetRange(0, completeDeck.Count); // make a shallow copy of the original deck
        return this.shuffleCurrentDeck();
    }

    // -- helpers
    public string printList(List<UIButtonElement> list) {
        string print = "";
        foreach (UIButtonElement Element in list) {
            print = print + ", " + Element.Model.Text;
        }
        Debug.Log(print);
        return print;
    }

    // 
    public UIButtonElement getCardInUnknownList(UIButtonElement card) {
        return unknownList.Find(item => item.ID == card.ID);
    }
}
