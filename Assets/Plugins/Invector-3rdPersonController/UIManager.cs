using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Text collectSprayCountText;
    public Text collectFoodCountText;
    public Text collectRollCountText;
    public Text collectTapeCountText;
    private static UIManager instance;
    public GameObject completePanel;
    public GameObject levelDescriptionPanel;

    public static UIManager Instance
    {
        get { return instance; }
        set { instance = value; }
    }
    private void Start()
    {
        instance = this;
        UpdateUI();
        levelDescriptionPanel.SetActive(true);
        Invoke("HideLevelDescription", 3f);
    }
    public void UpdateUI()
    {
        if(LevelManager.Instance.collectRollsInLevel >= LevelManager.currentRollsIndex)
            collectRollCountText.text = "" + (LevelManager.Instance.collectRollsInLevel - LevelManager.currentRollsIndex);
        if (LevelManager.Instance.collectSprayInLevel >= LevelManager.currentSprayIndex)
            collectSprayCountText.text = "" + (LevelManager.Instance.collectSprayInLevel - LevelManager.currentSprayIndex);
        if (LevelManager.Instance.collectTapeInLevel >= LevelManager.currentTapeIndex)
            collectTapeCountText.text = "" + (LevelManager.Instance.collectTapeInLevel - LevelManager.currentTapeIndex);
        if (LevelManager.Instance.collectFoodInLevel >= LevelManager.currentFoodIndex)
            collectFoodCountText.text = "" + (LevelManager.Instance.collectFoodInLevel - LevelManager.currentFoodIndex);
    }
    public void HideLevelDescription()
    {
        levelDescriptionPanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
