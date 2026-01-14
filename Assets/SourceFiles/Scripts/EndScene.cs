using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using ErasmusGame.Models;
using TMPro;

public class EndScene : MonoBehaviour
{
    public GameObject exitPanel;
    public TMP_Text messageText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        messageText.text = SceneMessage.message;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        exitPanel.SetActive(true);
    }

    public void ConfirmExit()
    {
        ClearPersistentData();
        Application.Quit();
    }

    public void CancelExit()
    {
        exitPanel.SetActive(false);
    }

    public void NewGame()
    {
        // move to second scene
        ClearPersistentData();
        SceneManager.LoadScene("CharacterSelection");
    }


    public void ClearPersistentData()
{
    string path = Application.persistentDataPath;

    if (Directory.Exists(path))
    {
        Directory.Delete(path, true);
        Directory.CreateDirectory(path);
    }

    Debug.Log("Clear data");
}
}
