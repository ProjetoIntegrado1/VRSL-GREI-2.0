using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TriggerHintManager : MonoBehaviour
{
    [System.Serializable]
    public class TriggerInfo
    {
        public Collider trigger;
        [TextArea]
        public string message;
    }

    [Header("Referências de UI")]
    public GameObject panel;
    public TextMeshProUGUI messageText;
    public string hoverText = "Clique ou aperte E para interagir";

    [Header("Configuração de Triggers")]
    public List<TriggerInfo> triggers = new List<TriggerInfo>();

    private Collider playerCollider;

    void Awake()
    {
        panel.SetActive(false);

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerCollider = player.GetComponent<Collider>();
        if (playerCollider == null)
            Debug.LogError("TriggerHintPanel: Não encontrei Collider no Player com tag 'Player'.");
    }

    void Update()
    {
        // verifica hover
        var hov = HoverOutline.CurrentHovered;
        if (hov != null)
        {
            ShowPanel(hoverText);
            return;
        }

        // verifica colisões com triggers
        if (playerCollider != null)
        {
            foreach (var info in triggers)
            {
                if (info.trigger != null && info.trigger.bounds.Intersects(playerCollider.bounds))
                {
                    ShowPanel(info.message);
                    return;
                }
            }
        }

        panel.SetActive(false);
    }

    private void ShowPanel(string text)
    {
        messageText.text = text;
        panel.SetActive(true);
    }
}