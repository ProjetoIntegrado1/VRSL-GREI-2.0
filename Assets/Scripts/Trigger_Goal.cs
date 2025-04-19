using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Trigger_Goal : MonoBehaviour
{

    
public GameObject goal;
Collider _col;

    // Start is called before the first frame update
    void Start()
    {
        goal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {	
        
  
    }

void OnTriggerEnter(Collider _col){
    	if(_col.gameObject.CompareTag("Player")){
    		goal.SetActive(true);
    	}    	
    } 






}
