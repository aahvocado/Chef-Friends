using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    view interface
*/
public interface BaseView { 
    void handleUpdate(string animName); // called by Model to update View
    void handleDestroy(); // should implement to tell Model this View will be destroyed
    void handleViewDoneAnimation(); // called when animation is done

    bool isAnimatable(); // can this be animated
}
