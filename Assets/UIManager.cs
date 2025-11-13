using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void AddXpToSlider(int xpToAdd)
    {
        slider.value += xpToAdd;
    }

    public void UpdateSlider(float value)
    {
        slider.maxValue = value;
    }
}
