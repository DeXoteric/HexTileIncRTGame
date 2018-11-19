public class TileHQ : Tile
{
   

    private void Start()
    {
        tileType[0] = TileType.Headquarter;
        gameObject.name = tileName;
        tileLevel = 1;

        GameManager.instance.placedTiles += 1;

        RefreshData();
        RefreshDataDisplay();
    }
}