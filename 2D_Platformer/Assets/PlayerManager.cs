using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    private GameObject gameOverScreen;

    public void Awake()
    {
        isGameOver = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);

        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(0);
    }
}
