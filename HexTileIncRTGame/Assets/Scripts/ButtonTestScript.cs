using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTestScript : MonoBehaviour {

	public void EnableActiveHexes()
    {
        var activeHexes = HexTileMapManager.instance.activeTiles;

        foreach (var hex in activeHexes)
        {
            hex.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
}
