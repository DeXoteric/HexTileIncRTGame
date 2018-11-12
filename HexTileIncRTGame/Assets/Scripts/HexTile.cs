using UnityEngine;

public class HexTile : MonoBehaviour
{
    public int tileIndex;

    private void Start()
    {
        HexTileMapManager.instance.unusedHexes.Add(gameObject);
        tileIndex = HexTileMapManager.instance.unusedHexes.Count - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Capsule Collider")
        {
            HexTileMapManager.instance.unusedHexes.Remove(gameObject);
            HexTileMapManager.instance.activeHexes.Remove(gameObject);
            Destroy(gameObject);
        }

        if (other.name == "Mesh Collider" )
        {
            if (gameObject.tag == "Empty Hex")
            {
                HexTileMapManager.instance.activeHexes.Add(gameObject);
                gameObject.tag = "Active Hex";
            }
        }
    }
}