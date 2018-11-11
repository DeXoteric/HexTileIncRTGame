using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject hexTilePrefab;

    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    private float tileXOffset = 1.75f;
    private float tileZOffset = 1.515f;

    private void Start()
    {
        CreateHexTileMap();
    }

    private void CreateHexTileMap()
    {
        int mapXMin = -mapWidth / 2;
        int mapXMax = mapWidth / 2;
        int mapZMin = -mapHeight / 2;
        int mapZMax = mapHeight / 2;

        if (mapWidth % 2 != 0)
        {
            mapXMax += 1;
        }

        if (mapHeight % 2 != 0)
        {
            mapZMax += 1;
        }

        for (int z = mapZMin; z < mapZMax; z++)
        {
            for (int x = mapXMin; x < mapXMax; x++)
            {
                GameObject hexTile = Instantiate(hexTilePrefab);

                if (z % 2 == 0)
                {
                    hexTile.transform.position = new Vector3(x * tileXOffset, 0f, z * tileZOffset);
                }
                else
                {
                    hexTile.transform.position = new Vector3(x * tileXOffset + tileXOffset / 2, 0f, z * tileZOffset);
                }

                SetTileInfo(hexTile, x, z);
            }
        }
    }

    private void SetTileInfo(GameObject hexTile, int x, int z)
    {
        hexTile.transform.parent = transform;
        hexTile.name = "tile (" + x.ToString() + "," + z.ToString() + ")";
    }
}