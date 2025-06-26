using UnityEngine;
using UnityEngine.EventSystems; // se quiser filtrar UI
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class HoverOutline : MonoBehaviour
{
    private static HoverOutline currentHovered; // quem está com outline agora
    private Outline outline;
    [Header("Canva a abrir ao clicar")]
    public GameObject canvasDoObjeto;
    private MenuSystem menuSystem;

    private void Awake()
    {
        // Garantir Outline
        outline = GetComponent<Outline>() ?? gameObject.AddComponent<Outline>();
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10f;
        outline.enabled = false;

        // pegar o menuSystem
        menuSystem = FindObjectOfType<MenuSystem>();
        if (menuSystem == null)
            Debug.LogError("Não encontrei nenhum MenuSystem na cena!");

        // Se for mesh estático, usar MeshCollider para cobertura exata:
        if (GetComponent<MeshFilter>() != null && GetComponent<MeshCollider>() == null)
        {
            var meshCol = gameObject.AddComponent<MeshCollider>();
            meshCol.convex = false; // ou true, dependendo do uso
        }
        // Senão, ajusta um BoxCollider aos bounds do MeshRenderer
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
    }

    private void Update()
    {
        // 1) Raycast só dispara se o ponteiro não estiver sobre UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            ClearCurrent();
            return;
        }

        // 2) Raycast da câmera principal
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int interactiveMask = 1 << 6;
        if (Physics.Raycast(ray, out var hit, 100f, interactiveMask))
        {
            var hov = hit.collider.GetComponent<HoverOutline>();
            if (hov != null)
            {
                // se mudou de alvo, limpa o anterior
                if (currentHovered != hov)
                {
                    ClearCurrent();
                    currentHovered = hov;
                    currentHovered.outline.enabled = true;
                }

                // clique
                if (Input.GetMouseButtonDown(0))
                {
                    menuSystem.OpenMenu(canvasDoObjeto, true);
                }

                return;
            }
        }

        // se não acertou nada ou não é interativo, limpa
        ClearCurrent();
    }

    private void ClearCurrent()
    {
        if (currentHovered != null)
        {
            currentHovered.outline.enabled = false;
            currentHovered = null;
        }
    }
}
