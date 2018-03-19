using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	view
*/
public class BaseView : MonoBehaviour {	
	public BaseController controller;

	public virtual bool isInteractable() { return true; }
	public virtual bool canAnimate() { return true; }

	// - called from controller
	public void setController(BaseController newController) {
		this.controller = newController;
	}
	// - setters
	public void handleViewDestroy() {
		controller.OnViewWillDestroy(this);
		Destroy(gameObject);
	}
}
