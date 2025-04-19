using UnityEngine;
using UnityEngine.UI;

public class AparecerV2 : MonoBehaviour
{
    public Image RET;
    public Image QDSACC;
    public Image QDSACA;
    public string target1 = "RET";
    public string target2 = "QDSACC";
    public string target3 = "QDSACA";

    void Start()
    {
        RET.enabled = false;
        QDSACC.enabled = false;
        QDSACA.enabled = false;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag(target1))
            {
                RET.enabled = true;
                QDSACC.enabled = false;
                QDSACA.enabled = false;
            }

            else if (hit.transform.CompareTag(target2))
            {
                QDSACC.enabled = true;
                RET.enabled = false;
                QDSACA.enabled = false;
            }

            else if (hit.transform.CompareTag(target3))
            {
                QDSACA.enabled = true;
                RET.enabled = false;
                QDSACC.enabled = false;
            }
            else
            {
                QDSACA.enabled = false;
                QDSACC.enabled = false;
                RET.enabled = false;
            }
        }
        else
        {
            RET.enabled = false;
            QDSACA.enabled = false;
            QDSACC.enabled = false;
        }
    
    }
}