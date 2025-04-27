using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour
{
    [SerializeField] private Object nextScene;
    
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("start");
    }

}
