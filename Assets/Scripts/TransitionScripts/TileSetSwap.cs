using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public struct TileCouple
{
    public TileBase tileA;
    public TileBase tileB;
}


public class TileSetSwap : MonoBehaviour
{
    public List<TileCouple> AllTiles ;

    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        foreach (TileCouple i in AllTiles)
        {
            tilemap.SwapTile(i.tileA, i.tileB);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
