using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] AudioSource audioSource;

    public AudioClip drinkingSound;

    [Header("Health Bar")]
    public Slider playerHealthBar;
    public float playerHealth;
    public float playerHealthMax;
    public GameObject deathUI = null;
    public TextMeshProUGUI deathText = null;
    public GameObject gameUI = null;
    public AudioClip damageSound;
    public AudioClip gameOverSound;
    
    [HideInInspector]
    public static bool isDead = false;

    [Header("Stamina Bar")]
    public Slider playerStamBar;
    public float playerStamina;
    public float playerStamMax;
    public float staminaLossRate;
    public float staminaGainRate;
    public AudioClip outOfStamSound;
   
    [Header("Camera Shake")]
    public GameObject playerCamera;
    public float duration;
    public float magnitude;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerHealthBar.maxValue = playerHealthMax;
        playerHealthBar.minValue = 0;
        playerHealth = playerHealthMax;
        playerHealthBar.value = playerHealth;
        playerStamBar.maxValue = playerStamMax;
        playerStamBar.minValue = 0;
        playerStamina = playerStamMax;
        playerStamBar.value = playerHealth;
    }

    public void TakeHealing(float healing)
    {
        playerHealth += healing;
        playerHealthBar.value = playerHealth;
        audioSource.PlayOneShot(drinkingSound, audioSource.volume);
        if(playerHealth > playerHealthMax)
            playerHealth = playerHealthMax;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        playerHealthBar.value = playerHealth;
        StartCoroutine(ScreenShakeing(duration, magnitude));
        audioSource.PlayOneShot(damageSound, audioSource.volume);

        if(playerHealth <= 0)
        {
            duration = 0;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<AudioSource>().enabled = false;
            audioSource.PlayOneShot(gameOverSound, audioSource.volume);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isDead = true;          
            deathText.text = "YOU SURVIVED " + GameManager.floorNumber + " FLOORS";
            deathUI.SetActive(true);
            gameUI.SetActive(false);
        }
    }

    public void LoseStamina()
    {
        playerStamina -= (20 * staminaLossRate) * Time.deltaTime;
        playerStamBar.value = playerStamina;
        if(playerStamina <= 0)
        {
            audioSource.PlayOneShot(outOfStamSound, audioSource.volume);
        }
    }

    public void GainStamina()
    {
        if(playerStamina < playerStamMax)
        {
            playerStamina += (20 * staminaGainRate) * Time.deltaTime;
            playerStamBar.value = playerStamina;
        }                
    }

    public void ReceiveStamina(float received)
    {
        playerStamina += received;
        playerStamBar.value = playerStamina;
        audioSource.PlayOneShot(drinkingSound, audioSource.volume);
        if(playerStamina > playerStamMax)
            playerStamina = playerStamMax;
    }

    

    IEnumerator ScreenShakeing(float dur, float mag)
    {
        Vector3 originalCamPos = Camera.main.transform.localPosition;

        float elapsed = 0.0f;    
        
        while (elapsed < duration) 
        { 
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            
            Camera.main.transform.localPosition = new Vector3(x, y, originalCamPos.z);

            elapsed += Time.deltaTime;    
            yield return null;        
        }
        
        Camera.main.transform.localPosition = originalCamPos;
    }
}
