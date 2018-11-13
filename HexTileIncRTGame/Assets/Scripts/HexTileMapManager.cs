using System.Collections.Generic;
using UnityEngine;

public class HexTileMapManager : MonoBehaviour
{
    public static HexTileMapManager instance;

    [SerializeField] private GameObject hqTile;

    [SerializeField] private LayerMask clickMask;

    public GameObject SelectedTile { get; set; }

    public List<GameObject> unusedHexes = new List<GameObject>();
    public List<GameObject> activeHexes = new List<GameObject>();
    public List<GameObject> placedTiles = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (GameManager.instance.isNewGame)
        {
            GameObject tile = Instantiate(hqTile, Vector3.zero, Quaternion.identity);
            tile.name = hqTile.name;
            tile.transform.parent = transform;
            tile.tag = "Placed Tile";

            placedTiles.Add(tile);
        }
    }

    public void ShowActiveHexes()
    {
        foreach (var hex in activeHexes)
        {
            hex.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }

    public void HideActiveHexes()
    {
        foreach (var hex in activeHexes)
        {
            hex.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

    public void ResetSelectedTile()
    {
        SelectedTile = null;
    }

    private void Update()
    {
        if (SelectedTile != null)
        {
            PlaceTile();
        }
        else
        {
        }
    }

    private void PlaceTile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, clickMask))
            {
                if (hit.rigidbody.tag == "Active Hex")
                {
                    var tilePosition = hit.rigidbody.transform.position;
                    GameObject tile = Instantiate(SelectedTile, tilePosition, Quaternion.identity);

                    tile.name = SelectedTile.name;
                    tile.transform.parent = transform;
                    tile.tag = "Placed Tile";

                    placedTiles.Add(tile);

                    UIManager.instance.DisableTilePlacementUIElements();
                    ResetSelectedTile();
                    HideActiveHexes();
                }
            }
        }
    }
}