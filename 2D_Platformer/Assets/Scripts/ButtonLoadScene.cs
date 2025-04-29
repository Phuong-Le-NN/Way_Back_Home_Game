using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
    [SerializeField] private Object nextScene;
    
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("FirstLvl");
    }

    public void LoadNextBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}