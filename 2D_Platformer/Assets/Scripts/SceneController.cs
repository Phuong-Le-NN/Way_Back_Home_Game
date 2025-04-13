using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] SpawnPlatform originalPlatform;
    [SerializeField] Sprite[] images;
    public const int gridRows = 10;
    public const int gridCols = 10;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    void Start() {
        Vector3 startPos = originalPlatform.transform.position;

        for (int i = 0; i < gridCols; i++){
            for (int j = 0; j < gridRows; j++){
                SpawnPlatform platform;
                if (i == 0 && j == 0){
                    platform = originalPlatform;
                } else {
                    platform = Instantiate(originalPlatform) as SpawnPlatform;
                }

                int id = Random.Range(0, images.Length);
                platform.SetPlatform(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * i) + startPos.y;
                platform.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }
}