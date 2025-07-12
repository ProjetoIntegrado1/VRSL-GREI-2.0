using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour
{
    public List<Mission> missions = new();
    public TextMeshProUGUI missionText;
    public Toggle checkBox;
    public Transform allMissionsContainer;
    public GameObject missionEntryPrefab;

    private int currentIndex = 0;
    private bool suppressToggleCallback = false;

    void Start()
    {
        checkBox.onValueChanged.AddListener(OnCheckBoxChanged);

        if (missions.Count > 0)
        {
            UpdateMissionUI();
            PopulateAllMissionsPanel();
        }
            
    }

    void UpdateMissionUI()
    {
        var m = missions[currentIndex];
        suppressToggleCallback = true;
        missionText.text = m.description;
        checkBox.isOn = false;
        suppressToggleCallback = false;
    }

    public void OnCheckBoxChanged(bool value)
    {
        if (suppressToggleCallback || !value) return;

        missions[currentIndex].isCompleted = true;
        GoToNextMission();
        UpdateAllMissionsPanel();
    }

    void GoToNextMission()
    {
        currentIndex++;
        if (currentIndex < missions.Count)
            UpdateMissionUI();
        else
        {
            missionText.text = "Todas as missões completas!";
            checkBox.gameObject.SetActive(false);
        }
    }

    public void CompleteMissionByTarget(GameObject target)
    {
        if (currentIndex >= missions.Count) return;

        var current = missions[currentIndex];
        if (current.target == target && !current.isCompleted)
        {
            current.isCompleted = true;
            checkBox.isOn = true;
        }
    }

    public void CompleteSpecificMission(int index)
    {
        if (index < 0 || index >= missions.Count) return;

        var mission = missions[index];
        if (!mission.isCompleted)
        {
            if (index == currentIndex)
            {
                mission.isCompleted = true;
                checkBox.isOn = true;
            }
            else
            {
                UpdateAllMissionsPanel();
            }
        }
    }

    public bool IsCurrentMissionTarget(GameObject obj)
    {
        if (currentIndex >= missions.Count) return false;

        var current = missions[currentIndex];
        return current.type == Mission.MissionType.Interaction && current.target == obj;
    }

    void PopulateAllMissionsPanel()
    {
        foreach (Transform child in allMissionsContainer)
            Destroy(child.gameObject);

        foreach (var mission in missions)
        {
            GameObject entry = Instantiate(missionEntryPrefab, allMissionsContainer);
            var text = entry.transform.Find("Description").GetComponent<TextMeshProUGUI>();
            var toggle = entry.transform.Find("Toggle").GetComponent<Toggle>();

            text.text = mission.description;
            toggle.isOn = mission.isCompleted;
            toggle.interactable = false;
        }
    }

    void UpdateAllMissionsPanel()
    {
        int i = 0;
        foreach (Transform child in allMissionsContainer)
        {
            if (i >= missions.Count) break;
            var toggle = child.Find("Toggle").GetComponent<Toggle>();
            toggle.isOn = missions[i].isCompleted;
            i++;
        }
    }
}
