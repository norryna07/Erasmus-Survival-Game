using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HappinessBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text happinessText;
    public GameStatus gameStatus;

    private int currentHappiness, minHappiness, maxHappiness;
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
        currentHappiness = gameStatus.currentHappiness;
        maxHappiness = gameStatus.maxHappiness;
        minHappiness = gameStatus.minHappiness;

        float fillValue = 100.0f * (currentHappiness - minHappiness) / (maxHappiness - minHappiness);
        slider.value = fillValue;

        happinessText.text = currentHappiness + "/" + maxHappiness;
    }
}
