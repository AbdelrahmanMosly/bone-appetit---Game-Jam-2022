using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Gen : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private Transform player;

    private List<GameObject> Tiles = new List<GameObject>();

    private Camera cam;
    private Vector2 prePos,currPos;

    void Start()
    {
        cam = Camera.main;
        prePos = player.position;
    }

    void Update()
    {

        transform.position = new Vector3(0,player.position.y+5,0);

        currPos = player.position;
        spawnTiles();
    }

    private void spawnTiles()
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
     
        
    }


}
