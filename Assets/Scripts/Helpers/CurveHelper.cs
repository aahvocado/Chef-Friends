using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	https://answers.unity.com/questions/12689/moving-an-object-along-a-bezier-curve.html
*/
public class CurveHelper {
	// bezier with 1 control point
	public static Vector3 getQuadraticBezier(Vector3 start, Vector3 control, Vector3 end, float percent) {
		float t = percent;
		if (t >= 1) {
			t = 1;
		}
		return (((1-t)*(1-t)) * start) + (2 * t * (1 - t) * control) + ((t * t) * end);
	}
}
