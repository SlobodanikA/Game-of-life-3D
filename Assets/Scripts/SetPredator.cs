using UnityEngine;
using UnityEngine.UI;
using static GameData;

public class SetPredator : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
       
        if (slider != null)
        {
            slider.minValue = MinNumPredator;
            slider.maxValue = MaxNumPredator;
            slider.value = CurrentPredator;
        }
        else
        {
            Debug.LogError("Slider reference is not set!");
        }
    }
}