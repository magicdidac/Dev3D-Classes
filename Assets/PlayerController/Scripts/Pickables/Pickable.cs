using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    protected void Start()
    {

        this.tag = "Pickable";
        
    }

    public abstract void GetPickable(FPSController player);

}
