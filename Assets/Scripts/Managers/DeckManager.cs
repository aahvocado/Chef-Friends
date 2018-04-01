using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class that handles Deck
*/
public class DeckManager {
    // data
    private List<CardElement> completeDeck; // original complete deck
    private List<CardElement> currentDeck; // currently in the deck
    private List<CardElement> discardDeck; // discard pile
    private List<CardElement> unknownList; // cards in neither currentDeck nor discardDeck, probably in Hand

    public DeckManager () {
        completeDeck = this.createDeck(CardConstants.defaultDeckList); // make a new deck and set default to it
        this.handleResetDeck(); // sets up currentDeck and discardDeck
    }

    /* draws the next card in the currentDeck */
    public CardElement drawCard() {
        if (currentDeck.Count <= 0) {
            this.handleShuffleDiscardToDeck();
            return this.drawCard();
        } else {
            // todo: implement a pop() method?
            CardElement card = currentDeck[0]; // get the top card
            unknownList.Add(card);
            currentDeck.Remove(card); // remove it from current deck
            return card;
        }
    }

    /* puts given card into discardDeck */
    public List<CardElement> discardCard(CardElement card) {
        discardDeck.Add(card);

        // remove it from our unknown list
        CardElement cardInUnknown = getCardInUnknownList(card);
        if (cardInUnknown != null) {
            unknownList.Remove(cardInUnknown);
        }

        return discardDeck;
    }

    /* creates the initial list of Card Elements for a new deck */
    public List<CardElement> createDeck(List<string> cardList) {
        List<CardElement> tempDeck = new List<CardElement>();
        for (int i = 0; i < cardList.Count; i++) {
            string newCardType = cardList[i];
            CardElement newCard = new CardElement();

            // set stuff to be created
            newCard.ID = "id-" + i;
            newCard.CardType = cardList[i];

            tempDeck.Add(newCard);
        };
        return tempDeck;
    }

    /* reorders everything inside current deck */
    public List<CardElement> shuffleCurrentDeck() {
        List<CardElement> tempDeck = currentDeck;
        int n = tempDeck.Count;
        for (int i = 0; i < tempDeck.Count; i++) {
            int k = Random.Range(i, tempDeck.Count - 1);
            CardElement tempCard = tempDeck[k];
            tempDeck[k] = tempDeck[i];
            tempDeck[i] = tempCard;
        }
        return tempDeck;
    }

    /* shuffles discardDeck into currentDeck */
    public List<CardElement> handleShuffleDiscardToDeck() {
        List<CardElement> tempCurrentDeck = currentDeck;
        List<CardElement> tempDiscardDeck = discardDeck;
        foreach(CardElement card in tempDiscardDeck) {
            tempCurrentDeck.Add(card);
        };
        discardDeck = new List<CardElement>(); // clear discard list
        currentDeck = tempCurrentDeck;
        return this.shuffleCurrentDeck();
    }

    /* sets the current deck to the original deck then shuffles it, clears the discard list */
    public List<CardElement> handleResetDeck () {
        unknownList = new List<CardElement>(); // clear this mystery list
        discardDeck = new List<CardElement>(); // clear discard list
        currentDeck = completeDeck.GetRange(0, completeDeck.Count); // make a shallow copy of the original deck
        return this.shuffleCurrentDeck();
    }

    // -- helpers
    public string printList(List<CardElement> list) {
        string print = "";
        foreach (CardElement Element in list) {
            print = print + ", " + Element.Model.Text;
        }
        Debug.Log(print);
        return print;
    }

    // 
    public CardElement getCardInUnknownList(CardElement card) {
        return unknownList.Find(item => item.ID == card.ID);
    }
}
