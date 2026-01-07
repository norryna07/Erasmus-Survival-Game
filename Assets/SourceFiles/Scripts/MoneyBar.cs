using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text moneyText;
    public GameObject gameStatus;

    private int currentMoney, minMoney, maxMoney;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney = gameStatus.GetComponent<GameStatus>().currentMoney;
        maxMoney = gameStatus.GetComponent<GameStatus>().maxMoney;
        minMoney = gameStatus.GetComponent<GameStatus>().minMoney;

        float fillValue = 100.0f * currentMoney / (maxMoney - minMoney);
        slider.value = fillValue;

        moneyText.text = currentMoney + "/" + maxMoney;
    }
}
