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
        dayText.text = "Day " + gameStatus.GetComponent<GameStatus>().day + " " + gameStatus.GetComponent<GameStatus>().GetTimeString();
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
        gameStatus.GetComponent<GameStatus>().SaveData("BeforeScene");

        Application.Quit();
    }
}
