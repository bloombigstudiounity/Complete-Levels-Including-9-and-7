using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLiftTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lift"))
        {
            PlayerController.Instance.stopMovement = true;
        }
    }
}
