using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Start()
    {
        Instantiate(StartGameManager.instance.currentCharacter.prefab, transform.position, 
        Quaternion.identity);
    }
}
