using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject gunInfoPanel = null;
    [SerializeField] private Text ammoText = null;

    public void SetAmoText(string message)
    {
        ammoText.text = message;
    }

    public void SetActiveGunInfo()
    {
        gunInfoPanel.SetActive(true);
    }


}
