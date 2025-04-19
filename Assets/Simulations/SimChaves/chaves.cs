using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Threading.Tasks;


public class chaves : MonoBehaviour
{

    private Animator meuAnimator1;
    public GameObject objAnimator1;
    private Animator meuAnimator2;
    public GameObject objAnimator2;
    private Animator meuAnimator3;
    public GameObject objAnimator3;
    // Start is called before the first frame update
    void Start()
    {
     meuAnimator1 = objAnimator1.GetComponent<Animator>();
     meuAnimator2 = objAnimator2.GetComponent<Animator>();
     meuAnimator3 = objAnimator3.GetComponent<Animator>();
    }
    public void Abre_Chave()
    {

        meuAnimator1.SetTrigger("TrAbre");
        meuAnimator2.SetTrigger("TrAbre");
        meuAnimator3.SetTrigger("TrAbre");
        //		status=false;

        //Texto();

    }
    public void Fecha_Chave()
    {
        meuAnimator1.ResetTrigger("TrAbre");
        meuAnimator2.ResetTrigger("TrAbre");
        meuAnimator3.ResetTrigger("TrAbre");
        meuAnimator1.SetTrigger("TrFecha");
        meuAnimator2.SetTrigger("TrFecha");
        meuAnimator3.SetTrigger("TrFecha");
        //objRotation = objAnimator.transform.rotation.x;
        //	Debug.Log(objRotation);
        //	if (objRotation == 0)
        //{
        //			meuAnimator.SetTrigger("TrAbre");
        //		status = false;
        //}
        //		else
        //	{
        //meuAnimator.SetTrigger("TrFecha");
        //	status = true;
        //}
        //Texto();

    }
    // Update is called once per frame
   
    public void Tempo1()
    {
        Time.timeScale = 1;
    }
    public void Tempo0()
    {
        Time.timeScale = 0;
    }
}
