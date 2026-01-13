using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ErasmusGame.Models;
using System.IO;
using UnityEngine.SceneManagement;

public class LaptopSceneMenu : MonoBehaviour
{
    public Canvas CVCanvas;
    public Canvas OLACanvas;
    public Canvas TransportCanvas;
    public Canvas AccommodationCanvas;
    public Canvas MainCanvas;
    public Button CVButton, OLAButton, TransportButton, AccommodationButton;
    public GameStatus gameStatus;

    private LaptopInformation laptopInfo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadData();
        HideAllCanvases();
        UpdateButtons();
        gameStatus = GameStatus.Instance;
    }

    void OnEnable()
    {
        LoadData();
    }

    public void ButtonOnClick(Canvas canvas)
    {
        SaveData();
        HideAllCanvases();
        MainCanvas.GameObject().SetActive(false);
        canvas.GameObject().SetActive(true); 
    }

    public void MarkCVDone()
    {
        laptopInfo.CVDone = true;
        Debug.Log(laptopInfo.CVDone);
        UpdateButtons();
    }

    public void MarkOLADone()
    {
        laptopInfo.OLADone = true;
        UpdateButtons();
    }

    public void MarkTransportDone()
    {
        laptopInfo.transportDone = true;
        UpdateButtons();
    }

    public void MarkAccommodationDone()
    {
        laptopInfo.accommodationDone = true;
        UpdateButtons();
    }

    public void SetAccommodationName(string name)
    {
        laptopInfo.accommodationName = name;
    }

    void HideAllCanvases()
    {
        CVCanvas.GameObject().SetActive(false);
        OLACanvas.GameObject().SetActive(false);
        TransportCanvas.GameObject().SetActive(false);
        AccommodationCanvas.GameObject().SetActive(false);
    }

    void UpdateButtons()
    {
        CVButton.interactable = true;
        OLAButton.interactable = laptopInfo.CVDone;
        TransportButton.interactable = laptopInfo.OLADone;
        AccommodationButton.interactable = laptopInfo.transportDone;
    }

    private void LoadData()
    {
        if (laptopInfo != null) return;
        string path = Path.Combine(
            Application.persistentDataPath,
            "LaptopInformation.json"
        );
        string json;
        Debug.Log("load data");
        if (!File.Exists(path))
        {
            laptopInfo = new LaptopInformation();
            json = JsonUtility.ToJson(laptopInfo, true);
            File.WriteAllText(path, json);
            return;
        }

        json = File.ReadAllText(path);
        laptopInfo = JsonUtility.FromJson<LaptopInformation>(json);
    }

    void SaveData()
    {
        string path = Path.Combine(
            Application.persistentDataPath,
            "LaptopInformation.json"
        );
        string json = JsonUtility.ToJson(laptopInfo, true);
        File.WriteAllText(path, json);
        Debug.Log("Laptop Information saved at: " + path);
    }

    public void SaveAndExit()
    {
        gameStatus.SaveData("BeforeScene");
        SaveData();
        SceneManager.LoadScene("BeforeScene");
    }
}
