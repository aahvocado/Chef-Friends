using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #singleton
public class GameInstantiator : MonoBehaviour {
	GameObject CardComponentPrefab;

	// Use this for initialization
	void Start () {
    	// CardComponentPrefab = Instantiate(Resources.Load("Prefabs/CardComponent", typeof(GameObject))) as GameObject;
	}

	//
	public GameObject instantiateDish (Vector3 newPos) {
		GameObject newDish = Instantiate(Resources.Load("Prefabs/DishComponent", typeof(GameObject))) as GameObject;
		Transform cardTransform = newDish.transform;
		cardTransform.position = newPos;
		return newDish;
	}

	//
	public GameObject instantiateCard (Vector3 newPos) {
		GameObject newCard = Instantiate(Resources.Load("Prefabs/CardComponent", typeof(GameObject))) as GameObject;
		Transform cardTransform = newCard.transform;
		cardTransform.position = newPos;
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
