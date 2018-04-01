using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ease of access for singletons
*/
public class SingletonHelper {
    public GameInstantiator Instantiator;
    public GameManager Game;

    public SingletonHelper() {
        Instantiator = GameInstantiator.getInstance;
        Game = GameManager.getInstance;
    }
}
