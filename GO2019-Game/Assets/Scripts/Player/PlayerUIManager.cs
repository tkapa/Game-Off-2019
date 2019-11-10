using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{

    [Header("Health Bar")]
    public Slider playerHealthBar;
    public float playerHealth;
    public float playerHealthMax;
    public float playerHealthMin;

    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthBar.maxValue = playerHealthMax;
        playerHealthBar.minValue = playerHealthMin;
        playerHealth = playerHealthMax;
        playerHealthBar.value = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void TakeHealing(float healing)
    {
        playerHealth += healing;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        playerHealthBar.value = playerHealth;
        StartCoroutine(ScreenShakeing(0.1f, 0.05f));
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ScreenShakeing(float duration, float magnitude)
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
