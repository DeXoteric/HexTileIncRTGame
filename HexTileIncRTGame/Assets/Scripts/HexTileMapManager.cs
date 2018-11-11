using System.Collections.Generic;
using UnityEngine;

public class HexTileMapManager : MonoBehaviour
{
    public static HexTileMapManager instance;

    [SerializeField] private GameObject startingTile;

    public List<GameObject> unusedTiles = new List<GameObject>();
    public List<GameObject> activeTiles = new List<GameObject>();

    public bool newGame = true;

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        if (newGame)
        {
            GameObject tile = Instantiate(startingTile, Vector3.zero, Quaternion.identity);
            tile.name = startingTile.name;
            tile.transform.parent = transform;
        }
    }
}