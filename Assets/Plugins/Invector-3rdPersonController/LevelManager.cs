using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public int collectRollsInLevel = 10;
    public int collectTapeInLevel = 5;
    public int collectSprayInLevel = 0;
    public int collectFoodInLevel = 0;
    public static int currentFoodIndex = 0;

    public static int currentRollsIndex = 0;
    public static int currentTapeIndex = 0;
    public static int currentSprayIndex = 0;
    public int currentFoodInLevel = 0;
    private static LevelManager instance;
    public GameObject LevelCompleteTrigger;
    public static LevelManager Instance
    {
        get { return instance; }
        set { instance = value; }
    }
    private void Awake()
    {
        instance = this;

    }
    public bool IsLevelComplete()
    {
        if (currentRollsIndex >= collectRollsInLevel &&
            currentSprayIndex >= collectSprayInLevel &&
            currentTapeIndex >= collectTapeInLevel &&
            currentTapeIndex >= collectTapeInLevel)
        {
            return true;
        }
        else
            return false;
    }

    public void ShowLevelComplete()
    {
        print("LevelCOmplete");
        UIManager.Instance.completePanel.SetActive(true);
    }
}

