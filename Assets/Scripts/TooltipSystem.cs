using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;

    public Tooltip tooltip;

    public void Awake()
    {
        current = this;
    }

    public static void Show(string content, string header = "")
    {
        if (current == null || current.tooltip == null) return;
        current.tooltip.SetText(content, header);
        current.tooltip.Update();
        current.tooltip.gameObject.SetActive(true);
    }
    
    public static void Hide()
    {
        if (current == null || current.tooltip == null) return;
        current.tooltip.gameObject.SetActive(false);
    }
}
