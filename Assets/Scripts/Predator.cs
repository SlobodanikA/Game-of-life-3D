using UnityEngine;
using static GameData;

public class Predator : Prey 
{
    protected int timeToFeed;
    public override Cell reproduce(Coordinate anOffset){ //               Не дает сделать приватным
        Debug.Log(anOffset.getY() + " " + anOffset.getX() + "spawn Predator");
        Predator temp = new Predator(anOffset, this.Viewer);
        Viewer.setNumPredators(Viewer.getNumPredator()+1);
        return temp;
    }
    public Predator(Coordinate aCoord, Ocean l) : base(aCoord, l, 1){
        timeToFeed = TimeToFeed;
        image = DefaultPredatorImage;
        model = GameObject.Instantiate<GameObject>(l.objs[1]);
        model.transform.position = new Vector3(aCoord.getY() * 10, 0, aCoord.getX() * 10);
    }
    public override void process() {
        Coordinate toCoord;
        --timeToFeed;
        if (timeToFeed <= 0){
            assignCellAt(offset, new EmptyCell(offset, this.Viewer));
            Debug.Log(offset.getY() + " " + offset.getX() + "feed Death Predator");
            Viewer.setNumPredators(Viewer.getNumPredator()-1);
            GameObject.Destroy(model);
            //finalize();                                          Как удалять и нужно ли вообще?
        }
        else{
            toCoord = getPreyNeighborCoord();
            if(toCoord != this.offset){
                Viewer.cells[toCoord.getY(),toCoord.getX()].model.GetComponent<PreyDestroy>().DestroyObjectDelayed();
                Debug.Log(toCoord.getY() + " " + toCoord.getX() + "Eaten");
                Viewer.setNumPrey(Viewer.getNumPrey()-1);
                timeToFeed = TimeToFeed;
                moveFrom(offset,toCoord);
            }
            else {
                base.process();
            }
        }
    }
}