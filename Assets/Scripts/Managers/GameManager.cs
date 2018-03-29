using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Super Awesome Game Controller
    
    #singleton
*/
public class GameManager : MonoBehaviour {
    // singletons
    // public GameInstantiator _GameInstantiator;

    // player stuff
    PlayerManager Player1;
    // PlayerManager Player2;

    // Use this for initialization
    void Start () {
        // get singletons
        // _GameInstantiator = GameInstantiator.getInstance;

        Player1 = new PlayerManager();
    }

    // Update is called once per frame
    void Update () {
        
    }

    // uses the Cook card
    public void useCook(int power) {
    }

    // create singleton
    private static GameManager _instance;
    public static GameManager getInstance { get { return _instance; } }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}
