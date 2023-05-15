using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : CONSTANTA
{
    public Ocean Viewer = null;
    public Coordinate offset;
    public String image;
    public GameObject model;
    public Cell(Coordinate aCord, Ocean l) {
        model = null;
        Viewer = l;
        offset = new Coordinate(aCord);
        image = DefaultImage;
    }
    public String getImage() {
        return image;
    }
    public Cell(){
    }
    public Cell getCallAt(Coordinate aCord) {
        return Viewer.getCell(aCord.getY(),aCord.getX());
    }
    public Cell getNeighborWithImage(String anImage){
        Cell [] neighbors = new Cell[NumOfNeighbors];
        int count = 0;
        if(north().getImage() == anImage){
            neighbors[count++] = north();
        }
        if(south().getImage() == anImage){
            neighbors[count++] = south();
        }
        if(east().getImage() == anImage){
            neighbors[count++] = east();
        }
        if(west().getImage() == anImage){
            neighbors[count++] = west();
        }
        if(count == 0){
            return this;
        }
        else{
            return neighbors[((int) UnityEngine.Random.Range(0, count-1))];
        }
    }
    public Coordinate getEmptyNeighborCoord(){
        return getNeighborWithImage(DefaultImage).getOffset();
    }
    public Coordinate getPreyNeighborCoord(){
        return getNeighborWithImage(DefaultPreyImage).getOffset();
    }
    public Coordinate getOffset() {
        return offset;
    }
    public void assignCellAt(Coordinate aCord, Cell aCell){
        Viewer.setCell(aCell,aCord);
    }
    public Cell north(){
        int yValue;
        yValue = (offset.getY()>0) ? (offset.getY()-1):(offset.getY());
        return Viewer.getCell(yValue,offset.getX());
    }
    public Cell south(){
        int yValue;
        yValue = (offset.getY() < Viewer.getNumRows()-1) ? (offset.getY()+1):(offset.getY());
        return Viewer.getCell(yValue,offset.getX());
    }
    public Cell east(){
        int xValue;
        xValue = (offset.getX() < Viewer.getNumCols()-1) ? (offset.getX()+1):(offset.getX());
        return Viewer.getCell(offset.getY(),xValue);
    }

    public Cell west(){
        int xValue;
        xValue = (offset.getX()>0)?(offset.getX()-1):(offset.getX());
        return Viewer.getCell(offset.getY(),xValue);
    }
    public abstract Cell reproduce(Coordinate anOffset);
    public void setOffset(Coordinate anOffset) {
        offset = anOffset;
    }
    public abstract void process();
}