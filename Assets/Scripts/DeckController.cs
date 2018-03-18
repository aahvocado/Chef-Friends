using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController {
	public int defaultDeckSize = 5;

	private List<CardController> deck;

	// Use this for initialization
	void Start () {
    	createDeck();
	}

	// Creates a Deck and creates the cards to populate the list
	public List<CardController> createDeck () {
		deck = new List<CardController>();
		for (var i = 0; i < defaultDeckSize; i++) {
			var newId = i + "";
			var newCard = createCard(newId);
			deck.Add(newCard);
		}
		return deck;
	}

	// Creates a new CardController and adds it to the deck
	public CardController createCard(string newId) {
		CardController newCard = new CardController();
		newCard.setId(newId);
		return newCard;
	}
}
