using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tile;
    public float startPointX = -8.26f, startPointY = 2.8745f;
    public float dimensionOfTile = 1.301f;

    private List<GameObject> setOfTiles= new List<GameObject>();


    void Start()
    {
        SpawnTiles();
    }

    void SpawnTiles()
    {
        for(int i = 0; i<14; i++)
        {
            for(int j = 0; j<7; j++)
            {
                Vector2 currentPointOfSpawn = new Vector2(startPointX + i * dimensionOfTile, startPointY - j *  dimensionOfTile);
                GameObject thisTile = Instantiate(tile, currentPointOfSpawn, Quaternion.identity);
                thisTile.transform.parent = gameObject.transform;
                setOfTiles.Add(thisTile);
            }
        } 
        
    }
}
