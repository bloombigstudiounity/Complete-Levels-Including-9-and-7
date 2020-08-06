using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElevatorEnterTrigger : MonoBehaviour
{
    public Animator _doorAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player Triggered Enter Cube");
            PlayerOpenDoorAnim();
            this.gameObject.SetActive(false);

        }
    }
    public void PlayerOpenDoorAnim()
    {
        _doorAnim.SetTrigger("open");
        print("Player Triggered Enter Cube");
    }
    public void PlayerCloseDoorAnim()
    {
        _doorAnim.SetTrigger("close");
    }

}
