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

public class CVSelection : MonoBehaviour
{
    public Transform parent;
    public ToggleGroup group;
    public Toggle togglePrefab;
    public Button button;
    public TMP_Text titleText;
    public Canvas mainCanvas, CVCanvas;
    private CVoptionsJSON CVoptions;
    private int currentOptionNumber;
    private PlayerProfile playerProfile;
    private int totalScore;
    private string[] selectedOptions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadData();
        AddOptionOnScreen();
        selectedOptions = new string[CVoptions.CVoptions.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddToggle(string label, int score)
    {
        Toggle toggle = Instantiate(togglePrefab, parent);

        toggle.GetComponentInChildren<Text>().text = label;
        Variables.Object(toggle).Set("score", score);

        toggle.isOn = false;
        toggle.group = group;

        toggle.onValueChanged.AddListener(isOn =>
        {
            if (isOn)
                Debug.Log($"Selected: {label} | Score: {score}");
        });
    }

    void LoadData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/CVoptions");
        if (jsonFile == null)
        {
            Debug.LogError("JSON file not found!");
            return;
        }

        string json = jsonFile.text;
        CVoptions = JsonUtility.FromJson<CVoptionsJSON>(json);
        currentOptionNumber = 0;

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
        CVSection currentSection = CVoptions.CVoptions[currentOptionNumber];
        titleText.text = currentSection.name;
        foreach (var option in currentSection.options)
        {
            if (option.major != null && option.major.Length > 0)
            {
                if (!option.major.Contains(playerProfile.major)) continue;
            }
            string label = option.text.Replace("firstname", playerProfile.name);
            label = label.Replace("lastname", playerProfile.surname);
            AddToggle(label, option.score);
        }
    }

    public void ButtonClick()
    {
        Toggle selected = group.ActiveToggles().FirstOrDefault();
        selectedOptions[currentOptionNumber] = selected.GetComponentInChildren<Text>().text;
        totalScore += (int)Variables.Object(selected).Get("score");
        if (currentOptionNumber == CVoptions.CVoptions.Length - 1)
        {
            Debug.Log(selectedOptions);
            Debug.Log(totalScore);
            mainCanvas.GameObject().SetActive(true);
            mainCanvas.GetComponent<LaptopSceneMenu>().MarkCVDone();
            CVCanvas.GameObject().SetActive(false);
        }
        else
        {   
            CleanScreen();
            currentOptionNumber ++;
            AddOptionOnScreen();
            if (currentOptionNumber == CVoptions.CVoptions.Length - 1)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Save";
            }
        }
    }

    void CleanScreen()
    {
        foreach(Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
