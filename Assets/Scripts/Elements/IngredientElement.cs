using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

*/
public class IngredientElement : BaseElement {
    public new IngredientModel Model;
    public new IngredientView View;
    public new IngredientController Controller;

    public override void instantiateElement(Vector3 startPos, Vector3 endPos) {
        IngredientModel newModel = new IngredientModel();

        // instantiate GameObject
        GameObject newObject = Singletons.Instantiator.instantiateObject(Type);

        // get the View from GameObject
        IngredientView newView = newObject.transform.GetComponent<IngredientView>();        

        // assign MVC so everyone knows each other
        IngredientController newController = new IngredientController();
        this.createMVC(newModel, newView, newController);

        // update Model values - must be done after MVC is created
        newModel.Position = endPos;
        newModel.initModel();
    }

    /* sets the MVC relationships */
    public void createMVC(IngredientModel m, IngredientView v, IngredientController c) {
        Model = m;
        View = v;
        Controller = c;

        Model.setElement(this);
        View.setElement(this);
        Controller.setElement(this);
    }
}