using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
   
    public int Demage() {
        return damage;
    }
}
