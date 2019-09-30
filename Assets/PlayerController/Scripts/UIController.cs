using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject gunInfoPanel = null;
    [SerializeField] private Text ammoText = null;

    [SerializeField] private Image healthSlider = null;
    [SerializeField] private TMP_Text healthText = null;

    [SerializeField] private Image shieldSlider = null;
    [SerializeField] private TMP_Text shieldText = null;


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
        healthSlider.fillAmount = (amount + 0.0f) / 100;
    }

    public void SetShield(int amount)
    {
        shieldText.text = "" + amount;
        shieldSlider.fillAmount = (amount+0.0f) / 100;
    }

}
