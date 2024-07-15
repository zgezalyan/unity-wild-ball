using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{

    public GameObject pauseGreyImage;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject exitButton;
    public GameObject nextLevelButton;
    public GameObject levelNameText;
    public GameObject statusInstructionText;
    public GameObject timeText;

    private Text levelNameTextComponent;
    private Text statusInstructionTextComponent;
    private Text timeTextComponent;
    private bool isPaused;    
    
    private void Awake()
    {
        levelNameTextComponent = levelNameText.GetComponent<Text>();
        statusInstructionTextComponent = statusInstructionText.GetComponent<Text>();
        timeTextComponent = timeText.GetComponent<Text>();
        isPaused = false;        
        
        ActivatePause(false);
    }

    public void OnPauseClick()
    {
        ActivatePause(true);
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnResumeClick()
    {
        ActivatePause(false);
    }

    public void OnNextLevelClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ActivatePause(bool activate)
    {
        levelNameTextComponent.color = Color.white;
        statusInstructionTextComponent.color = Color.white;

        pauseButton.SetActive(!activate);
        pauseGreyImage.SetActive(activate);
        resumeButton.SetActive(activate);
        restartButton.SetActive(activate);
        exitButton.SetActive(activate);
        nextLevelButton.SetActive(false);
        levelNameText.SetActive(false);
        statusInstructionText.SetActive(false);
        timeText.SetActive(false);

        isPaused = activate;        
    }

    public void ActivateWin(string levelName, float levelTime, bool isLastLevel)
    {
        float minutes = Mathf.Floor(levelTime / 60);
        float seconds = Mathf.RoundToInt(levelTime % 60);
        string strSeconds;

        if (seconds < 10)        
            strSeconds = "0" + Mathf.RoundToInt(seconds).ToString();        
        else
            strSeconds = Mathf.RoundToInt(seconds).ToString();

        levelNameTextComponent.color = Color.white;
        statusInstructionTextComponent.color = Color.white;

        pauseButton.SetActive(false);
        pauseGreyImage.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(isLastLevel);
        nextLevelButton.SetActive(!isLastLevel);
        levelNameText.SetActive(true);
        statusInstructionText.SetActive(true);
        timeText.SetActive(true);

        levelNameTextComponent.text = levelName;
        statusInstructionTextComponent.text = "WELL DONE!";
        timeTextComponent.text = "TIME " + minutes.ToString() + ":" + strSeconds;
    }

    public void ActivateLost(string levelName)
    {
        levelNameTextComponent.color = Color.white;
        statusInstructionTextComponent.color = Color.white;

        pauseButton.SetActive(false);
        pauseGreyImage.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        nextLevelButton.SetActive(false);
        levelNameText.SetActive(false);
        statusInstructionText.SetActive(true);
        timeText.SetActive(false);

        levelNameTextComponent.text = levelName;
        statusInstructionTextComponent.text = "TRY AGAIN!";        
    }

    public void ShowWelcomeInfo(string levelName, string levelInfo)
    {

        levelNameTextComponent.color = Color.black;
        statusInstructionTextComponent.color = Color.black;


        levelNameText.SetActive(true);
        statusInstructionText.SetActive(true);

        levelNameTextComponent.text = levelName;
        statusInstructionTextComponent.text = levelInfo;
        
    }

    public void HideWelcomeInfo()
    {
        levelNameTextComponent.color = Color.white;
        statusInstructionTextComponent.color = Color.white;

        levelNameText.SetActive(false);
        statusInstructionText.SetActive(false);
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }

    public void ShowHint(string hint)
    {
        statusInstructionTextComponent.color = Color.black;
        statusInstructionText.SetActive(true);
        statusInstructionTextComponent.text = hint;
    }

    public void HideHint()
    {
        statusInstructionTextComponent.color = Color.white;
        statusInstructionText.SetActive(false);
    }
    
}
