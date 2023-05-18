using static GameData;

public class Obstacle : Cell 
{
    public Obstacle(Coordinate aCoord, Ocean l) : base(aCoord, l){
        image = ObstacleImage;
    }
    public override void process()
    {
        throw new System.NotImplementedException();
    }
    public override Cell reproduce(Coordinate anOffset)
    {
        throw new System.NotImplementedException();
    }
}