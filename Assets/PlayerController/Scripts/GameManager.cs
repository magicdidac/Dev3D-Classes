using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [SerializeField] public UIController uiController = null;
    [HideInInspector] public FPSController player = null;
    [HideInInspector] public Checkpoint checkpoint = null;
    [HideInInspector] private Vector3 playerInitialPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

        playerInitialPos = player.transform.position;

    }

}
