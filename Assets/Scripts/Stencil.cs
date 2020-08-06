using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stencil : MonoBehaviour
{
    public bool IsCurrentGrid = false;
    public float WaitTime = 5f;
    public float timer = 0f;
    public float removeTimer = 0f;

    public enum StencilState {
        idle,
        applied,
        removed
    };
    public StencilState stencilState = StencilState.idle;
    private void Start()
    {
        stencilState = StencilState.idle;
    }
    private void Update()
    {
        if (timer >= WaitTime && stencilState == StencilState.idle)
        {
            CancelInvoke("ApplyStencilAfterTime");
            stencilState = StencilState.applied;

        }
        if (removeTimer >= WaitTime && stencilState == StencilState.applied)
        {
            CancelInvoke("RemoveStencilAfterTime"); stencilState = StencilState.removed;

        }
    }
    public void ApplyStencil()
    {
        InvokeRepeating("ApplyStencilAfterTime", 0f, 1f);
    }
    public void  ApplyStencilAfterTime()
    {
//        yield return new WaitForSeconds(1f);
        ApplyStencils.Instance.applyingStencilTime.text = ""+(WaitTime - timer);
        timer++;
        if (timer >= WaitTime)
        {
            this.GetComponent<MeshRenderer>().enabled = true;

        }
    }
    public void RemoveStencil()
    {
        InvokeRepeating("RemoveStencilAfterTime", 0f, 1f);

    }
    public void RemoveStencilAfterTime()
    {
        //        yield return new WaitForSeconds(1f);
        ApplyStencils.Instance.applyingStencilTime.text = "" + (WaitTime - removeTimer);
        removeTimer++;
        if (removeTimer >= WaitTime)
        {
            this.GetComponent<MeshRenderer>().enabled = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("other.name: "+other.name);
        if(other.CompareTag("Player"))
            IsCurrentGrid = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        IsCurrentGrid = false;
    }
}
