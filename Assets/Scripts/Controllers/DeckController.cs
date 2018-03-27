using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class that handles Deck
*/
public class DeckController {
	public List<string> defaultDeckList = new List<string> { "ingredient", "ingredient", "cook", "cook", "cook" };

	// data
	private List<CardController> completeDeck; // original complete deck
	private List<CardController> currentDeck; // currently in the deck
	private List<CardController> discardDeck; // discard pile

	private List<CardController> unknownList; // cards in neither currentDeck nor discardDeck, probably in Hand

	// constructor
	public DeckController () {
    	completeDeck = createDeck(defaultDeckList); // make a new deck and set default to it
    	handleResetDeck(); // sets up currentDeck and discardDeck
	}

	// draws the next card in the currentDeck
	public CardController drawCard() {
		if (currentDeck.Count <= 0) {
			handleShuffleDiscardToDeck();
			return drawCard();
		} else {
			// todo: implement a pop() method?
			CardController card = currentDeck[0]; // get the top card
			unknownList.Add(card);
			currentDeck.Remove(card); // remove it from current deck
			return card;
		}
	}

	// puts given card into discardDeck
	public List<CardController> discardCard(CardController card) {
		discardDeck.Add(card);

		// remove it from our unknown list
		CardController cardInUnknown = getCardInUnknownList(card);
		if (cardInUnknown != null) {
			unknownList.Remove(cardInUnknown);
		}

		return discardDeck;
	}

	// Creates a Deck and creates the cards to populate the list
	public List<CardController> createDeck(List<string> cardList) {
		List<CardController> tempDeck = new List<CardController>();
		for (int i = 0; i < cardList.Count; i++) {
			string newId = i + "";
			string newCardType = cardList[i];
			CardController newCard = createCard(newCardType, newId);
			tempDeck.Add(newCard);
		};
		return tempDeck;
	}

	// shuffles everything inside the current deck
	public List<CardController> shuffleCurrentDeck() {
		List<CardController> tempDeck = currentDeck;
		int n = tempDeck.Count;
		for (int i = 0; i < tempDeck.Count; i++) {
			int k = Random.Range(i, tempDeck.Count - 1);
			CardController tempCard = tempDeck[k];
			tempDeck[k] = tempDeck[i];
			tempDeck[i] = tempCard;
		}
	    return tempDeck;
	}

	// shuffles discardDeck into currentDeck
	public List<CardController> handleShuffleDiscardToDeck() {
		List<CardController> tempCurrentDeck = currentDeck;
		List<CardController> tempDiscardDeck = discardDeck;
		foreach(CardController card in tempDiscardDeck) {
			tempCurrentDeck.Add(card);
		};
		discardDeck = new List<CardController>(); // clear discard list
		currentDeck = tempCurrentDeck;
		return shuffleCurrentDeck();
	}

	// Creates a new CardController and adds it to the deck
	public CardController createCard(string cardType, string newId) {
		CardController newCard;
		switch (cardType) {
			case "cook":
				newCard = new CookCard();
				break;
			default:
				newCard = new CardController();
				break;

		};
		newCard.setId(newId);
		return newCard;
	}

	// sets the current deck to the original deck then shuffles it, clears the discard list
	public List<CardController> handleResetDeck () {
		unknownList = new List<CardController>(); // clear this mystery list
		discardDeck = new List<CardController>(); // clear discard list
    	currentDeck = completeDeck.GetRange(0, completeDeck.Count); // make a shallow copy of the original deck
    	return shuffleCurrentDeck();
	}

	// - helpers
	public string printList(List<CardController> list) {
		string print = "";
		foreach (CardController card in list) {
			print = print + ", " + card.getName();
		}
		Debug.Log(print);
		return print;
	}

	// 
	public CardController getCardInUnknownList(CardController card) {
		return unknownList.Find(item => item.getId() == card.getId());
	}
	public List<CardController> getCompleteDeck() {
		return completeDeck;
	}
	public List<CardController> getCurrentDeck() {
		return currentDeck;
	}
	public List<CardController> getDiscardDeck() {
		return discardDeck;
	}
}
