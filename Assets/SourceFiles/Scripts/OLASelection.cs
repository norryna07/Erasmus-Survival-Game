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
using System.Collections;

public class OLASelection : MonoBehaviour
{
    public Transform leftParent, rightParent;
    public ToggleGroup leftGroup, rightGroup;
    public Toggle togglePrefab;
    public GameObject gameStatus;
    public Color rightColor = Color.darkGreen;
    public Color wrongColor = Color.red;
    public Color defaultColor = Color.black;
    public TMP_Text instructionMessage;
    public Canvas mainCanvas, OLACanvas;
    private CoursesJSON courses;
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
        Toggle rightToggle = rightGroup.GetFirstActiveToggle();
        Toggle leftToggle = leftGroup.GetFirstActiveToggle();;
        if (rightToggle == null || leftToggle == null) return;

        string rightID = (string)Variables.Object(rightToggle).Get("id");
        string leftID = (string)Variables.Object(leftToggle).Get("id");

        if (rightID == leftID)
        {
            // we made them green and set them us not interactable
            rightToggle.GetComponentInChildren<Text>().color = rightColor;
            leftToggle.GetComponentInChildren<Text>().color = rightColor;
            rightToggle.isOn = false;
            leftToggle.isOn = false;
            rightToggle.interactable = false;
            leftToggle.interactable = false;
        } else
        {
            StartCoroutine(HighlightCoroutine(rightToggle, leftToggle));
        }
    }

    private IEnumerator HighlightCoroutine(Toggle right, Toggle left)
    {
        right.GetComponentInChildren<Text>().color = wrongColor;
        left.GetComponentInChildren<Text>().color = wrongColor;
        yield return new WaitForSeconds(1f);
        if (right.interactable) right.GetComponentInChildren<Text>().color = defaultColor;
        if (left.interactable) left.GetComponentInChildren<Text>().color = defaultColor;
        right.isOn = false;
    }

    void AddToggle(string label, string id, Transform parent, ToggleGroup group)
    {
        Toggle toggle = Instantiate(togglePrefab, parent);

        toggle.GetComponentInChildren<Text>().text = label;
        Variables.Object(toggle).Set("id", id);

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
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/courses");
        if (jsonFile == null)
        {
            Debug.LogError("JSON file not found!");
            return;
        }

        string json = jsonFile.text;
        courses = JsonUtility.FromJson<CoursesJSON>(json);

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
        Course[] selectedCourses = courses.courses.Where(c => c.major == playerProfile.major).ToArray();
        Course[] homeCourses = selectedCourses.OrderBy(_ => Random.value).Take(6).ToArray();

        // fill the left part
        foreach (var course in homeCourses)
        {
            AddToggle(course.englishName, course.courses_id, leftParent, leftGroup);
        }

        // fill the right part
        foreach (var course in selectedCourses)
        {
            Debug.Log(course.translations);
            AddToggle(course.translations.GetByCountry(playerProfile.erasmusCountry), course.courses_id, rightParent, rightGroup);
        }
    }

    public void ButtonClick()
    {
        foreach (var toggle in leftGroup.GetComponentsInChildren<Toggle>())
        {
            if (toggle.interactable)
            {
                instructionMessage.text = "You need to find all courses";
                instructionMessage.color = wrongColor;
                return;
            }
        }
        mainCanvas.GameObject().SetActive(true);
        mainCanvas.GetComponent<LaptopSceneMenu>().MarkOLADone();
        OLACanvas.GameObject().SetActive(false);
        TasksSystem.Instance.UpdateTasks("laptop_transport");
    }
}
