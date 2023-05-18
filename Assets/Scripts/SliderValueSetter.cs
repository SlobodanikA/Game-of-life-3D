using UnityEngine;
using UnityEngine.UI;
using static GameData;

public class SliderValueSetter : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        if (slider != null)
        {
            slider.value = CurrentPrey;
            slider.minValue = MinNumPrey;
            slider.maxValue = MaxNumPrey;
        }
        else
        {
            Debug.LogError("Slider reference is not set!");
        }
    }

    public void OnSliderValueChanged(float value)
    {
        CurrentPrey = Mathf.RoundToInt(Mathf.Lerp(MinNumPrey, MaxNumPrey, value));
    }
}