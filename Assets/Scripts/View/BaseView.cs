using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	view
*/
public class BaseView : MonoBehaviour {	
	public BaseController controller;

	// called from controller
	public void setController(BaseController newController) {
		this.controller = newController;
	}

	// tell controller we are destroyed
	private void OnDestroy() {
		if (controller != null)
			controller.OnViewDestroy();
	}
}
