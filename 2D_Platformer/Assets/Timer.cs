using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject gameOverPanel; 

     void Start()
    {
        gameOverPanel.SetActive(false); // Hide the Game Over panel when the level starts
    }
    void Update()
    {
        bool panelOff = true;
		foreach (GameObject panel in panels){
			if (panel.activeSelf){
				panelOff = false;
				break;
			}
		}
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            gameOverPanel.SetActive(true);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}

