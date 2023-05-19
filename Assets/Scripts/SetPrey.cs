using UnityEngine;
using UnityEngine.UI;
using static GameData;

public class SetPrey : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        
        if (slider != null)
        {
            
            slider.minValue = MinNumPrey;
            slider.maxValue = MaxNumPrey;
            slider.value = CurrentPrey;
        }
        else
        {
            Debug.LogError("Slider reference is not set!");
        }
    }
}