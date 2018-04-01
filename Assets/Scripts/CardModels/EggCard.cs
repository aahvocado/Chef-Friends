using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCard : UIButtonModel {
    public EggCard() {
		
    }

    public override void initModel() {
        base.initModel();
        
        Text = "Egg";
        // power = 1;
        // type = "cook";
    }
}
