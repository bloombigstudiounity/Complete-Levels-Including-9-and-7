using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePoliceScript : MonoBehaviour
{
    public GameObject policeAI_parent;
    private void Start()
    {
        policeAI_parent.gameObject.SetActive(false);
    }
    private void OnEnable()
    {

        Timer.OnTimeFinishEvent += EnablePoliceAI;
    }
    public void EnablePoliceAI()
    {
        policeAI_parent.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        Timer.OnTimeFinishEvent -= EnablePoliceAI;
    }
}
