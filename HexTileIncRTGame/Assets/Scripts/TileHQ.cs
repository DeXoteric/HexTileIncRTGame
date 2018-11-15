public class TileHQ : Tile
{
    private void Start()
    {
        gameObject.name = tileName;

        GameManager.instance.placedTiles += 1;

        RefreshData();
        RefreshDataDisplay();
    }
}