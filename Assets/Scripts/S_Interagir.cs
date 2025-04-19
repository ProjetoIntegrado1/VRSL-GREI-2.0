using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interagir : MonoBehaviour
{



    public GameObject cube;

    
    private Renderer myRenderer;
    //private bool isMouseOver = false;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnMouseEnter()
    {
        myRenderer.material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        myRenderer.material.color = Color.white;
    }
}