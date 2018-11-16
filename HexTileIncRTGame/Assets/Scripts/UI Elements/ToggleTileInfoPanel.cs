using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTileInfoPanel : MonoBehaviour {

    [SerializeField] private TileInfoPanel tileInfoPanel;

    public void TogglePanel()
    {

        if (tileInfoPanel.gameObject.activeInHierarchy)
        {
            DeselectTile();
        }

        tileInfoPanel.gameObject.SetActive(false);

        
    }

    private void DeselectTile() //TODO currently it's a brute force solution, move it, change it
    {
        foreach (var tile in Board.instance.placedTiles)
        {
            tile.tileHighlight.enabled = false;
        }
    }
}
