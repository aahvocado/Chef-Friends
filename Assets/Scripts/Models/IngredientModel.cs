using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientModel : BaseModel {
    private IngredientElement Element;
    private bool initialized;

    private Vector3 startPosition; // where the view currently is
    private Vector3 targetPosition; // where the view will end up
    public Vector3 Position {
        get { return targetPosition; } // todo - documentation
        set {
            targetPosition = value;
            if (initialized) {
                // startPosition = Element.View.Position;
                // Element.View.handlePositionUpdate();
            } else {
                startPosition = Vector3.zero; // todo - placeholder do a proper default value set
            }
        }
    }

    // data
    private string _Text;
    public string Text {
        get { return _Text; }
        set {
            _Text = value;
            // Element.View.Text = value;
        }
    }
    
    public IngredientModel() {
		
    }

    public void initModel() {
        if (Element != null) {
            // Element.View.setDefaultPosition(startPosition);
            // Element.View.handlePositionUpdate();
            initialized = true;
        }   

        Text = "Ingredient";
    }

    /* trying to keep certain variables private */
    public void setElement(IngredientElement e) {
        Element = e;
    }
}
