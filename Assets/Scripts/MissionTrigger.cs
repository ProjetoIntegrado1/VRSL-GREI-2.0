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
        if (other.CompareTag("Player"))
            missionManager.CompleteMissionByTarget(gameObject);
    }
}
