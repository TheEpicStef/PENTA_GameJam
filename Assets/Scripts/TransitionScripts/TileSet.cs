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

[System.Serializable]
public struct TileCoupleList
{
    public List<TileCouple> AllTiles;
}

public class TileSet : MonoBehaviour
{
    public TileCoupleList tiles;
}
