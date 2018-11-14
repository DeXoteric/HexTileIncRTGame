using UnityEngine;

public class StartTilePlacement : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

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