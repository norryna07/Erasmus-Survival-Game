using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text moneyText;
    public GameStatus gameStatus;

    private int currentMoney, minMoney, maxMoney;
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
        currentMoney = gameStatus.currentMoney;
        maxMoney = gameStatus.maxMoney;
        minMoney = gameStatus.minMoney;

        float fillValue = 100.0f * (currentMoney - minMoney) / (maxMoney - minMoney);
        slider.value = fillValue;

        moneyText.text = currentMoney + "/" + maxMoney;
    }
}
