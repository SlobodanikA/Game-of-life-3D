using UnityEngine;
using static GameData;

public class Ocean 
{
    public int numIterations;
    public int numRows;
    public int numCols;
    public int size;
    public int numPrey;
    public int numPredators;
    public int numObstacles;
    public GameObject[] objs;
    public Cell [,] cells = new Cell[CurrentRows,CurrentCols];
   
    public bool [,] wasInProcess = new bool[CurrentRows, CurrentCols];
    public Ocean(GameObject [] obj) {
        objs = obj;
        initialize();
    }
    public void initialize() {
        numRows = CurrentRows;
        numCols = CurrentCols;
        size = numCols * numRows;
        numObstacles = CurrentObstacles;
        numPredators = CurrentPredator;
        numPrey = CurrentPrey;
        initCells();
    }
    private void initCells(){
        /////////////////////////////////////////////////////////////////ТУТ ВВОД ИЗ КОНСТАНТ КОТОРЫЕ ВЫСТАВЛЯТЬ В ПРОГРАМЕ
        addEmtyCells();
        //setNumObstacles(DefaultNumObstacles);
        //setNumPredators(DefaultNumPredators);
        //setNumPrey(DefaultNumPrey);
        //addObstacles();                                                ПОКА НЕ НУЖНЫ
        addPredators();
        addPrey();
        /*OceanViewer.displayStats(this, -1);
        OceanViewer.displayBorder(numCols);
        OceanViewer.displayCells(this);
        OceanViewer.displayBorder(numCols);
        */
    }
    public void setNumIterations(int numIt) {
        numIterations = numIt;
    }
    public void setNumRows(int numRows) {
        this.numRows = numRows;
    }
    public void setNumObstacles(int num){
        numObstacles = num;
    }
    public void setNumPrey(int num) {
        numPrey = num;
    }
    public void setNumPredators(int num) {
        numPredators = num;
    }
    public void setNumCols(int numCols) {
        this.numCols = numCols;
    }
    public void setCell(Cell cell, Coordinate aCoord) {
        cells[aCoord.getY(),aCoord.getX()] = cell;
    }
    public string getCellImage(int yCoord, int xCoord) {
        return cells[yCoord,xCoord].getImage();
    }
    public Cell getCell(int yCoord, int xCoord) {
        return cells[yCoord,xCoord];
    }
    private Coordinate getEmptyCellCoord() {
        int x, y;
        Coordinate empty;
        do {
            x = (int)UnityEngine.Random.Range(0, numCols - 1);
            y = (int)UnityEngine.Random.Range(0, numRows - 1);
        } while (cells[y,x].getImage() != DefaultImage);
        empty = cells[y,x].getOffset();
        //finalize                                                                  на будещее поменять
        return empty;
    }
    public int getNumIterations(){return numIterations;}
    public int getNumObstacles(){
        return numObstacles;
    }
    public int getNumPrey() {
        return numPrey;
    }
    public int getNumPredator() {
        return numPredators;
    }
    public int getNumRows(){
        return numRows;
    }
    public int getNumCols(){
        return numCols;
    }
    private void addEmtyCells() {
        for (int row = 0; row < numRows; row++) {
            for (int col = 0; col < numCols; col++) {
                cells[row,col] = new EmptyCell(new Coordinate(col, row), this);               // В координате переменные перевернуты посмотреть
            }
        }
    }
    private void addObstacles() {
        Coordinate empty;
        for (int count = 0; count < numObstacles; count++) {
            empty = getEmptyCellCoord();
            cells[empty.getY(),empty.getX()] = new Obstacle(empty, this);
        }
    }
    private void addPredators() {
        Coordinate empty;
        for (int count = 0; count < numPredators; count++) {
            empty = getEmptyCellCoord();
            cells[empty.getY(),empty.getX()] = new Predator(empty, this);
        }
    }
    private void addPrey() {
        Coordinate empty;
        for (int count = 0; count < numPrey; count++) {
            empty = getEmptyCellCoord();
            cells[empty.getY(),empty.getX()] = new Prey(empty, this);
        }
    }
    /*public void workMetod(){
        //OceanWindow OW = new OceanWindow();

        setNumIterations(OceanViewer.enterIterations());
        OceanViewer.startSim(numIterations);
        for (int iter = 0; iter < numIterations; iter++) {
            if (numPredators > 0 && numPrey > 0) {
                for (int row = 0; row < numRows; row++) {
                    for (int col = 0; col < numCols; col++) {
                        if (!wasInProcess[row,col]) {
                            Cell workCell = cells[row,col];
                            cells[row,col].process();
                            Coordinate workCoord = workCell.getOffset();
                            wasInProcess[workCoord.getY(),workCoord.getX()] = true;
                        }
                    }
                }
                for (int row = 0; row < numRows; row++) {
                    for (int col = 0; col < numCols; col++) {
                        wasInProcess[row,col] = false;
                    }
                }
                //OW.OneIterationOutput(this);
                OceanViewer.displayStats(this, iter);
                OceanViewer.displayBorder(numCols);
                OceanViewer.displayCells(this);
                OceanViewer.displayBorder(numCols);
                Thread.sleep(NumBetweenIterations);
            }

        }
        OceanViewer.endSim();
    }*/
}