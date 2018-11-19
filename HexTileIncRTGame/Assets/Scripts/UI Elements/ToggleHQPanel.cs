﻿using UnityEngine;

public class ToggleHQPanel : MonoBehaviour
{
    [SerializeField] private MainPanel mainPanel;
    [SerializeField] private TileInfoPanel tileInfoPanel;
    [SerializeField] private ChooseTilePanel chooseTilePanel;

    public void TogglePanel()
    {
        mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeInHierarchy);

        if (mainPanel.gameObject.activeInHierarchy)
        {
            DeselectTile();
        }

        if (tileInfoPanel.gameObject.activeInHierarchy)
        {
            CloseTileInfoPanel();
        }

        if (chooseTilePanel.gameObject.activeInHierarchy)
        {
            CloseChooseTileInfoPanel();
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

    private void CloseChooseTileInfoPanel()
    {
        chooseTilePanel.gameObject.SetActive(false);
        Board.instance.ResetSelectedTile();
        Board.instance.HideActiveHexes();
    }
}