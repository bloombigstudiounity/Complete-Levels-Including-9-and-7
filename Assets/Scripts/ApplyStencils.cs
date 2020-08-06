using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ApplyStencils : MonoBehaviour
{
    public Stencil[] stencilTriggers;
    public  int appliedStencilsCount = 0;
    public  int removedStencilsCount = 0;
    public TextMeshProUGUI applyingStencilTime;
    public enum AllStencilState {
        applying,
        removing
    }
    public AllStencilState allStencilState;
    private static  ApplyStencils instance;

    public static ApplyStencils Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private void Start()
    {
        instance = this;
        DisableAllStencils();
        allStencilState = AllStencilState.applying;

    }
    public void DisableAllStencils()
    {
        for (int i = 0; i < stencilTriggers.Length; i++)
        {
            stencilTriggers[i].GetComponent<MeshRenderer>().enabled=false;
        }
    }
    public void ApplyTriggeredStencil()
    {
        for (int i = 0; i < stencilTriggers.Length; i++)
        {
  
            if (stencilTriggers[i].IsCurrentGrid)
            {
                if (stencilTriggers[i].stencilState == Stencil.StencilState.idle)
                {
                    stencilTriggers[i].ApplyStencil();
                    appliedStencilsCount++;
                    break;
                }
            }

        }
        if (appliedStencilsCount >= stencilTriggers.Length)
        {
            allStencilState = AllStencilState.removing;
        }
    }
    public void RemoveTriggeredStencil()
    {
        for (int i = 0; i < stencilTriggers.Length; i++)
        {
            if (stencilTriggers[i].IsCurrentGrid)
            {
                if (stencilTriggers[i].stencilState == Stencil.StencilState.applied)
                {
                    stencilTriggers[i].RemoveStencil();
                    removedStencilsCount++;
                    break;
                }
            }
        }

    }
}
