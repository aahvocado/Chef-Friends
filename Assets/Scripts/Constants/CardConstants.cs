using System.Collections.Generic;
using UnityEngine;

public class CardConstants {
	//
    public static List<string> defaultDeckList = new List<string> { "ingredient", "ingredient", "cook", "cook", "cook" };

	// arbitrary sizing
	public static float cardSize = 60f;

	// hand size positining info
	public static Vector3 handStartPosition = new Vector3(220f, 140f, 0f);

	// animation
	public static string DRAW_CARD_ANIM = "draw-card-animation";
	public static int DRAW_CARD_ANIM_TIME = 15;
	
	public static string USE_CARD_ANIM = "use-card-animation";
	public static int USE_CARD_ANIM_TIME = 22;

	public static string MOVE_CARD_ANIM = AnimationConstants.BASIC_ANIM;
	public static int MOVE_CARD_ANIM_TIME = 5;

}