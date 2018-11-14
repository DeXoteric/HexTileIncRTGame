using UnityEngine;

public class HexTile : MonoBehaviour
{
    public int tileIndex;

    private void Start()
    {
        HexTileMapManager.instance.unusedHexes.Add(gameObject);
        tileIndex = HexTileMapManager.instance.unusedHexes.Count - 1;
    }

    
}