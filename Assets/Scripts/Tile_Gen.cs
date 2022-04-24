using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Gen : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private int gameObjectsArrPoolSize;
    [SerializeField] private float distanceBetweenTiles;
    [SerializeField] private int allowance;
    [SerializeField] private int conditionalDisplacement;
    [SerializeField] private int maxDisplacement;


    private GameObject[] gameObjectsArr;
    

    private Camera cam;
    private float windowSize;
    private int oldestTileIndex=0;

    void Start()
    {
        gameObjectsArr= new GameObject[gameObjectsArrPoolSize];
        cam = Camera.main;
        windowSize = cam.GetComponent<Camera>().orthographicSize;
        spawnInitialTiles();
    }
    private void spawnInitialTiles()
    {
        for(int i = 0; i < gameObjectsArrPoolSize; i++)
        {
            int rand = Random.Range(-maxDisplacement, maxDisplacement);
            gameObjectsArr[i] = Instantiate(tile,new Vector3(rand+((i>0)? gameObjectsArr[i-1].transform.position.x:0),
                                                          (i + 1) * distanceBetweenTiles,
                                                          0),
                                                           Quaternion.identity);
            if (i > 0 && Mathf.Abs(gameObjectsArr[i - 1].transform.position.x - gameObjectsArr[i].transform.position.x) < allowance)
                gameObjectsArr[i].transform.position = new Vector3(gameObjectsArr[i].transform.position.x + conditionalDisplacement
                                    , gameObjectsArr[i].transform.position.y
                                    , 0
                                    ) ;
        }

    }
   
    void Update()
    {
        spawnTiles();
    }
    private void spawnTiles()
    {
        if((cam.transform.position.y - windowSize)- distanceBetweenTiles * 5> gameObjectsArr[oldestTileIndex].transform.position.y)
        {
            Destroy(gameObjectsArr[oldestTileIndex]);
            int farestIndex = (oldestTileIndex - 1) % gameObjectsArrPoolSize < 0 ? gameObjectsArrPoolSize - 1 : (oldestTileIndex - 1) % gameObjectsArrPoolSize;
            float farestTilePositionY = gameObjectsArr[farestIndex].transform.position.y;
            gameObjectsArr[oldestTileIndex] = Instantiate(tile,new Vector3( Random.Range(-10, 10),
                                                           farestTilePositionY + distanceBetweenTiles,
                                                            0),
                                                           Quaternion.identity);
            oldestTileIndex=(oldestTileIndex+1) % gameObjectsArrPoolSize;
        }
    }

}
