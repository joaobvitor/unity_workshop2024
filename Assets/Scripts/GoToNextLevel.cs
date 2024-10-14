using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNextLevel : MonoBehaviour
{
    public bool nextLevel = false;
   
   private void OnCollisionEnter2D(Collision2D other) {
      if (other.gameObject.CompareTag("Player")) {
        nextLevel= true;
      }
   }
}
