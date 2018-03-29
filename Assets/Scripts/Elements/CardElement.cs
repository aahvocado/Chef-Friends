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
                goto default;
            default:
                newModel = new CardModel();
                break;
        }

        return newModel;
    }

    /* creates a new Card (View and Controller) and adds it to our Hand */
    public CardElement instantiateElement() {
        CardModel newModel = this.createCardModel();

        // instantiate GameObject
        Vector3 newCardPos = Vector3.zero;
        GameObject newCardObject = Instantiator.instantiateCard(newCardPos);
        newModel.Position = CardConstants.handCenterPosition;

        // get the View from GameObject and set relevent data
        CardView newView = newCardObject.transform.GetComponent<CardView>();        
        newView.setDisplayText(newModel.name);

        // assign MVC and finish
        CardController newController = new CardController();
        this.createMVC(newModel, newView, newController);

        return this;
    }

    public CardElement createMVC(CardModel m, CardView v, CardController c) {
        Model = m;
        View = v;
        Controller = c;

        Model.Element = this;
        View.Element = this;
        Controller.Element = this;

        return this;
    }

    /* checks if all MVC elements are assigned */
    public bool isInstantiated() {
        return Model != null && View != null && Controller != null;
    }
}