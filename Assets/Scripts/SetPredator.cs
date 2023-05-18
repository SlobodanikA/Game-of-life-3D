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
            slider.value = CurrentPredator;
            slider.minValue = MinNumPredator;
            slider.maxValue = MaxNumPredator;
        }
        else
        {
            Debug.LogError("Slider reference is not set!");
        }
    }
}