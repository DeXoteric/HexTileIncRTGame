using UnityEngine;

public class PreviousTile : MonoBehaviour
{
    private int currentSelectedTileIndex;

    public void ShowPreviousTile()
    {
        currentSelectedTileIndex -= 1;

        if (currentSelectedTileIndex < 0)
        {
            currentSelectedTileIndex = HexTileMapManager.instance.placedTiles.Count - 1;
        }

        GetComponentInParent<TileInfoPanel>().ShowSelectedTile(HexTileMapManager.instance.placedTiles[currentSelectedTileIndex]);
        HexTileMapManager.instance.selectedTile = HexTileMapManager.instance.placedTiles[currentSelectedTileIndex];
    }

    private void Update()
    {
        currentSelectedTileIndex = HexTileMapManager.instance.GetSelectedTileIndex();
    }
}