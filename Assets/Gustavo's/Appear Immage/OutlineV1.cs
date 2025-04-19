using UnityEngine;

public class OutlineV1 : MonoBehaviour
{
    private Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            outline = gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.cyan;
            outline.OutlineWidth = 10.0f;
            outline.enabled = false;
        }
    }

    void OnMouseEnter()
    {
        outline.enabled = true;
    }

    void OnMouseExit()
    {
        outline.enabled = false;
    }
}