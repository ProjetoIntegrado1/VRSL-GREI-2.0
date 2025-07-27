using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static MenuSystem;

public class HoverOutline : MonoBehaviour
{
    private static HoverOutline currentHovered;
    public static HoverOutline CurrentHovered => currentHovered;

    private Outline outline;

    [SerializeField]
    private List<Collider> interactiveColliders = new List<Collider>();

    [Header("Canvas a abrir ao clicar")]
    public GameObject canvasDoObjeto;

    private MenuSystem menuSystem;

    private int interactiveMask = 1 << 6;

    private void Awake()
    {
        // garantir Outline
        outline = GetComponent<Outline>() ?? gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 7f;
        outline.enabled = false;

        // pegar o menuSystem
        menuSystem = FindObjectOfType<MenuSystem>();
        if (menuSystem == null)
            Debug.LogError($"[{nameof(HoverOutline)}] Não encontrei nenhum MenuSystem na cena!", this);

        // se for mesh estático, usar MeshCollider para cobertura exata:
        if (GetComponent<MeshFilter>() != null && GetComponent<MeshCollider>() == null)
        {
            var meshCol = gameObject.AddComponent<MeshCollider>();
            meshCol.convex = false;
        }
        // ajusta um BoxCollider aos bounds do MeshRenderer
        else if (GetComponent<Collider>() == null)
        {
            var mr = GetComponent<MeshRenderer>();
            if (mr != null)
            {
                var bc = gameObject.AddComponent<BoxCollider>();
                bc.center = transform.InverseTransformPoint(mr.bounds.center);
                bc.size = mr.bounds.size;
            }
        }

        // inclui todos os colliders deste GameObject
        foreach (var col in GetComponents<Collider>())
            if (!interactiveColliders.Contains(col))
                interactiveColliders.Add(col);

        if (interactiveColliders.Count == 0)
            Debug.LogWarning($"[{nameof(HoverOutline)}] Não há colliders para interagir.", this);
    }

    private void Update()
    {
        if (menuSystem.currentState != MenuState.Crosshair && menuSystem.currentState != MenuState.Interaction)
        {
            ClearCurrent();
            return;
        }

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            ClearCurrent();
            return;
        }

        Camera cam = GetCamera();
        if (cam == null)
        {
            ClearCurrent();
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 50f, interactiveMask))
        {
            HoverOutline hov = hit.collider.GetComponentInParent<HoverOutline>();
            if (hov != null)
            {
                if (currentHovered != hov)
                {
                    ClearCurrent();
                    currentHovered = hov;
                    currentHovered.outline.enabled = true;
                }

                if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && currentHovered == this)
                {
                    menuSystem.OpenMenu(canvasDoObjeto, isTablet: false);

                    var missionManager = FindObjectOfType<MissionManager>();
                    if (missionManager != null && missionManager.IsCurrentMissionTarget(gameObject))
                        missionManager.CompleteMissionByTarget(gameObject);
                }

                return;
            }
        
        }

        ClearCurrent();
        currentHovered = null;
    }

    private void ClearCurrent()
    {
        if (currentHovered != null && menuSystem.allOutlinesEnabled == false)
        {
            currentHovered.outline.enabled = false;
            currentHovered = null;
        }
    }

    public void AddInteractiveCollider(Collider col)
    {
        if (col != null && !interactiveColliders.Contains(col))
            interactiveColliders.Add(col);
    }

    private Camera GetCamera()
    {
        var validCams = new List<Camera>();
        foreach (var c in Camera.allCameras)
        {
            if (!c.enabled || !c.gameObject.activeInHierarchy)
                continue;
            if (!c.pixelRect.Contains(Input.mousePosition))
                continue;
            validCams.Add(c);
        }

        if (validCams.Count == 1)
            return validCams[0];

        if (validCams.Count >= 2)
            return validCams[1];

        return null;
    }
}