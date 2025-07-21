using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    private MissionManager missionManager;

    void Start()
    {
        missionManager = FindObjectOfType<MissionManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        int idx = missionManager.missions.FindIndex(m => m.target == gameObject);
        if (idx != -1)
            missionManager.CompleteSpecificMission(idx);
    }
}
