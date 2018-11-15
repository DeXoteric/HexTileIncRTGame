using UnityEngine;

public class HexTile : MonoBehaviour
{
    public int tileIndex;

    private void Start()
    {
        Board.instance.unusedHexes.Add(gameObject);
        tileIndex = Board.instance.unusedHexes.Count - 1;
    }

    
}