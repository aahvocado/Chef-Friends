using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController {
	public int defaultDeckSize = 5;

	private List<CardController> deckList;

	public DeckController () {
    	createDeck();
	}

	// Creates a Deck and creates the cards to populate the list
	public List<CardController> createDeck () {
		deckList = new List<CardController>();
		for (int i = 0; i < defaultDeckSize; i++) {
			string newId = i + "";
			CardController newCard = createCard(newId);
			deckList.Add(newCard);
		};
		return deckList;
	}

	// Creates a new CardController and adds it to the deck
	public CardController createCard(string newId) {
		CardController newCard = new CardController();
		newCard.setId(newId);
		return newCard;
	}

	public List<CardController> getDeck() {
		return deckList;
	}
}
