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

    // view was removed
	public virtual void OnRemoveView(BaseView destroyedView) {}

    // - called from view
    public virtual void OnViewMouseUp() {}

    // manages view
	public void setView(BaseView newView) {
		view = newView;
	}
	public void OnViewWillDestroy(BaseView destroyedView) {
		OnRemoveView(destroyedView);
		view = null;
	}
}
