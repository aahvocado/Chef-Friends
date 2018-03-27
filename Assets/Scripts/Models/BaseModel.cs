using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	model
*/
public class BaseModel {

	public BaseController controller;
	public BaseView view;

	public BaseModel {
		
	}

	public void updateView() {
		view.update();
	}
}
