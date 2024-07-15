using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public GameObject playButton;
    public GameObject selectLevelText;
    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;
    public GameObject level4Button;
    public GameObject level5Button;
    public GameObject level6Button;
    public GameObject backButton;

    private void Start()
    {
        ActivateLevelState(false);
    }

    public void OnPlayClick()
    {
        ActivateLevelState(true);
    }

    public void OnBackClick()
    {
        ActivateLevelState(false);
    }

    public void OnLevelClick(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }

    public void ActivateLevelState(bool activate)
    {
        playButton.SetActive(!activate);
        selectLevelText.SetActive(activate);
        level1Button.SetActive(activate);
        level2Button.SetActive(activate);
        level3Button.SetActive(activate);
        level4Button.SetActive(activate);
        level5Button.SetActive(activate);
        level6Button.SetActive(activate);
        backButton.SetActive(activate);
    }
}
