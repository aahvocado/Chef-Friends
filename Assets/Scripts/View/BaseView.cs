using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour {	
	public BaseController controller;

	public void setController(BaseController newController) {
		this.controller = newController;
	}

	private void OnDestroy() {
		if (controller != null)
			controller.removeView();
	}
}
