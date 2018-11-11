using UnityEngine;

public class HexTile : MonoBehaviour
{
    public int tileIndex;

    private void Start()
    {
        HexTileMapManager.instance.unusedTiles.Add(gameObject);
        tileIndex = HexTileMapManager.instance.unusedTiles.Count - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Capsule Collider")
        {
            Destroy(gameObject);
            HexTileMapManager.instance.unusedTiles.Remove(gameObject);
            HexTileMapManager.instance.activeTiles.Remove(gameObject);
        }

        if (other.name == "Mesh Collider")
        {
            gameObject.tag = "Active Hex";
            HexTileMapManager.instance.activeTiles.Add(gameObject);
        }
    }
}