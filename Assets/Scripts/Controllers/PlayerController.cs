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

	// - called from CardController
	// a card was used
	public void usePlayerCard(CardController card) {
		switch(card.getType()) {
			case "cook":
				_GameController.useCook(card.getPower());
				break;
			default:
				break;
		}
		// todo check if valid use?
		card.animateUseCard();
	}
	// a CardView was destroyed (probably from use)
	public void handleCardConsumed(CardController card, CardView destroyedView) {
		handViewList.Remove(destroyedView);
		currentHandList.Remove(card);
		deckController.discardCard(card);
		CardController newCard = deckController.drawCard();
		instanciateNewCard(newCard);
	}

	public void instanciateNewCard(CardController card) {
		// instantiate GameObject
		Vector3 newCardPos = new Vector3(7f, 4 - (handViewList.Count * CardConstants.cardSize));
		GameObject newCard = _GameInstantiator.instantiateCard(newCardPos);

		// get the view and set relevent data
		CardView cardView = newCard.transform.GetComponent<CardView>();
		cardView.setDisplayText(card.getName() + " " + card.getId());

		// let the Controller and View know of each other
		card.setView(cardView);
		card.setOwner(this);
		cardView.setController(card);

		// add View and Controller to our list
		currentHandList.Add(card);
		handViewList.Add(cardView);
	}

	// makes a view of the current Hand
	public List<CardView> instanciateHandView() {
		currentHandList = new List<CardController>();
		handViewList = new List<CardView>();

		for (int i = 0; i < currentHandSize; i++) {
			CardController card = deckController.drawCard();
			instanciateNewCard(card);
		}

		return handViewList;
	}

	// gets this player's DeckController
	public DeckController getDeck() {
		return deckController;
	}
}
