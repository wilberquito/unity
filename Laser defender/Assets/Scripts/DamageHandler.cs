using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] int damage = 100;
   private void OnTriggerEnter2D(Collider2D other) {
       var enemy = other.gameObject.GetComponent<Enemy>();
   
        if (enemy) {
            enemy.Hit(this.damage);
        }
   }
}
