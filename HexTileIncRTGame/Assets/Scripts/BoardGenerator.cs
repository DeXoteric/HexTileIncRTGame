using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject hexPrefab;

    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    private float tileXOffset = 1.80f;
    private float tileYOffset = 1.565f;

    private void Start()
    {
        CreateHexTileMap();
    }

    private void CreateHexTileMap()
    {
        int mapXMin = -mapWidth / 2;
        int mapXMax = mapWidth / 2;
        int mapYMin = -mapHeight / 2;
        int mapYMax = mapHeight / 2;

        if (mapWidth % 2 != 0)
        {
            mapXMax += 1;
        }

        if (mapHeight % 2 != 0)
        {
            mapYMax += 1;
        }

        for (int y = mapYMin; y < mapYMax; y++)
        {
            for (int x = mapXMin; x < mapXMax; x++)
            {
                GameObject hex = Instantiate(hexPrefab);

                if (y % 2 == 0)
                {
                    hex.transform.position = new Vector2(x * tileXOffset, y * tileYOffset);
                }
                else
                {
                    hex.transform.position = new Vector2(x * tileXOffset + tileXOffset / 2, y * tileYOffset);
                }

                SetTileInfo(hex, x, y);
            }
        }
    }

    private void SetTileInfo(GameObject hexTile, int x, int y)
    {
        hexTile.transform.parent = transform;
        hexTile.name = "tile (" + x.ToString() + "," + y.ToString() + ")";
    }
}