using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Checkpoint : MonoBehaviour
{
    [HideInInspector] private Renderer rend;
    [HideInInspector] private GameManager gm;

    [SerializeField] private Material offMaterial = null;
    [SerializeField] private Material onMaterial = null;

    private void Start()
    {
        this.tag = "Checkpoint";

        gm = GameManager.instance;

        rend = GetComponent<Renderer>();

        if (!Application.isEditor)
            rend.enabled = false;
    }

    public void EnableCheckpoint()
    {

        if (gm.checkpoint != null)
            gm.checkpoint.DisableCheckpoint();

        gm.checkpoint = this;

        if(Application.isEditor)
            rend.material = onMaterial;
    }

    public void DisableCheckpoint()
    {
        if (Application.isEditor)
            rend.material = offMaterial;
    }

}
