using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject exitPanel;
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
        SceneManager.LoadScene("");
    }

    public void ResumeGame()
    {
        // load settings info
        // character info
        // status info
        // resume the game at the correct scene
    }
}
