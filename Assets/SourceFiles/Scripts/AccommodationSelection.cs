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

public class AccommodationSelection : MonoBehaviour
{
    public Transform parent;
    public ToggleGroup group;
    public Toggle togglePrefab;
    public GameObject gameStatus;
    public TMP_Text instructionText;
    public Canvas mainCanvas, accommodationCanvas;
    private AccommodationsJSON accommodations;
    private PlayerProfile playerProfile;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadData();
        AddOptionOnScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddToggle(string label, int price, string name)
    {
        Toggle toggle = Instantiate(togglePrefab, parent);

        toggle.GetComponentInChildren<Text>().text = label;
        Variables.Object(toggle).Set("price", price);
        Variables.Object(toggle).Set("id", name);

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
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/accommodations");
        if (jsonFile == null)
        {
            Debug.LogError("JSON file not found!");
            return;
        }

        string json = jsonFile.text;
        accommodations = JsonUtility.FromJson<AccommodationsJSON>(json);

        // load player profile
        string path = Path.Combine(
            Application.persistentDataPath,
            "playerProfile.json"
        );

        string jsonProfile = File.ReadAllText(path);
        Debug.Log(jsonProfile);
        playerProfile = JsonUtility.FromJson<PlayerProfile>(jsonProfile);
    }

    void AddOptionOnScreen()
    {
        // get the percentage for price difference
        double priceDifference = 1;
        foreach (var difference in accommodations.priceDifferences)
        {
            if (playerProfile.erasmusCountry.Equals(difference.name))
            {
                priceDifference = difference.multiplicationFactor;
                break;
            }
        }

        foreach (var accommodation in accommodations.accommodations)
        {
            int realPrice = (int)(accommodation.price * priceDifference);
            string label = accommodation.name + " " + accommodation.price + "€/month " + "\n" 
                         + accommodation.space + " " + accommodation.type + " " + " with " + accommodation.roommates + " roommates" + "\n"
                         + accommodation.distanceToUni + "min away from uni and " + accommodation.distanceToCenter + "min away from center\n";
            if (!accommodation.privateKitchen) label += "NO ";
            label += "private kitchen, ";
            if (!accommodation.privateBathroom) label += "NO ";
            label += "private bathroom";
            AddToggle(label, accommodation.price, accommodation.name);
        }

        instructionText.text = "Select where you want to stay in " + playerProfile.erasmusCountry; 
    }

    public void ButtonClick()
    {
        Toggle selected = group.ActiveToggles().FirstOrDefault();
        Debug.Log(selected.GetComponentInChildren<Text>().text);
        int price = (int)Variables.Object(selected).Get("price");
        string name = (string)Variables.Object(selected).Get("id");
        gameStatus.GetComponent<GameStatus>().currentMoney -= price * 4;
        Debug.Log(gameStatus.GetComponent<GameStatus>().currentMoney);
        mainCanvas.GameObject().SetActive(true);
        mainCanvas.GetComponent<LaptopSceneMenu>().MarkOLADone();
        mainCanvas.GetComponent<LaptopSceneMenu>().SetAccommodationName(name);
        accommodationCanvas.GameObject().SetActive(false);
    }
}
