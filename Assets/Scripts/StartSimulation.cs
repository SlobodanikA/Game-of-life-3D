using System.Collections;
using UnityEngine;


public class StartSimulation : MonoBehaviour
{
    public GameObject otherObject;
    private void Awake()
    {
        Time.timeScale = 0f;
        otherObject.GetComponent<OceanScripts>().spawn();
        otherObject.GetComponent<OceanScripts>().startWork();
    }
}