using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Player
	 manages their hands and their decks
*/
public class PlayerController : BaseController {
    public GameController _GameController;

    public int defaultHandSize = 3;

    private int currentHandSize;
	public DeckController deckController;
	public List<CardController> currentHandList; // list of controllers for the cards in the hand
	public List<CardView> handViewList; // list of the views of the current hand

	public PlayerController () {
		// get singletons
		_GameController = GameController.getInstance;

		// 
		currentHandSize = defaultHandSize;
		deckController = new DeckController();
		currentHandList = new List<CardController>();
		handViewList = new List<CardView>();

		instanciateHandView();
	}

	// a card was used
	public void usePlayerCard(CardController card) {
		switch(card.getType()) {
			case "cook":
				_GameController.useCook(card.getPower());
				deckController.discardCard(card);
				deckController.drawCard();
				card.animateUseCard();
				break;
			default:
				break;
		}
	}

	// makes a view of the current Hand
	public void instanciateHandView() {
		// List<CardController> tempDeckList = deckController.getCurrentDeck();

		for (int i = 0; i < currentHandSize; i++) {
			CardController card = deckController.drawCard();

			// instantiate GameObject
			Vector3 newCardPos = new Vector3(7f, 4 - (i * CardConstants.cardSize));
			GameObject newCard = _GameInstantiator.instantiateCard(newCardPos);
			
			// get the view and set relevent data
			CardView cardView = newCard.transform.GetComponent<CardView>();
			cardView.setDisplayText(card.getName() + " " + card.getId());

			// let the Controller and View know of each other
			cardView.setController(card);
			card.setView(cardView);
			card.setOwner(this);
			
			// add View and Controller to our list
			currentHandList.Add(card);
			handViewList.Add(cardView);
		}
	}

	// gets this player's DeckController
	public DeckController getDeck() {
		return deckController;
	}
}
