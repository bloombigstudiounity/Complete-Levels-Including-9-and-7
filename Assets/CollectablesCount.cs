using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesCount : MonoBehaviour
{
    public static int CollectableCount = 0;
    public GameObject Endpoint;
    // Start is called before the first frame update
    void Start()
    {
        Endpoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CollectableCount == 6)
        {
            ShowEnd();
        }
    }
    public void ShowEnd()
    {
        Endpoint.SetActive(true);
    }
}
