using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2DoorSceneCtrller : MonoBehaviour {
    [SerializeField] GameObject start;
    [SerializeField] SpawnKeyPlatform keyPlatform;
    [SerializeField] Sprite[] images;
    [SerializeField] GameObject end;
    [SerializeField] GameObject cat;
    public const int gridRows = 10;
    public const int gridCols = 10;
    float offsetX = 2f;
    float offsetY = 2.5f;
    float posX;
    float posY;

    float near;

    public void InitKey2Door() {
        Vector3 startPos = keyPlatform.transform.position;
        posX = keyPlatform.transform.position.x;
        posY = keyPlatform.transform.position.y;
        bool firstPlatform = true;
        float ran = Random.Range(0f, 1f);
            while((Mathf.Abs(posX - end.transform.position.x) > 3f) || (Mathf.Abs(posY - end.transform.position.y) > 3f)){
                SpawnKeyPlatform platform;
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
                    platform = keyPlatform;
                    firstPlatform = false;
                    float endX = keyPlatform.transform.position.x + offSetEndX;
                    if (Mathf.Abs(keyPlatform.transform.position.x + offSetEndX - start.transform.position.x) < 10f ){
                        if (keyPlatform.transform.position.x > start.transform.position.x){
                            endX = start.transform.position.x - 12f;
                        } else {
                            endX = start.transform.position.x + 12f;
                        }
                    }
                    end.transform.position = new Vector3(endX, keyPlatform.transform.position.y + offSetEndY, startPos.z);
                    // ran = 0;
                    continue;
                } else {
                    platform = Instantiate(keyPlatform) as SpawnKeyPlatform;
                }

                int id = 0;
                platform.SetPlatform(id, images[id]);

                offsetX = Random.Range(4f, 5.5f);
                offsetY = Random.Range(1.2f, 1.5f); 
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
            cat.transform.position = new Vector3(posX, posY + 1, startPos.z + 1);
    }
}