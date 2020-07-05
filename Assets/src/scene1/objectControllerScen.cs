using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectControllerScen : MonoBehaviour
{

    public GameObject destiny;
    public bool vaiDestino = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vaiDestino)
        {
            Debug.Log("testeeeeeeee");
            moveToDestiny();
        }
    }
    public void moveToDestiny()
    {
        transform.position = Vector3.MoveTowards(transform.position, destiny.transform.position, 5f * Time.deltaTime);
        if (Vector3.Distance(transform.position, destiny.transform.position) < 0.001f)
        {
            vaiDestino = false;
        }

    }

}
