using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections;

public class TasksPanelUI : MonoBehaviour
{

    public Color rightColor = Color.green;
    public Color wrongColor = Color.red;
    public Transform parent;
    public Toggle togglePrefab;
    private GameStatus gameStatus;
    private bool allSet;

    IEnumerator Start()
    {
        // Wait for BOTH systems
        yield return new WaitUntil(() =>
            GameStatus.Instance != null &&
            GameStatus.Instance.IsInitialized &&
            TasksSystem.Instance != null &&
            TasksSystem.Instance.IsInitialized
        );

        gameStatus = GameStatus.Instance;
        BuildUI();
        allSet = true;
    }

    void Update()
    {
        if (!allSet) return;
        UpdateUI();
    }

        void AddToggle(string label, int id)
    {
        Toggle toggle = Instantiate(togglePrefab, parent);

        toggle.GetComponentInChildren<Text>().text = label;
        Variables.Object(toggle).Set("id", id.ToString());

        toggle.isOn = false;

        toggle.onValueChanged.AddListener(isOn =>
        {
            if (isOn)
                Debug.Log($"Selected: {label} | Score: {id}");
        });
    }

    void BuildUI()
    {
        var tasks = TasksSystem.Instance.GetTasks();

        for (int i = 0; i < tasks.Count; ++i)
        {
            AddToggle(tasks[i].task.description, i);
        } 
    }

    void UpdateUI()
    {
        var tasks = TasksSystem.Instance.GetTasks();

        foreach (var toggle in parent.GetComponentsInChildren<Toggle>())
        {
            int id = int.Parse(Variables.Object(toggle).Get("id").ToString());
            toggle.interactable = tasks[id].available;
            if (gameStatus.hour > tasks[id].task.maxHour)
            {
                if (toggle.isOn) toggle.GetComponentInChildren<Text>().color = rightColor;
                else toggle.GetComponentInChildren<Text>().color = wrongColor;
            }
        }
    }
}
