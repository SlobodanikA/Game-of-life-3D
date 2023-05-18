using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;

public class Prey : Cell 
{
    public int timeToReproduce;
        public void moveFrom(Coordinate from,Coordinate to){
            --timeToReproduce;
            if(to != from){
                setOffset(to);
                assignCellAt(to, this);
                model.GetComponent<ObjectMovement>().MoveTo(new Vector3(offset.getY() * 10, 0 , offset.getX() * 10));
                if(timeToReproduce <= 0){
                    timeToReproduce = TimeToReproduce;
                    assignCellAt(from, reproduce(from));
                }
                else{
                    assignCellAt(from, new EmptyCell(from, this.Viewer));
                }
            }
        }
    public override Cell reproduce(Coordinate anOffset){
        Prey temp = new Prey(anOffset, this.Viewer);
        Debug.Log(anOffset.getY() + " " + anOffset.getX() + "spawn Prey");
        Viewer.setNumPrey(Viewer.getNumPrey()+1);
        return temp;
    }
    public Prey(Coordinate aCoord,Ocean l) : base(aCoord, l){
        timeToReproduce= (int)UnityEngine.Random.Range(3,9); //Допускаються числа
        image = DefaultPreyImage;
        model = GameObject.Instantiate<GameObject>(l.objs[0]);
        model.transform.position = new Vector3(aCoord.getY() * 10, 0, aCoord.getX() * 10);
    }
    public Prey(Coordinate aCoord,Ocean l, int a) : base(aCoord, l){
        timeToReproduce= (int)UnityEngine.Random.Range(3,9); //Допускаються числа
        image = DefaultPreyImage;
    }
    public override void process(){
        Coordinate toCoord;
        toCoord = getEmptyNeighborCoord();
        moveFrom(offset, toCoord);
    }
}
