using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerVitals : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
    public int healthFallRate;

    public Slider thirstSlider;
    public int maxThirst;
    public int thirstFallRate;

    public Slider hungerSlider;
    public int maxHunger;
    public int hungerFallRate;

    public Slider staminaSlider;
    public int maxStamina;
    private int staminaFallrate;
    public int staminaFallMult;
    private int staminaRegainRate;
    public int staminaRegainMult;

    [Header("Temperature Settings")]
    public float freezingTemp;
    public float currentTemp;
    public float normalTemp;
    public float heatTemp;
    public Text tempNumber;
    public Image tempBG;


    private CharacterController charController;
    private FirstPersonController playerController;

    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        thirstSlider.maxValue = maxThirst;
        thirstSlider.value = maxThirst;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;

        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

        staminaFallrate = 1;
        staminaRegainRate = 1;

        charController = GetComponent<CharacterController>();
        playerController = GetComponent<FirstPersonController>();
    }
    
    void UpdateTemp()
    {
        tempNumber.text = currentTemp.ToString("00.0");
    }

    void Update()
    {
        //Temperature
        if(currentTemp <= freezingTemp)
        {
            tempBG.color = Color.blue;
            UpdateTemp();
        }

        else if(currentTemp >= heatTemp - 0.1)
        {
            tempBG.color = Color.red;
            UpdateTemp();
        }

        else
        {
            tempBG.color = Color.green;
            UpdateTemp();
        }

        //HEALTH CONTROL SECTION
        if (hungerSlider.value <= 0 && (thirstSlider.value <= 0))
        {
            healthSlider.value -= Time.deltaTime / healthFallRate * 2;
        }

        else if (hungerSlider.value <= 0 || thirstSlider.value <= 0 || currentTemp <= freezingTemp || currentTemp >= heatTemp)
        {
            healthSlider.value -= Time.deltaTime / healthFallRate;
        }

        if (healthSlider.value <= 0)
        {
            CharacterDeath();
        }

        //HUNGER CONTROL SECTION
        if (hungerSlider.value >= 0)
        {
            hungerSlider.value -= Time.deltaTime / hungerFallRate;
        }

        else if (hungerSlider.value <= 0)
        {
            hungerSlider.value = 0;
        }

        else if (hungerSlider.value >= maxHunger)
        {
            hungerSlider.value = maxHunger;
        }

        //THIRST CONTROL SECTION
        if (thirstSlider.value >= 0)
        {
            thirstSlider.value -= Time.deltaTime / thirstFallRate;
        }

        else if (thirstSlider.value <= 0)
        {
            thirstSlider.value = 0;
        }

        else if (thirstSlider.value >= maxThirst)
        {
            thirstSlider.value = maxThirst;
        }

        //Stamina Control

        if(charController.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            staminaSlider.value -= Time.deltaTime / staminaFallrate * staminaFallMult;
            if(staminaSlider.value > 0)
            {
                currentTemp += Time.deltaTime / 5;
            }
        }

        else
        {
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;
            
            if(currentTemp >= normalTemp)
            {
                currentTemp -= Time.deltaTime / 10;
            }
        }

        if(staminaSlider.value >= maxStamina)
        {
            staminaSlider.value = maxStamina;
        }

        else if(staminaSlider.value <= 0)
        {
            staminaSlider.value = 0;
            playerController.m_RunSpeed = playerController.m_WalkSpeed;
        }

        else if(staminaSlider.value >= 0)
        {
            playerController.m_RunSpeed = playerController.m_RunSpeedNorm;
        }
    }

    void CharacterDeath()
    {
        //DEATH
    }
}
