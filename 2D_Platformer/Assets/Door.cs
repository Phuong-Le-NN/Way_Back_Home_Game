using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Object nextScene;

    public bool locked;
    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;
    public bool doorOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            locked = false;
            doorOpen = true;
            theSR.sprite = doorOpenSprite;
            Debug.Log("door open");
            SceneManager.LoadScene(nextScene.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("Key"))
        {
            locked = true;
        }
    }
}
