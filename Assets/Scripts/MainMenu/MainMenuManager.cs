using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button playButton;
    [SerializeField] private Button TutorialButton;
    [SerializeField] private Transform TutTransform;
    [SerializeField] private Button exitButton;

    [SerializeField] private Transform tutorialTextParent;
    [SerializeField] private Transform MainMenuHolder;

    private bool lerpButtons= false;
    private Vector3 menuInitial;
    private Vector3 buttonInitial;  

    private void Start()
    {
        playButton.onClick.AddListener(StartGame);
        TutorialButton.onClick.AddListener(ShowTutorialText);
        exitButton.onClick.AddListener(QuitGame);

        menuInitial = MainMenuHolder.transform.position;
        buttonInitial = TutTransform.transform.position;

    }
    
    private void StartGame()
    {
        SceneManager.LoadScene("Develop");
    }

    private void Update()
    {
        if (lerpButtons)
        {
            Vector3 UpTarget = menuInitial + Vector3.up * 1100f;
            MainMenuHolder.transform.position = Vector3.Lerp(MainMenuHolder.transform.position, UpTarget, 10f * Time.deltaTime);
            Vector3 LeftTarget = buttonInitial + Vector3.left * 700f;
            TutTransform.transform.position = Vector3.Lerp(TutTransform.transform.position, LeftTarget, 10f * Time.deltaTime);

            TutTransform.GetComponentInChildren<TextMeshProUGUI>().text = "BACK";
        }
        else
        {
            MainMenuHolder.transform.position = Vector3.Lerp(MainMenuHolder.transform.position, menuInitial, 10f * Time.deltaTime);
            TutTransform.transform.position = Vector3.Lerp(TutTransform.transform.position, buttonInitial, 10f * Time.deltaTime);
            
            TutTransform.GetComponentInChildren<TextMeshProUGUI>().text = "TUTORIAL";
        }
    }

    private void ShowTutorialText()
    {
        lerpButtons = !lerpButtons;
        tutorialTextParent.gameObject.SetActive(lerpButtons);
    }


    

    private void QuitGame()
    {
        Application.Quit(); 
    }
    
}
