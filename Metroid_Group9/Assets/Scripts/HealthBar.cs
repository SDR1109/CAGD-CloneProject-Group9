using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Name: Maya Andrade
 * Date: 04/11/25
 * Last Updated: 04/11/25
 * Description: Gives the health bar for the player functionality (marking it's health)
 */

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TMP_Text healthPoint_Text;
    public Player playerScript;

    private void Start()
    {
        SetMaxHP();
    }

    private void Update()
    {
        SetHP();
    }
    /// <summary>
    /// Sets the maximum value of the health bar and makes it green (to show full health)
    /// </summary>
    public void SetMaxHP()
    {
        slider.maxValue = playerScript.maxHP;
        slider.value = playerScript.maxHP;
        fill.color = gradient.Evaluate(1F);
        healthPoint_Text.text = playerScript.healthPoints + "";
    }

    /// <summary>
    /// Keeps the slider updated so that it reflects the player's current HP value
    /// </summary>
    public void SetHP()
    {
        slider.value = playerScript.healthPoints;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        healthPoint_Text.text = playerScript.healthPoints + "";
    }
}
