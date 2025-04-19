using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Threading.Tasks;

public class SimDisj : MonoBehaviour
{
    private Animator animMola;
    public GameObject objMola;
    private Animator animDisj;
    public GameObject objDisj;
    // Start is called before the first frame update
    
    //animMola= objMola.GetComponent<Animator>();
    void Start()
    {
        Time.timeScale = 1;
        animMola = objMola.GetComponent<Animator>();
        animDisj = objDisj.GetComponent<Animator>();
    }
    public void Opera()
    {
    animMola.ResetTrigger("TrMola_0");
    animDisj.ResetTrigger("TrDisj_0");
    animMola.SetTrigger("TrMola_1");
    animDisj.SetTrigger("TrDisj_1");
    }
    public void NOpera()
    {
     animMola.ResetTrigger("TrMola_0");
     animDisj.ResetTrigger("TrDisj_0");
     animMola.SetTrigger("TrMola_0");
     animDisj.SetTrigger("TrDisj_0");
    }

    public void Tempo0()
    {
        Time.timeScale = 0;
    }
    public void Tempo1()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
  
}
