using DeXoteric;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board instance;

    public List<TileSO> tilesSO;
    [SerializeField] private GameObject hqTile;

    [SerializeField] private LayerMask tilePlacementMask;

    [SerializeField] private GameObject tileTemplatePrefab;

    [HideInInspector] public Tile selectedTile;
    [HideInInspector] public TileSO selectedTileSO;

    public List<GameObject> unusedHexes = new List<GameObject>();
    public List<GameObject> activeHexes = new List<GameObject>();
    public List<Tile> placedTilesList = new List<Tile>();
    public int placedTiles;

    private GameObject[] hexes;
    private bool rerollHexes = true;
    public bool rerollTiles = true;

    private Vector3 mouseStart;
    private Vector2 touchStart;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject tile = Instantiate(hqTile, Vector2.zero, Quaternion.identity);
        tile.name = hqTile.name;
        tile.transform.parent = transform;

        placedTilesList.Add(tile.GetComponent<Tile>());
    }

    private void Update()
    {
        if (selectedTileSO != null)
        {
            if (!Utils.IsOnMobile())
            {
                PlaceTileMouse();
            }
            else
            {
                PlaceTileTouch();
            }
        }
    }

    public void ShowActiveHexes()
    {
        int hexesToShow = (int)activeHexes.Count / 2;

        if (rerollHexes)
        {
            hexes = new GameObject[hexesToShow];

            for (int i = 0; i < hexesToShow; i++)
            {
                hexes[i] = activeHexes[Random.Range(0, activeHexes.Count)];
            }
        }

        foreach (var hex in hexes)
        {
            hex.GetComponent<SpriteRenderer>().enabled = true;
        }

        rerollHexes = false;

        //foreach (var hex in activeHexes)
        //{
        //    hex.GetComponent<SpriteRenderer>().enabled = true;
        //}
    }

    public void HideActiveHexes()
    {
        foreach (var hex in activeHexes)
        {
            hex.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void ResetSelectedTile()
    {
        selectedTileSO = null;
    }

    private void PlaceTileMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Input.mousePosition != mouseStart) return;
            if (Utils.IsPointerOverUIObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            PlaceTileOnSelectedHex(ray);
        }
    }

    private void PlaceTileTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStart = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (Input.GetTouch(0).position != touchStart) return;
            if (Utils.IsPointerOverUIObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            PlaceTileOnSelectedHex(ray);
        }
    }

    private void PlaceTileOnSelectedHex(Ray ray)
    {
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f, tilePlacementMask);

        if (hit.collider != null)
        {
            if (hit.rigidbody.tag == "Active Hex" && hit.collider.GetComponent<SpriteRenderer>().isVisible)
            {
                var tilePosition = hit.rigidbody.transform.position;
                GameObject tile = Instantiate(tileTemplatePrefab, tilePosition, Quaternion.identity);

                tile.GetComponent<Tile>().selectedTileSO = selectedTileSO;
                tile.transform.parent = transform;

                placedTilesList.Add(tile.GetComponent<Tile>());

                ResetSelectedTile();
                HideActiveHexes();
                rerollHexes = true;
            }
        }
    }
}