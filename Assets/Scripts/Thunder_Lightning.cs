using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_Lightning : MonoBehaviour
{
    public GameObject Thunder;
    public float teste;
    //public AudioClip som_Raio;
    //AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        //aud.playOnAwake = false;
        Thunder.SetActive(false);
        //aud.loop = false;
        teste = 0;
       // audi = GetComponent<AudioSource>();
        //if (som_Raio)
        //{
          //  audi.clip = som_Raio;
        //}
     



    }




    public void Cair_Raio()
    {
        Thunder.SetActive(false);
        
        Time.timeScale = 0;
    }

    public void Chama()
    {
        Time.timeScale = 1;
        Thunder.SetActive(true);
       // audi.PlayOneShot(audi.clip);
        Invoke("Cair_Raio", 2);
    }
    // Update is called once per frame
  



    // private IEnumerator On(float time_to_wait)
   // {
     //   yield return new WaitForSeconds(time_to_wait);
    //}

}
