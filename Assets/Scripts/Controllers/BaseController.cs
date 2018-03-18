using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	controller
*/
public class BaseController {
    public GameInstantiator _GameInstantiator;
    
    public BaseView view;

    public BaseController() {
    	// get singletons
		_GameInstantiator = GameInstantiator.getInstance;
    }

    // called from view
    public virtual void OnViewMouseUp() { }

    // manages view
	public void setView(BaseView newView) {
		view = newView;
	}
	public void OnViewDestroy() {
		removeView();
	}
	public void removeView() {
		view = null;
	}
}
