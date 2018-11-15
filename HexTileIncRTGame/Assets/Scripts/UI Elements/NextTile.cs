using UnityEngine;

public class NextTile : MonoBehaviour
{
    private int currentSelectedTileIndex;

    public void ShowNextTile()
    {
        currentSelectedTileIndex += 1;

        if (currentSelectedTileIndex > HexTileMapManager.instance.placedTiles.Count - 1)
        {
            currentSelectedTileIndex = 0;
        }

        GetComponentInParent<TileInfoPanel>().ShowSelectedTile(HexTileMapManager.instance.placedTiles[currentSelectedTileIndex]);
        HexTileMapManager.instance.selectedTile = HexTileMapManager.instance.placedTiles[currentSelectedTileIndex];
    }

    private void Update()
    {
        currentSelectedTileIndex = HexTileMapManager.instance.GetSelectedTileIndex();
    }
}