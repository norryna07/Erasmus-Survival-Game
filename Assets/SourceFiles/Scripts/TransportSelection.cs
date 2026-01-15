using System.Reflection.Emit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ErasmusGame.Models;
using System.IO;
using System.Linq;
using UnityEngine.SocialPlatforms.Impl;
using TMPro.Examples;

public class TransportSelection : MonoBehaviour
{
    public Transform parent;
    public ToggleGroup group;
    public Toggle togglePrefab;
    private GameStatus gameStatus;
    public TMP_Text instructionText;
    public Canvas mainCanvas, transportCanvas;
    private TravelInfosJSON travelInfos;
    private PlayerProfile playerProfile;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadData();
        AddOptionOnScreen();
        gameStatus = GameStatus.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddToggle(string label, int price)
    {
        Toggle toggle = Instantiate(togglePrefab, parent);

        toggle.GetComponentInChildren<Text>().text = label;
        Variables.Object(toggle).Set("price", price);

        toggle.isOn = false;
        toggle.group = group;

        toggle.onValueChanged.AddListener(isOn =>
        {
            if (isOn)
                Debug.Log($"Selected: {label}");
        });
    }

    void LoadData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/travelInfo");
        if (jsonFile == null)
        {
            Debug.LogError("JSON file not found!");
            return;
        }

        string json = jsonFile.text;
        travelInfos = JsonUtility.FromJson<TravelInfosJSON>(json);

        // load player profile
        string path = Path.Combine(
            Application.persistentDataPath,
            "SaveData",
            "playerProfile.json"
        );

        string jsonProfile = File.ReadAllText(path);
        Debug.Log(jsonProfile);
        playerProfile = JsonUtility.FromJson<PlayerProfile>(jsonProfile);
    }

    void AddOptionOnScreen()
    {
        foreach (var travelInfo in travelInfos.travelInfos)
        {
            if (travelInfo.erasmusCountry.Equals(playerProfile.erasmusCountry) && 
                travelInfo.originCountry.Equals(playerProfile.homeCountry))
            {
                string label = travelInfo.method + " " + travelInfo.price + "€ " + travelInfo.timeHours + "h";
                AddToggle(label, travelInfo.price);
            }
        }

        instructionText.text = "Select how you want to go from " + playerProfile.homeCountry + " to " + playerProfile.erasmusCountry; 
    }

    public void ButtonClick()
    {
        Toggle selected = group.ActiveToggles().FirstOrDefault();
        Debug.Log(selected.GetComponentInChildren<Text>().text);
        int price = (int)Variables.Object(selected).Get("price");
        gameStatus.currentMoney -= price;
        Debug.Log(gameStatus.currentMoney);
        mainCanvas.GameObject().SetActive(true);
        mainCanvas.GetComponent<LaptopSceneMenu>().MarkTransportDone();
        transportCanvas.GameObject().SetActive(false);
        TasksSystem.Instance.UpdateTasks("laptop_transport");
    }
}
