using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Player
*/
public class PlayerManager {
    private DeckManager Deck;
    private HandManager Hand;

    public int defaultHandSize = 3;
    private int currentHandSize;

    public PlayerManager() {
        currentHandSize = defaultHandSize;

        // set stuff
        Deck = new DeckManager();
        Hand = new HandManager();

        // new stuff
        this.setupHandList();
    }

    /* returns a CardElement list for the current Hand */
    public List<CardElement> setupHandList() {
        List<CardElement> handList = new List<CardElement>();

        for (int i = 0; i < currentHandSize; i++) {
            CardElement card = Deck.drawCard();
            handList.Add(card);
        }

        Hand.instanciateHandView(handList);

        return handList;
    }
}
