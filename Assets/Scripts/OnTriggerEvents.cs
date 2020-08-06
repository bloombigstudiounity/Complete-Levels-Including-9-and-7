//Scripted by: Saliha Bilal

using UnityEngine;
using UnityEngine.Events;
public class OnTriggerEvents : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    public UnityEvent onTriggerStay;
    public bool layerBased = true, PlayerComponentOnly = false;
    public int layer = 8;
    void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter"+other.name);
        if (layerBased && other.gameObject.layer == layer)
        {
            if (!PlayerComponentOnly) onTriggerEnter.Invoke();
            else { if (other.gameObject.GetComponent<Invector.vCharacterController.vThirdPersonController>()) onTriggerEnter.Invoke(); }
        }
        else if (!layerBased && other.gameObject.layer != layer) onTriggerEnter.Invoke();
    }
    void OnTriggerExit(Collider other)
    {
        if (layerBased && other.gameObject.layer == layer)
        {
            if (!PlayerComponentOnly) onTriggerExit.Invoke();
            else { if (other.gameObject.GetComponent<Invector.vCharacterController.vThirdPersonController>()) onTriggerExit.Invoke(); }
        }
        else if (!layerBased && other.gameObject.layer != layer) onTriggerExit.Invoke();
    }
    void OnTriggerStay(Collider other)
    {
        if (layerBased && other.gameObject.layer == layer)
        {
            if (!PlayerComponentOnly) onTriggerStay.Invoke();
            else { if (other.gameObject.GetComponent<Invector.vCharacterController.vThirdPersonController>()) onTriggerStay.Invoke(); }
        }
        else if (!layerBased && other.gameObject.layer != layer) onTriggerStay.Invoke();
    }
}
