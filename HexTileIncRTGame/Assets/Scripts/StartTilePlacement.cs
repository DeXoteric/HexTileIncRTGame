using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTilePlacement : MonoBehaviour {

    [SerializeField] GameObject tilePrefab;

    public void PlaceSelectedTile()
    {
        SetSelectedTile();
        EnableActiveHexes();
        EnableUIElements();
    }

    private void SetSelectedTile()
    {
        HexTileMapManager.instance.SelectedTile = tilePrefab;
    }

	private void EnableActiveHexes()
    {
        HexTileMapManager.instance.ShowActiveHexes();
        
    }

    private void EnableUIElements()
    {
        UIManager.instance.EnableTilePlacementUIElements(tilePrefab.name);
    }


}
