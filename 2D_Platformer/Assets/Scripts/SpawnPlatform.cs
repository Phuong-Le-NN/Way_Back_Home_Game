using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] Sprite image;
    [SerializeField] SceneController controller;

    private int _id;
    public int Id {
        get {return _id; }
    }

    public void SetPlatform(int id, Sprite image) {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
