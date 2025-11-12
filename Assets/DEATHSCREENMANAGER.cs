using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DEATHSCREENMANAGER : MonoBehaviour
{
    [SerializeField] private Button restartButton; 
    [SerializeField] private Button mainMenuButton; 
    [SerializeField] private Button quitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(MainMenu);
        quitButton.onClick.AddListener(Quit);
    }

    private void Restart()
    {
        SceneManager.LoadScene("Develop");
    }
    
    private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Quit()
    {
        Application.Quit(); 
    }
}
