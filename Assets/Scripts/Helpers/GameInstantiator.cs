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
	public GameObject instantiateCard (Vector3 defaultPos) {
		GameObject newCard = Instantiate(Resources.Load("Prefabs/UI_Prefabs/UI_BrickButton", typeof(GameObject))) as GameObject;
		Transform cardTransform = newCard.transform;
        cardTransform.SetParent(Canvas.transform);
		return newCard;
	}

	//
	public GameObject instantiateIngredient (Vector3 defaultPos) {
		GameObject newCard = Instantiate(Resources.Load("Prefabs/IngredientComponent", typeof(GameObject))) as GameObject;
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
