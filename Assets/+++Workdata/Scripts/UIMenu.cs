using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonExitGame;
    [SerializeField] private Button buttonLevelSelection;
    
    [SerializeField] private CanvasGroup panelLevelSelection;
    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    
    [SerializeField] private string[] levelNames;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowMainPanel();

        buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
        buttonNewGame.onClick.AddListener(LoadLevel1);
        buttonExitGame.onClick.AddListener(ExitGame);
        
        buttonBackToMain.onClick.AddListener(ShowMainPanel);
        buttonLevel1.onClick.AddListener(LoadLevel1);

        buttonLevel2.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[1]))
        {
            if (PlayerPrefs.GetInt(levelNames[1]) == 1)
            {
                buttonLevel2.interactable = true;
            }
        }
    }

    void ShowLevelSelection()
    {
        panelMain.alpha = 0f;
        panelMain.interactable = false;
        panelMain.blocksRaycasts = false;

        panelLevelSelection.alpha = 1f;
        panelLevelSelection.interactable = true;
        panelLevelSelection.blocksRaycasts = true;
    }
    
    void ShowMainPanel()
    {
        panelMain.alpha = 1f;
        panelMain.interactable = true;
        panelMain.blocksRaycasts = true;

        panelLevelSelection.alpha = 0f;
        panelLevelSelection.interactable = false;
        panelLevelSelection.blocksRaycasts = false;
    }

    void LoadLevel1()
    {
        SceneManager.LoadScene(levelNames[0]);
    }

    void ExitGame()
    {
        Application.Quit();
    }

}
