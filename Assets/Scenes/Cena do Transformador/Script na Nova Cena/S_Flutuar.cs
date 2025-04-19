using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Flutuar : MonoBehaviour

    
{

    public GameObject Obj;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cube.gameObject.transform.position = new Vector3(Obj.transform.position.x, cube.transform.position.y , Obj.transform.position.z);

        if (Input.GetKey(KeyCode.U) && cube.transform.position.y < 3.4)
        
        {

            cube.gameObject.transform.position = new Vector3 (cube.transform.position.x, cube.transform.position.y + 3* Time.deltaTime, cube.transform.position.z);
        }

        if (Input.GetKey(KeyCode.I) && cube.transform.position.y > -0.01)

        {

            cube.gameObject.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y - 3 * Time.deltaTime, cube.transform.position.z);
        }
    }
}