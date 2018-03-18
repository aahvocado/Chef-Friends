using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController {
    public virtual BaseView view { get; set; }

    public virtual void OnMouseUpView () { }

	public void setView(BaseView newView) {
		view = newView;
	}
	public void removeView() {
		view = null;
	}
}
