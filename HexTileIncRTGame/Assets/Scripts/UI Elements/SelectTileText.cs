using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectTileText : MonoBehaviour {

    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "Select Tile";
    }

    private void Update()
    {
        if (Board.instance.selectedTileSO != null)
        {
            GetComponent<TextMeshProUGUI>().text = Board.instance.selectedTileSO.tileName + " selected";
        }
    }
}
