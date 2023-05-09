using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class OceanScripts : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject[,] mass;
    Ocean myOcean;
    public void spawn()
    {
        myOcean = new Ocean(objs);

    }
    public IEnumerator work() {
    for (int iter = 0; iter < 1000; iter++) {
        Debug.Log(iter);
        if (myOcean.numPredators > 0 && myOcean.numPrey > 0) {
            for (int row = 0; row < myOcean.numRows; row++) {
                for (int col = 0; col < myOcean.numCols; col++) {
                  
                    if (!myOcean.wasInProcess[row,col]) {
                        
                        Cell workCell = myOcean.cells[row,col];
                        myOcean.cells[row,col].process();
                        Coordinate workCoord = workCell.getOffset();
                        myOcean.wasInProcess[workCoord.getY(),workCoord.getX()] = true;
                    }
                }
            }
            for (int row = 0; row < myOcean.numRows; row++) {
                for (int col = 0; col < myOcean.numCols; col++) {
                    myOcean.wasInProcess[row,col] = false;
                }
            }
            yield return new WaitForSeconds(2);
        }

    }
}
}
