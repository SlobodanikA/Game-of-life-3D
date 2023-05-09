public class EmptyCell : Cell
{
    public EmptyCell(Coordinate coordinate, Ocean l) : base(coordinate, l)
    {
        // добавьте здесь необходимые инициализации, если они требуются
    }

    public override void process()
    {
        // пустая реализация
    }
    public override Cell reproduce(Coordinate anOffset)
    {
        throw new System.NotImplementedException();
    }
}