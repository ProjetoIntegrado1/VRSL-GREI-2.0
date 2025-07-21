using UnityEngine;

[System.Serializable]
public class Mission
{
    public string description;
    public bool isCompleted;
    public enum MissionType { Trigger, Interaction, Button }
    public MissionType type;
    public GameObject target;
}