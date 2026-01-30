using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using ErasmusGame.Models;
using System.Collections;

public class LuggageInteraction : InteractionInterface
{
    public TMP_Text infoText;
    public TMP_Text totalText;
    public GameStatus gameStatus;
    public Transform parent;
    public Toggle togglePrefab;
    public Button saveButton;
    public GameObject panel;

    private float totalWeight;
    private LuggageJSON luggageItems;

    public IEnumerator Start()
    {
        interactDistance = 100f;

        yield return new WaitUntil(() =>
            GameStatus.Instance != null &&
            GameStatus.Instance.IsInitialized
        );

        gameStatus = GameStatus.Instance;
        LoadData();
        BuildUI();
    }
    protected override bool IsInteracting()
    {
        return input.interact;
    }
    protected override void DefaultUpdate()
    {
        
    }
    protected override void InteractAction()
    {
        infoText.text = "Interacting with luggage";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        input.cursorInputForLook = false;
        panel.SetActive(true);
    }
    protected override void EndingInteractAction()
    {
        infoText.text = "Ending Interaction with luggage";
    }
    protected override void OnTriggerEnterAction()
    {
        infoText.text = "Press E to interact with luggage";
    }
    protected override void OnTriggerExitAction()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        input.cursorInputForLook = true;
        infoText.text = "";
    }

    void AddToggle(string label, float weight)
    {
        Toggle toggle = Instantiate(togglePrefab, parent);

        toggle.GetComponentInChildren<Text>().text = label;
        Variables.Object(toggle).Set("weight", weight);

        toggle.isOn = false;

        toggle.onValueChanged.AddListener(isOn =>
        {
            if (isOn)
            {
                totalWeight += float.Parse(Variables.Object(toggle).Get("weight").ToString());
                totalText.text = "Total:" + totalWeight.ToString() + "/25";
                if (totalWeight > 25)
                {
                    saveButton.interactable = false;
                } else
                {
                    saveButton.interactable = true;
                }
            } else
            {
                totalWeight -= float.Parse(Variables.Object(toggle).Get("weight").ToString());
                totalText.text = $"Total: {totalWeight:F2}/25";
                if (totalWeight > 25)
                {
                    saveButton.interactable = false;
                } else
                {
                    saveButton.interactable = true;
                }
            }
        });
    }

    public void LoadData()
    {
        // read the tasks json from resources
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/luggageItems");
        if (jsonFile == null)
        {
            Debug.LogError("JSON file not found!");
            return;
        }

        string json = jsonFile.text;
        luggageItems = JsonUtility.FromJson<LuggageJSON>(json);

    }

    void BuildUI()
    {
        foreach (var item in luggageItems.items)
        {
            AddToggle(item.name, item.weight);
        } 
    }

    public void Save()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        input.cursorInputForLook = true;
        panel.SetActive(false);
        TasksSystem.Instance.UpdateTasks("luggage");
    }
}
