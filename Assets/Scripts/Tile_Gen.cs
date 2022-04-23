using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Gen : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private int gameObjectsPoolSize;
    [SerializeField] private float distanceBetweenTiles;


    private GameObject[] gameObjects;
    

    private Camera cam;
    private float windowSize;
    private int oldestTileIndex=0;

    void Start()
    {
        gameObjects= new GameObject[gameObjectsPoolSize];
        cam = Camera.main;
        windowSize = cam.GetComponent<Camera>().orthographicSize;
        spawnInitialTiles();
    }
    private void spawnInitialTiles()
    {
        for(int i = 0; i < gameObjectsPoolSize; i++)
        {   
            gameObjects[i] = Instantiate(tile,new Vector3(Random.Range(-10, 10) ,
                                                          (i + 1) * distanceBetweenTiles,
                                                          0),
                                                           Quaternion.identity);
        }

    }
   
    void Update()
    {
        spawnTiles();
    }
    private void spawnTiles()
    {
        if((cam.transform.position.y - windowSize)- distanceBetweenTiles * 5> gameObjects[oldestTileIndex].transform.position.y)
        {
            Destroy(gameObjects[oldestTileIndex]);
            int farestIndex = (oldestTileIndex - 1) % gameObjectsPoolSize < 0 ? gameObjectsPoolSize - 1 : (oldestTileIndex - 1) % gameObjectsPoolSize;
            float farestTilePositionY = gameObjects[farestIndex].transform.position.y;
            gameObjects[oldestTileIndex] = Instantiate(tile,new Vector3( Random.Range(-10, 10),
                                                           farestTilePositionY + distanceBetweenTiles,
                                                            0),
                                                           Quaternion.identity);
            oldestTileIndex=(oldestTileIndex+1) % gameObjectsPoolSize;
        }
    }

}
