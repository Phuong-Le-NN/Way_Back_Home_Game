using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
   public GameObject gameOverUI;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
       gameOverUI.SetActive(false);
   }


   // Update is called once per frame
   void Update()
   {
      
   }


   public void gameOver(){
       gameOverUI.SetActive(true);
   }
}


