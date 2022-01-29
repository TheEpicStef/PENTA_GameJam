using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetSwap : MonoBehaviour
{
    public TileSet TileCouples ;
    void Start()
    {
        
        Tilemap tilemap = GetComponent<Tilemap>();
        foreach (TileCouple i in TileCouples.tiles.AllTiles)
        {
           
            tilemap.SwapTile(i.tileA, i.tileB);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
