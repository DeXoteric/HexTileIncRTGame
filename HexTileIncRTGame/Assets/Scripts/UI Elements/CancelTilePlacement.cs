using UnityEngine;

public class CancelTilePlacement : MonoBehaviour
{
    public void Cancel()
    {
        Board.instance.ResetSelectedTile();
        Board.instance.HideActiveHexes();
        
    }
}