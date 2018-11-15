using UnityEngine;

public class PreviousTile : MonoBehaviour
{
    private int currentSelectedTileIndex;

    public void ShowPreviousTile()
    {
        currentSelectedTileIndex -= 1;

        if (currentSelectedTileIndex < 0)
        {
            currentSelectedTileIndex = Board.instance.placedTiles.Count - 1;
        }

        GetComponentInParent<TileInfoPanel>().ShowSelectedTile(Board.instance.placedTiles[currentSelectedTileIndex]);
        Board.instance.selectedTile = Board.instance.placedTiles[currentSelectedTileIndex];
    }

    private void Update()
    {
        currentSelectedTileIndex = Board.instance.GetSelectedTileIndex();
    }
}