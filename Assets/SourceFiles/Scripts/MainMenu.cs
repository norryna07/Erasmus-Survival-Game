using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using ErasmusGame.Models;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject exitPanel;
    public Button resumeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    public void ResumeGame()
    {
        string path = Path.Combine(
            Application.persistentDataPath,
            "SaveData",
            "GameInformation.json"
        );

        if (!File.Exists(path))
        {
            resumeButton.interactable = false;
            resumeButton.GetComponentInChildren<TextMeshProUGUI>().text = "No game";
            return;
        } 
        string json = File.ReadAllText(path);
        GameInformation data = JsonUtility.FromJson<GameInformation>(json);
        SceneManager.LoadScene(data.currentScene);
    }

    public void ClearPersistentData()
{
    string path = Path.Combine( 
        Application.persistentDataPath,
        "SaveData");

    if (Directory.Exists(path))
    {
        Directory.Delete(path, true);
        Directory.CreateDirectory(path);
    }
    else
            Directory.CreateDirectory(path);

        Debug.Log("Clear data");
}
}
