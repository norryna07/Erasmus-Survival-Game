using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UniPointsBar : MonoBehaviour
{
    private Slider slider;
    public TMP_Text uniPointsText;
    public GameObject gameStatus;

    private int currentUniPoints, minUniPoints, maxUniPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentUniPoints = gameStatus.GetComponent<GameStatus>().currentUniPoints;
        maxUniPoints = gameStatus.GetComponent<GameStatus>().maxUniPoints;
        minUniPoints = gameStatus.GetComponent<GameStatus>().minUniPoints;

        float fillValue = 100.0f * currentUniPoints / (maxUniPoints - minUniPoints);
        slider.value = fillValue;

        uniPointsText.text = currentUniPoints + "/" + maxUniPoints;
    }
}
