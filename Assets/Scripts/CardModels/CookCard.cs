using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCard : CardModel {
    public CookCard() {
		
    }

    public override void initModel() {
        base.initModel();
        
        Text = "Cook";
        // power = 1;
        // type = "cook";
    }
}
