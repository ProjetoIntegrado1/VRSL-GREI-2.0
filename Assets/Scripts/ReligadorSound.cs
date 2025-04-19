using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReligadorSound : MonoBehaviour
{
    public float teste;
    public AudioClip som_Religador;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        //aud.playOnAwake = false;

        //aud.loop = false;
        teste = 0;
        aud = GetComponent<AudioSource>();
        if (som_Religador)
        {
            aud.clip = som_Religador;
        }
     



    }

    private void Update()
    {
       // if(teste==1)
       // {
         //   StartCoroutine(On(4.0f));
          //  teste = 2;
           // aud.PlayOneShot(aud.clip);
        //}
        
        // StartCoroutine(On());
        // aud.PlayOneShot(aud.clip);


    }


    public void Acionar_Religador()
    {
        aud.PlayOneShot(aud.clip);
        Time.timeScale = 0;
    }

    public void Chama()
    {
        Time.timeScale = 1;
        Invoke("Acionar_Religador", 3);
    }
    // Update is called once per frame
  



    // private IEnumerator On(float time_to_wait)
   // {
     //   yield return new WaitForSeconds(time_to_wait);
    //}

}
