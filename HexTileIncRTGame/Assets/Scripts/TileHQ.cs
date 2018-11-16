public class TileHQ : Tile
{
   

    private void Start()
    {
        tileType[0] = TileType.Headquarter;
        gameObject.name = tileName;

        GameManager.instance.placedTiles += 1;

        RefreshData();
        RefreshDataDisplay();
    }
}