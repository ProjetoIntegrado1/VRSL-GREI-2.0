using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porta_Simples : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator _animator;
    private bool _colidindo;
    private bool _portaAberta = false;
    //public Text texto;
    public GameObject texto;
    public GameObject mira;
    

    void Start()
    {
       
        // texto.enabled = false;
        mira.SetActive(true);
        texto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)&& _colidindo){
    		_portaAberta=true;
    		_animator.SetTrigger("Abrir");
            texto.SetActive(false);
            mira.SetActive(true);
    
        }
    }

    void OnTriggerEnter(Collider _col){
    	if(_col.gameObject.CompareTag("Player")){
    		_colidindo=true;
            mira.SetActive(false);
            texto.SetActive(true);
            
    	}    	
    }
    
    void OnTriggerExit(Collider _col){
    	if(_col.gameObject.CompareTag("Player")){
    		if (_portaAberta){
    			_animator.SetTrigger("Fechar");
    		}
    		_colidindo=false;
            texto.SetActive(false);
            mira.SetActive(true);
    	}    	
    }
}
