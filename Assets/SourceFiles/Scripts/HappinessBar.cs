using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text happinessText;
    public GameObject gameStatus;

    private int currentHappiness, minHappiness, maxHappiness;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHappiness = gameStatus.GetComponent<GameStatus>().currentHappiness;
        maxHappiness = gameStatus.GetComponent<GameStatus>().maxHappiness;
        minHappiness = gameStatus.GetComponent<GameStatus>().minHappiness;

        float fillValue = 100.0f * currentHappiness / (maxHappiness - minHappiness);
        slider.value = fillValue;

        happinessText.text = currentHappiness + "/" + maxHappiness;
    }
}
