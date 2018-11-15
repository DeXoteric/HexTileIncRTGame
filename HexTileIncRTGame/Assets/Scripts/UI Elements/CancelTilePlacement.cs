using UnityEngine;

public class CancelTilePlacement : MonoBehaviour
{
    public void Cancel()
    {
        HexTileMapManager.instance.ResetSelectedTile();
        HexTileMapManager.instance.HideActiveHexes();
        UIManager.instance.DisableTilePlacementUIElements();
    }
}