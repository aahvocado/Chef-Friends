using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Player
    TODO MAYBE THIS IS NOT A CONTROLLER
     manages their hands and their decks
*/
public class PlayerController {
    public GameController _GameController;
    public GameInstantiator _GameInstantiator;

    public int defaultHandSize = 1;
    private int currentHandSize;

    public DeckController deckController;
    public List<CardElement> currentHandList; // TODO HandModel

    public PlayerController() {
        // get singletons
        _GameController = GameController.getInstance;
        _GameInstantiator = GameInstantiator.getInstance;

        // set stuff
        currentHandSize = defaultHandSize;
        currentHandList = new List<CardElement>();
        deckController = new DeckController();

        this.instanciateHandView();
    }

    /* creates a new Card (View and Controller) and adds it to our Hand, Model should already exist by now */
    public CardElement createNewCard(CardElement newElement) {
        currentHandList.Add(newElement);

        // instantiate GameObject
        Vector3 newCardPos = Vector3.zero;
        GameObject newCardObject = _GameInstantiator.instantiateCard(newCardPos);
        newElement.Model.Position = CardConstants.handCenterPosition;

        // get the View from GameObject and set relevent data
        CardView newView = newCardObject.transform.GetComponent<CardView>();        
        newView.setDisplayText(newElement.Model.name + " " + newElement.Model.Id);

        // assign MVC and finish
        CardController newController = new CardController();
        CardModel newModel = newElement.Model;
        newElement.createMVC(newModel, newView, newController);

        // animations
        newElement.View.handleUpdate(CardConstants.DRAW_CARD_ANIM);

        return newElement;
    }

    /* makes a new list of cards in the current Hand */
    public List<CardElement> instanciateHandView() {
        currentHandList = new List<CardElement>();

        for (int i = 0; i < currentHandSize; i++) {
            CardElement card = deckController.drawCard();
            this.createNewCard(card);
        }

        return currentHandList;
    }
}
