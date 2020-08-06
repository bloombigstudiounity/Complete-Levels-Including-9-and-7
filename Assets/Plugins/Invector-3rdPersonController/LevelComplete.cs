using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public void LevelCompleteEvent() { print("LevelComplete"); LevelManager.Instance.ShowLevelComplete(); }
   // public void ShowPause(bool show) { Invector.vGameController.instance.BtnPause.SetActive(show); }
}
