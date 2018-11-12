using System.Collections.Generic;
using UnityEngine;

public class HexTileMapManager : MonoBehaviour
{
    public static HexTileMapManager instance;

    [SerializeField] private GameObject startingTile;
    [SerializeField] private LayerMask clickMask;

    public GameObject SelectedTile { get; set; }

    public List<GameObject> unusedHexes = new List<GameObject>();
    public List<GameObject> activeHexes = new List<GameObject>();

    public bool newGame = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (newGame)
        {
            GameObject tile = Instantiate(startingTile, Vector3.zero, Quaternion.identity);
            tile.name = startingTile.name;
            tile.transform.parent = transform;
            tile.tag = "Placed Tile";
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
        } else
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
                    GameObject placedTile =  Instantiate(SelectedTile, tilePosition, Quaternion.identity);

                    placedTile.name = SelectedTile.name;
                    placedTile.transform.parent = transform;
                    placedTile.tag = "Placed Tile";

                    UIManager.instance.DisableTilePlacementUIElements();
                    ResetSelectedTile();
                    HideActiveHexes();
                }
            }
        }
    }
}