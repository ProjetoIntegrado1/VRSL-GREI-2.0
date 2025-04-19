using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinealwaysActive : MonoBehaviour
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
            outline.enabled = true;
        }
    }
}