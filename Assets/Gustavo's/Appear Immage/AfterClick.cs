using UnityEngine;
using UnityEngine.UI;

public class AfterClick : MonoBehaviour
{   
    //Declarar os objetos e variaveis
    public Image RET;
    public Image QDSACA;
    public Image QDSACC;

    public Image RET2;
    public Image QDSACA2;
    public Image QDSACC2;

    private string target1 = "RET";
    private string target2 = "QDSACC";
    private string target3 = "QDSACA";

    private Outline outline1;
    private Outline outline2;
    private Outline outline3;

    public GameObject etiquetaRET;
    public GameObject etiquetaQDSACC;
    public GameObject etiquetaQDSACA;


    void Start()
    {
        //Declara o estado inicial de todas as imagens e outlines como desabilitadas
        RET.enabled = false;
        QDSACC.enabled = false;
        QDSACA.enabled = false;
        
        RET2.enabled = false;
        QDSACA2.enabled = false;
        QDSACC2.enabled = false;

        outline1 = GetComponent<Outline>();
        outline2 = GetComponent<Outline>();
        outline3 = GetComponent<Outline>();

        if (outline1 == null)
        {
            outline1 = etiquetaRET.AddComponent<Outline>();
            outline1.OutlineColor = Color.cyan;
            outline1.OutlineWidth = 15.0f;
            outline1.enabled = false;
        }

        if(outline2 == null)
        { 
            outline2 = etiquetaQDSACC.AddComponent<Outline>();
            outline2.OutlineColor = Color.cyan;
            outline2.OutlineWidth = 15.0f;
            outline2.enabled = false;
        }

        if(outline3 == null)
        {   
            outline3 = etiquetaQDSACA.AddComponent<Outline>();
            outline3.OutlineColor = Color.cyan;
            outline3.OutlineWidth = 15.0f;
            outline3.enabled = false;
        }
    }

    void Update()
    {
        //Declara o raycast e o colisor
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

//---------------------------------------------------------------------------------------
//Referente ao Painel Retificador
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag(target1))
            {
                RET.enabled = true;
                QDSACC.enabled = false;
                QDSACA.enabled = false;

                RET2.enabled = false;
                QDSACA2.enabled = false;
                QDSACC2.enabled = false;
               
                outline1.enabled = true;
                outline2.enabled = false;
                outline3.enabled = false;
            }
        
//---------------------------------------------------------------------------------------
//Referente ao Painel QDSACC
            else if (hit.transform.CompareTag(target2))
            {
                QDSACC.enabled = true;
                RET.enabled = false;
                QDSACA.enabled = false;

                RET2.enabled = false;
                QDSACA2.enabled = false;
                QDSACC2.enabled = false;

                outline1.enabled = false;
                outline2.enabled = true;
                outline3.enabled = false;

            }
//---------------------------------------------------------------------------------------
//Referente ao Painel QDSACA
            else if (hit.transform.CompareTag(target3))
            {
                QDSACA.enabled = true;
                RET.enabled = false;
                QDSACC.enabled = false;

                RET2.enabled = false;
                QDSACA2.enabled = false;
                QDSACC2.enabled = false;

                outline1.enabled = false;
                outline2.enabled = false;
                outline3.enabled = true;
            }
//---------------------------------------------------------------------------------------
//Analisar se o mouse clicou em algo
            else if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.CompareTag(target1))
                {
                    RET2.enabled = true;
                    QDSACA2.enabled = false;
                    QDSACC2.enabled = false;

                    RET.enabled = false;
                    QDSACA.enabled = false;
                    QDSACC.enabled = false;
                }
                else if (hit.transform.CompareTag(target2))
                {    
                    RET2.enabled = false;
                    QDSACA2.enabled = true;
                    QDSACC2.enabled = false;

                    RET.enabled = false;
                    QDSACA.enabled = false;
                    QDSACC.enabled = false;
                }
                else if (hit.transform.CompareTag(target3))
                {
                    RET2.enabled = false;
                    QDSACA2.enabled = false;
                    QDSACC2.enabled = true;

                    RET.enabled = false;
                    QDSACA.enabled = false;
                    QDSACC.enabled = false;
                }
                else 
                {
                    RET2.enabled = false;
                    QDSACA2.enabled = false;
                    QDSACC2.enabled = false;

                    RET.enabled = false;
                    QDSACA.enabled = false;
                    QDSACC.enabled = false;
                }
            }
//---------------------------------------------------------------------------------------
//se colidir com um objeto e ele nn possuir nenhuma das tags determinadas, todas as imagens ficam desabilitadas
            else
            {
                QDSACA.enabled = false;
                QDSACC.enabled = false;
                RET.enabled = false;

                RET2.enabled = false;
                QDSACA2.enabled = false;
                QDSACC2.enabled = false;
            }
        }
//---------------------------------------------------------------------------------------
//Se nn colidir com nenhum objeto, todas as imagens ficam desabilitadas
        else
        {
            RET.enabled = false;
            QDSACA.enabled = false;
            QDSACC.enabled = false;

            RET2.enabled = false;
            QDSACA2.enabled = false;
            QDSACC2.enabled = false;
        }
    }
}