using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI killtxt;

    private int killed;

    public void AddXpToSlider(int xpToAdd)
    {
        slider.value += xpToAdd;
    }

    public void UpdateSlider(float value)
    {
        slider.maxValue = value;
    }

    public void AddKilled(int val)
    {
        killed += val;  
        killtxt.text = ": " + killed.ToString();    
    }
    
    
}
