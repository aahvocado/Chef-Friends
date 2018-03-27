using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Helps instantiate GameObjects
	
	#singleton
*/
public class GameInstantiator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	//
	public GameObject instantiateDish (Vector3 defaultPos) {
		GameObject newDish = Instantiate(Resources.Load("Prefabs/DishComponent", typeof(GameObject))) as GameObject;
		Transform cardTransform = newDish.transform;
		cardTransform.position = defaultPos;
		return newDish;
	}

	//
	public GameObject instantiateCard (Vector3 defaultPos) {
		GameObject newCard = Instantiate(Resources.Load("Prefabs/CardComponent", typeof(GameObject))) as GameObject;
		Transform cardTransform = newCard.transform;
		cardTransform.position = defaultPos;
		return newCard;
	}

	//
	public GameObject instantiateIngredient (Vector3 defaultPos) {
		GameObject newCard = Instantiate(Resources.Load("Prefabs/IngredientComponent", typeof(GameObject))) as GameObject;
		Transform cardTransform = newCard.transform;
		cardTransform.position = defaultPos;
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
