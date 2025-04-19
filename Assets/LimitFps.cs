using UnityEngine;



public class LimitFPS : MonoBehaviour

{

    [SerializeField]

    private int targetFrameRate = 20;



    void Start()

    {



        Application.targetFrameRate = targetFrameRate;

    }



}

