using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField] Text placeTileText;
    [SerializeField] GameObject cancelPlacementButton;

    private void Awake()
    {
        instance = this;

    }

    public void EnableTilePlacementUIElements(string tileName)
    {
        placeTileText.gameObject.SetActive(true);
        cancelPlacementButton.SetActive(true);
        placeTileText.text = "Place " + tileName + " on the board";
    }

    public void DisableTilePlacementUIElements()
    {
        placeTileText.gameObject.SetActive(false);
        cancelPlacementButton.SetActive(false);
    }
}
