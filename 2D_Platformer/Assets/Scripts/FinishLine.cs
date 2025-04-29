using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    float LoadScene = 0;

    [SerializeField] private Object nextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("collided");
            if(LoadScene == 0){
                // Reload the current scene to restart the game
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%6);            }
            
        }
    }
}
