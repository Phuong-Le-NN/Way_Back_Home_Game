using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] SpawnPlatform originalPlatform;
    [SerializeField] Sprite[] images;
    [SerializeField] GameObject end;
    public const int gridRows = 10;
    public const int gridCols = 10;
    float offsetX = 2f;
    float offsetY = 2.5f;
    float distance = 0f;
    float posX;
    float posY;

    float near;

    void Start() {
        Vector3 startPos = originalPlatform.transform.position;
        posX = originalPlatform.transform.position.x;
        posY = originalPlatform.transform.position.y;
        bool firstPlatform = true;
        float ran = Random.Range(0f, 1f);
            while((Mathf.Abs(posX - end.transform.position.x) > 3f) || (Mathf.Abs(posY - end.transform.position.y) > 3f)){
                SpawnPlatform platform;
                if (firstPlatform){
                    float offSetEndX = Random.Range(40f, 45f);
                    float offSetEndY = Random.Range(20f, 25f);
                    if (ran >= 0.5f){
                        offSetEndX = - offSetEndX;
                    }
                    ran = Random.Range(0f, 1f);
                    if (ran >= 0.5f){
                        offSetEndY = - offSetEndY;
                    }
                    platform = originalPlatform;
                    firstPlatform = false;
                    end.transform.position = new Vector3(originalPlatform.transform.position.x + offSetEndX, originalPlatform.transform.position.y + offSetEndY, startPos.z);
                    // ran = 0;
                    continue;
                } else {
                    platform = Instantiate(originalPlatform) as SpawnPlatform;
                }

                int id = 0;
                platform.SetPlatform(id, images[id]);

                offsetX = Random.Range(4f, 6f);
                offsetY = Random.Range(1.2f, 1.8f); 
                if ((end.transform.position.x > posX)){
                    posX = posX + offsetX;
                }
                else{
                    posX = posX - offsetX;
                }
                if ((end.transform.position.y > posY)){
                    posY = posY + offsetY;
                }
                else{
                    posY = posY - offsetY;
                }
                platform.transform.position = new Vector3(posX, posY, startPos.z);
            }
            //sometimes the last platform got layered on the cup so we transform the position of the cup one last time at the end to not be hidden
            end.transform.position = new Vector3(posX, posY + 1, startPos.z);
    }
}