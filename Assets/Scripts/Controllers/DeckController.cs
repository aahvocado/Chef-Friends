using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController {
	public List<string> defaultDeckList = new List<string> {"apple", "cook", "cook", "cook", "cook"};

	private List<CardController> deckList;

	public DeckController () {
    	createDefaultDeck();
    	printList();
    	shuffleDeck();
    	printList();
	}

	public List<CardController> createDefaultDeck () {
		return createDeck(defaultDeckList);
	}

	// Creates a Deck and creates the cards to populate the list
	public List<CardController> createDeck (List<string> cardList) {
		deckList = new List<CardController>();
		for (int i = 0; i < cardList.Count; i++) {
			string newId = i + "";
			string newCardType = cardList[i];
			CardController newCard = createCard(newCardType, newId);
			deckList.Add(newCard);
		};
		return deckList;
	}

	// shuffles current deck
	public List<CardController> shuffleDeck () {
		int n = deckList.Count;
		for (int i = 0; i < deckList.Count; i++) {
			int k = Random.Range(i, deckList.Count - 1);
			CardController temp = deckList[k];
			deckList[k] = deckList[i];
			deckList[i] = temp;
		}
	    return deckList;
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


	// getters
	public string printList() {
		string print = "";
		foreach (CardController card in deckList) {
			print = print + ", " + card.getName();
		}
		Debug.Log(print);
		return print;
	}
	public List<CardController> getDeck() {
		return deckList;
	}
}
