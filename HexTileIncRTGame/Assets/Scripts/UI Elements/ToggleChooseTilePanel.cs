using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleChooseTilePanel : MonoBehaviour {

    [SerializeField] private ChooseTilePanel chooseTilePanel;
    [SerializeField] private TileInfoPanel tileInfoPanel;

    public void ToggleTilePanel()
    {
        chooseTilePanel.gameObject.SetActive(!chooseTilePanel.gameObject.activeInHierarchy);
        Board.instance.ShowActiveHexes();


        if (chooseTilePanel.gameObject.activeInHierarchy)
        {
            DeselectTile();
        }

        if (tileInfoPanel.gameObject.activeInHierarchy)
        {
            CloseTileInfoPanel();
        }
    }

    private void DeselectTile() //TODO currently it's a brute force solution, move it, change it
    {
        foreach (var tile in Board.instance.placedTiles)
        {
            tile.tileHighlight.enabled = false;
        }
    }

    private void CloseTileInfoPanel()
    {
        tileInfoPanel.gameObject.SetActive(false);
    }
}
