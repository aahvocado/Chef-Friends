using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Helps instantiate GameObjects
	
	#singleton
*/
public class GameInstantiator : MonoBehaviour {
    private GameObject Canvas;

	// Use this for initialization
	void Start () {
        Canvas = GameObject.Find("Canvas");
	}

	//
	public GameObject instantiateObject(string type) {
        string resourcePath;
        if (type == ObjectConstants.INGREDIENT_OBJ_TYPE) {
            resourcePath = "Prefabs/UI_Prefabs/TEMP_Ingredient";
        } else if (type == ObjectConstants.UI_BRICK_BUTTON_OBJ_TYPE) {
            resourcePath = "Prefabs/UI_Prefabs/UI_BrickButton";
        } else {
            resourcePath = "Prefabs/UI_Prefabs/UI_BrickButton";
        }

		GameObject newCard = Instantiate(Resources.Load(resourcePath, typeof(GameObject))) as GameObject;
        if (type == ObjectConstants.UI_BRICK_BUTTON_OBJ_TYPE) {
    		Transform cardTransform = newCard.transform;
            cardTransform.SetParent(Canvas.transform);
        }
		return newCard;
	}

	// create singleton
	private static GameInstantiator _instance;
    public static GameInstantiator getInstance { get { return _instance; } }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}
