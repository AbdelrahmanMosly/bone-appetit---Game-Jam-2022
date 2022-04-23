using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Gen : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private Transform player;
    [SerializeField] private int gameObjectsPoolSize;
    [SerializeField] private float distanceBetweenTiles;

    //private List<GameObject> Tiles = new List<GameObject>();

    private GameObject[] gameObjects;
    

    private Camera cam;
    private float windowSize;
    [SerializeField] // serialze for debug purpose
    private int oldestTileIndex=0;

    private Vector2 prePos,currPos;

    void Start()
    {
        gameObjects= new GameObject[gameObjectsPoolSize];
        cam = Camera.main;
        windowSize = cam.GetComponent<Camera>().orthographicSize;
      //  prePos = player.position;
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
        //transform.position = new Vector3(0,player.position.y+5,0);

      //  currPos = player.position;
       // spawnTiles();
    }
    void spawnTiles()
    {
        if((cam.transform.position.y - windowSize)> gameObjects[oldestTileIndex].transform.position.y)
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
    /* private void spawnTiles()
     {
         //the player position if higher than (previous positon+10) than spawn one tile in either 1 or 2 or 3

         if (currPos.y > (prePos.y + 3))
         {
             int rand = Random.Range(0, 3);
             GameObject t = Instantiate(tile, transform.GetChild(rand));
             t.transform.parent = null;
             prePos = currPos;
             //Tiles.Add();
         }


     }*/


}
