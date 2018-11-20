using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    

    [HideInInspector] public List<Sprite> tileTypeIcons = new List<Sprite>();

    private void Awake()
    {
        instance = this;

        tileTypeIcons.AddRange(Resources.LoadAll<Sprite>("Sprites/Tile Type Icons"));
    }

}