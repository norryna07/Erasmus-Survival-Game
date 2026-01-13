using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus Instance { get; private set;}
    public int day;
    
    // ---- Health -----
    public int maxHealth;
    public int minHealth;
    public int currentHealth;

    // ----- Money -----
    public int maxMoney;
    public int minMoney;
    public int currentMoney;

    // ---- Happiness ----
    public int maxHappiness;
    public int minHappiness;
    public int currentHappiness;

    // ---- University Points -----
    public int maxUniPoints;
    public int minUniPoints;
    public int currentUniPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
