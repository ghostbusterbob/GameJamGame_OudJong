using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private TextMeshProUGUI killedText;
    private int killed;


    private void Start()
    {
        updateUI();
    }

    public void addenemykill()
    {
        killed++;
        updateUI();
    }

    private void updateUI()
    {
        killedText.text = ": " +  killed.ToString();
    }
}
