public class TileHQ : Tile
{
   

    private void Start()
    {
        tileType[0] = TileType.Headquarter;
        gameObject.name = tileName;
        tileLevel = 1;

        Board.instance.placedTiles += 1;
        
    }
}