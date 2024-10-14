using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject victoryFlag;
    
    private Damageable damageable;
    private GoToNextLevel goToNextLevel;
    private bool stop = false;

    private void Awake() {
        damageable = player.GetComponent<Damageable>();
        goToNextLevel = victoryFlag.GetComponent<GoToNextLevel>();
    }

    void Update() {
        if (stop) return;
        if (damageable.isDead == true) {
            Debug.Log("Player is dead");
            Invoke("RestartGame", 2f);
            stop = true;
        }

        if (goToNextLevel.nextLevel == true) {
            LoadNextLevel();
            stop = true;
        }
    }
    
    void RestartGame() {
        Debug.Log("Restarting game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void LoadNextLevel() {
        Debug.Log("Loading next level");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
