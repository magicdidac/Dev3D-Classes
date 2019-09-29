using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [SerializeField] public UIController uiController = null;

    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

    }

}
