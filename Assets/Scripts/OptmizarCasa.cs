using UnityEngine;
using System.Collections;



public class OptmizarCasa : MonoBehaviour 
{
 public GameObject OPTIMIZAR;
 
void Start()
{
 OPTIMIZAR.SetActive (false);
 
}

 void OnTriggerStay ()
 {
  OPTIMIZAR.SetActive (true);
 }
 void OnTriggerExit ()
 {
  OPTIMIZAR.SetActive (false);

 }
}