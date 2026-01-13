using TMPro;
using UnityEngine;
using ErasmusGame.Models;
using System.IO;
using StarterAssets;
using UnityEngine.UI;
using System.Collections;

public class BeforeSceneUI : MonoBehaviour
{
    private GameStatus gameStatus;
    public TMP_Text dayText;

    public Button saveButton;

    public StarterAssetsInputs input;

    public GameObject ToDoPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        dayText.text = "Day " + gameStatus.day + " " + gameStatus.GetTimeString();
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
        gameStatus.SaveData("BeforeScene");
        TasksSystem.Instance.SaveData();

        Application.Quit();
    }

    public void OpenToDoList()
    {
        ToDoPanel.SetActive(true);
    }

    public void CloseToDoList()
    {
        ToDoPanel.SetActive(false);
    }
}
