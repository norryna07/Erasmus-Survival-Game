using TMPro;
using UnityEngine;
using ErasmusGame.Models;
using System.IO;
using StarterAssets;
using UnityEngine.UI;

public class BeforeSceneUI : MonoBehaviour
{
    public GameObject gameStatus;
    public TMP_Text dayText;

    public Button saveButton;

    public StarterAssetsInputs input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dayText.text = "Day" + gameStatus.GetComponent<GameStatus>().day;
        if (input.escape && input.cursorInputForLook)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            input.cursorInputForLook = false;
            input.escape = false;
        }
        if (input.escape && !input.cursorInputForLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            input.cursorInputForLook = true;
            input.escape = false;
        }
    }

    public void SaveAndExit()
    {
        GameInformation gameInformation = new GameInformation
        {
            maxHappiness = gameStatus.GetComponent<GameStatus>().maxHappiness,
            minHappiness = gameStatus.GetComponent<GameStatus>().minHappiness,
            currentHappiness = gameStatus.GetComponent<GameStatus>().currentHappiness,
            maxMoney = gameStatus.GetComponent<GameStatus>().maxMoney,
            minMoney = gameStatus.GetComponent<GameStatus>().minMoney,
            currentMoney = gameStatus.GetComponent<GameStatus>().currentMoney,
            maxHealth = gameStatus.GetComponent<GameStatus>().maxHealth,
            minHealth = gameStatus.GetComponent<GameStatus>().minHealth,
            currentHealth = gameStatus.GetComponent<GameStatus>().currentHealth,
            maxUniPoints = gameStatus.GetComponent<GameStatus>().maxUniPoints,
            minUniPoints = gameStatus.GetComponent<GameStatus>().minUniPoints,
            currentUniPoints = gameStatus.GetComponent<GameStatus>().currentUniPoints,
            currentScene = "BeforeScene"
        };

        string json = JsonUtility.ToJson(gameInformation, true);

        string path = Path.Combine(
            Application.persistentDataPath,
            "GameInformation.json"
        );

        File.WriteAllText(path, json);

        Debug.Log("Game status save to: " + path);

        Application.Quit();
    }
}
