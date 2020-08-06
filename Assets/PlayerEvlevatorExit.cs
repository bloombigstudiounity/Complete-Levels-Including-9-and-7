using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvlevatorExit : MonoBehaviour
{
    public Animator _doorAnim;
    public GameObject Ninja;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player Triggered Exit Cube");

            PlayerCloseDoorAnim();
            this.gameObject.SetActive(false);
        }
    }
    public void PlayerOpenDoorAnim()
    {

        _doorAnim.SetTrigger("open");
    }
    public void PlayerCloseDoorAnim()
    {
       // _doorAnim.SetTrigger("close");
        Ninja.transform.position = new Vector3(Ninja.transform.position.x, Ninja.transform.position.y - 16.5f, Ninja.transform.position.z);
    }
}
