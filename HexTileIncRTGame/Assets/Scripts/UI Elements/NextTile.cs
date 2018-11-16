using UnityEngine;

public class NextTile : MonoBehaviour
{
    private int currentSelectedTileIndex;

    public void ShowNextTile()
    {
        currentSelectedTileIndex += 1;

        if (currentSelectedTileIndex > Board.instance.placedTiles.Count - 1)
        {
            currentSelectedTileIndex = 1;
        }

        if (currentSelectedTileIndex == 0)
        {
            currentSelectedTileIndex = 1;
        }

        GetComponentInParent<TileInfoPanel>().ShowSelectedTile(Board.instance.placedTiles[currentSelectedTileIndex]);
        Board.instance.selectedTile = Board.instance.placedTiles[currentSelectedTileIndex];
    }

    private void Update()
    {
        currentSelectedTileIndex = Board.instance.GetSelectedTileIndex();
    }
}