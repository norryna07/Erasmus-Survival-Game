using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text healthText;
    public GameObject gameStatus;

    private int currentHealth, minHealth, maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = gameStatus.GetComponent<GameStatus>().currentHealth;
        maxHealth = gameStatus.GetComponent<GameStatus>().maxHealth;
        minHealth = gameStatus.GetComponent<GameStatus>().minHealth;

        float fillValue = 100.0f * currentHealth / (maxHealth - minHealth);
        slider.value = fillValue;

        healthText.text = currentHealth + "/" + maxHealth;
    }
}
