using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Player
	 manages their hands and their decks
*/
public class PlayerController : BaseController {
    public int defaultHandSize = 3;

    private int currentHandSize;
	public DeckController playerDeckController;
	public List<CardController> currentHandList; // list of controllers for the cards in the hand
	public List<CardView> handViewList; // list of the views of the current hand

	public PlayerController () {
		currentHandSize = defaultHandSize;
		playerDeckController = new DeckController();
		currentHandList = new List<CardController>();
		handViewList = new List<CardView>();

		instanciateHandView();
	}

	// makes a view of the current Hand
	public void instanciateHandView() {
		List<CardController> tempDeckList = playerDeckController.getCurrentDeck();

		for (int i = 0; i < currentHandSize; i++) {
			CardController card = playerDeckController.drawCard();

			// instantiate GameObject
			Vector3 newCardPos = new Vector3(7f, 4 - (i * CardConstants.cardSize));
			GameObject newCard = _GameInstantiator.instantiateCard(newCardPos);
			
			// get the view and set relevent data
			CardView cardView = newCard.transform.GetComponent<CardView>();
			cardView.setDisplayText(card.getName() + " " + card.getId());

			// let the Controller and View know of each other
			cardView.setController(card);
			card.setView(cardView);
			
			// add View and Controller to our list
			currentHandList.Add(card);
			handViewList.Add(cardView);
		}
	}

	// gets this player's DeckController
	public DeckController getDeck() {
		return playerDeckController;
	}
}
