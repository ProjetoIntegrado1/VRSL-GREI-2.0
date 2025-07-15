using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour
{
    [Header("Configurações de Missões")]
    public List<Mission> missions = new List<Mission>();

    [Header("Viewport A")]
    public Transform missionsContainerA;
    public GameObject missionEntryPrefabA;

    [Header("Viewport B")]
    public Transform missionsContainerB;
    public GameObject missionEntryPrefabB;

    [Header("UI da Missão Atual")]
    public TextMeshProUGUI missionText;
    public Toggle checkBox;

    private int currentIndex = 0;
    private bool suppressToggleCallback = false;

    void Start()
    {
        checkBox.onValueChanged.AddListener(OnCheckBoxChanged);

        if (missions.Count > 0)
        {
            SkipCompletedMissions();
            UpdateMissionUI();
            PopulateMissionsPanel(missionsContainerA, missionEntryPrefabA);
            PopulateMissionsPanel(missionsContainerB, missionEntryPrefabB);
        }
    }

    void UpdateMissionUI()
    {
        if (currentIndex < missions.Count)
        {
            var m = missions[currentIndex];
            suppressToggleCallback = true;
            missionText.text = m.description;
            checkBox.isOn = m.isCompleted;
            suppressToggleCallback = false;
        }
    }

    public void OnCheckBoxChanged(bool value)
    {
        if (suppressToggleCallback || !value) return;
        CompleteCurrentMission();
    }

    private void CompleteCurrentMission()
    {
        missions[currentIndex].isCompleted = true;
        UpdateEntryInPanels(currentIndex);
        GoToNextMission();
    }

    void GoToNextMission()
    {
        currentIndex++;
        SkipCompletedMissions();

        if (currentIndex < missions.Count)
        {
            UpdateMissionUI();
        }
        else
        {
            missionText.text = "Todas as missões completas!";
            checkBox.gameObject.SetActive(false);
        }
    }

    private void SkipCompletedMissions()
    {
        while (currentIndex < missions.Count && missions[currentIndex].isCompleted)
        {
            currentIndex++;
        }
    }

    public void CompleteMissionByTarget(GameObject target)
    {
        if (currentIndex >= missions.Count) return;
        var current = missions[currentIndex];
        if (current.target == target && !current.isCompleted)
        {
            CompleteCurrentMission();
        }
    }

    public void CompleteSpecificMission(int index)
    {
        if (index < 0 || index >= missions.Count) return;
        if (missions[index].isCompleted) return;

        missions[index].isCompleted = true;
        UpdateEntryInPanels(index);

        if (index == currentIndex)
        {
            suppressToggleCallback = true;
            checkBox.isOn = true;
            suppressToggleCallback = false;
            GoToNextMission();
        }
    }

    public bool IsCurrentMissionTarget(GameObject obj)
    {
        if (currentIndex >= missions.Count) return false;
        var current = missions[currentIndex];
        return current.type == Mission.MissionType.Interaction && current.target == obj;
    }

    void PopulateMissionsPanel(Transform container, GameObject prefab)
    {
        if (container == null || prefab == null) return;
        foreach (Transform child in container)
            Destroy(child.gameObject);

        for (int i = 0; i < missions.Count; i++)
        {
            int idx = i;
            GameObject entry = Instantiate(prefab, container);
            var text = entry.transform.Find("Description").GetComponent<TextMeshProUGUI>();
            var toggle = entry.transform.Find("Toggle").GetComponent<Toggle>();
            text.text = missions[idx].description;
            toggle.isOn = missions[idx].isCompleted;
            toggle.interactable = true;
            toggle.onValueChanged.AddListener((val) => {
                if (val) CompleteSpecificMission(idx);
            });
        }
    }

    void UpdateEntryInPanels(int index)
    {
        UpdatePanelEntry(missionsContainerA, index);
        UpdatePanelEntry(missionsContainerB, index);
    }

    void UpdatePanelEntry(Transform container, int index)
    {
        if (container == null || index < 0 || index >= container.childCount) return;
        var entry = container.GetChild(index);
        var toggle = entry.Find("Toggle").GetComponent<Toggle>();
        suppressToggleCallback = true;
        toggle.isOn = missions[index].isCompleted;
        suppressToggleCallback = false;
    }
}
