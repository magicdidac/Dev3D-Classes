using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [SerializeField] public UIController uiController = null;
    [HideInInspector] public FPSController player = null;
    [HideInInspector] public Checkpoint checkpoint = null;

    private void Awake()
    {
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Start()
    {
        uiController.ChangeFade();
    }

    public void Revive()
    {
        if(checkpoint == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }


        checkpoint.SetPlayerStats();
        
    }

}
