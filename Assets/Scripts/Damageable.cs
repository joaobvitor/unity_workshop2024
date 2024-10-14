using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public bool isDead = false;

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap") && !isDead) {
            Die();
        } 
    }

    void Die() {
        isDead = true;
        Debug.Log("Player died!");
    }
}
