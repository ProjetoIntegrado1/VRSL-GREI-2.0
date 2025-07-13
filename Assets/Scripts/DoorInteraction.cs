using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [Header("Animators to toggle")]
    public List<Animator> doorAnimators = new List<Animator>();
    public string parameterName = "Abrir";

    [Header("Interaction Settings")]
    public KeyCode interactionKey = KeyCode.E;
    public bool useMouseButton = true;

    private bool isOpen = false;
    private HoverOutline myOutline;

    private void Awake()
    {
        myOutline = GetComponent<HoverOutline>();
    }

    private void Update()
    {
        if (HoverOutline.CurrentHovered != myOutline)
            return;

        if (Input.GetKeyDown(interactionKey) || (useMouseButton && Input.GetMouseButtonDown(0)))
        {
            isOpen = !isOpen;
            foreach (var animator in doorAnimators)
                animator?.SetBool(parameterName, isOpen);
        }
    }
}