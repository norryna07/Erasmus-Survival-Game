using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text healthText;
    public GameStatus gameStatus;

    private int currentHealth, minHealth, maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    IEnumerator Start()
    {
        // Wait until GameStatus is ready
        yield return new WaitUntil(() => GameStatus.Instance != null 
                                    && GameStatus.Instance.IsInitialized);
        gameStatus = GameStatus.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus == null) return;
        currentHealth = gameStatus.currentHealth;
        maxHealth = gameStatus.maxHealth;
        minHealth = gameStatus.minHealth;

        float fillValue = 100.0f * (currentHealth - minHealth) / (maxHealth - minHealth);
        slider.value = fillValue;

        healthText.text = currentHealth + "/" + maxHealth;
    }
}
