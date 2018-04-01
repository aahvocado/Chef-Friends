using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientModel : UIButtonModel {
    public IngredientModel() {
		
    }

    public override void initModel() {
        base.initModel();
        
        Text = "Ingredient";
    }
}
