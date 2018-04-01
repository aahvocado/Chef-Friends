using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MVC Element
     how to make a base for this...
*/
public class CardElement {
    private GameInstantiator Instantiator;
    public string ID;
    public string CardType;

    public CardModel Model;
    public CardView View;
    public CardController Controller;

    public CardElement() {
        Instantiator = GameInstantiator.getInstance;
    }

    /* Creates a new CardModel */
    public CardModel createCardModel() {
        CardModel newModel;

        switch (CardType) {
            case "cook":
                newModel = new CookCard();
                break;
            default:
                newModel = new CardModel();
                break;
        }

        return newModel;
    }

    /* creates a new Card (View and Controller) and adds it to our Hand */
    public CardElement instantiateElement(Vector3 startPos, Vector3 endPos) {
        CardModel newModel = this.createCardModel();

        // instantiate GameObject
        Vector3 newCardPos = startPos;
        GameObject newCardObject = Instantiator.instantiateCard(newCardPos);

        // get the View from GameObject
        CardView newView = newCardObject.transform.GetComponent<CardView>();        

        // assign MVC so everyone knows each other
        CardController newController = new CardController();
        this.createMVC(newModel, newView, newController);

        // update Model values - must be done after MVC is created
        newModel.Position = endPos;
        newModel.initModel();

        return this;
    }
    public CardElement instantiateElement() {
        return this.instantiateElement(CardConstants.handStartPosition, CardConstants.handStartPosition);
    }

    /* sets the MVC relationships */
    public CardElement createMVC(CardModel m, CardView v, CardController c) {
        Model = m;
        View = v;
        Controller = c;

        Model.setElement(this);
        View.setElement(this);
        Controller.setElement(this);
        
        return this;
    }

    /* checks if all MVC elements are assigned */
    public bool isInstantiated() {
        return Model != null && View != null && Controller != null;
    }

    public Vector3 getViewPosition() {
        return View.transform.position;
    }
}