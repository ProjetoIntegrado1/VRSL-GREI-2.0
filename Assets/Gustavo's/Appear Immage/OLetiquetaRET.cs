using UnityEngine;

public class OLetiquetaRET : MonoBehaviour
{
    private Outline outline;

    void Start()
    { 
        outline = GetComponent<Outline>();

        if (outline == null)
        {
            outline = gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.cyan;
            outline.OutlineWidth = 15.0f;
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

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("RET"))
            {
                outline.enabled = true;
            }

            else 
            {
                outline.enabled = false;
            }
        }
        else
        {
            outline.enabled = false;
        }
    }
}