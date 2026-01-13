using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniPointsBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text uniPointsText;
    public GameStatus gameStatus;

    private int currentUniPoints, minUniPoints, maxUniPoints;
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
        currentUniPoints = gameStatus.currentUniPoints;
        maxUniPoints = gameStatus.maxUniPoints;
        minUniPoints = gameStatus.minUniPoints;

        float fillValue = 100.0f * (currentUniPoints * minUniPoints) / (maxUniPoints - minUniPoints);
        slider.value = fillValue;

        uniPointsText.text = currentUniPoints + "/" + maxUniPoints;
    }
}
