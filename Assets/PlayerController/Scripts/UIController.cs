using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject gunInfoPanel = null;
    [SerializeField] private Text ammoText = null;

    [SerializeField] private Slider healthSlider = null;
    [SerializeField] private Text healthText = null;

    [SerializeField] private Slider shieldSlider = null;
    [SerializeField] private Text shieldText = null;


    public void SetAmoText(string message)
    {
        ammoText.text = message;
    }

    public void SetActiveGunInfo()
    {
        gunInfoPanel.SetActive(true);
    }

    public void SetHealth(int amount)
    {
        healthText.text = "" + amount;
        healthSlider.value = (amount + 0.0f) / 100;
    }

    public void SetShield(int amount)
    {
        shieldText.text = "" + amount;
        shieldSlider.value = (amount+0.0f) / 100;
    }

}
