using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    // Start is called before the first frame update

    private bool _throwByHero = false;

    public bool ThrowByHero()
    {
        return this._throwByHero;
    }

    public void ThrowByHero(bool hero) {
        this._throwByHero = hero;
    }

}
