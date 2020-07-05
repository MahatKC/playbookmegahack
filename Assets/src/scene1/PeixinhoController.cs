using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PeixinhoController : MonoBehaviour
{
    public float speed = 2f, smooth = 4.0f, angleNada = 10.0f;
    public GameObject destinoPeixinho, peixino, sceneController;
    public bool vaiDestino = false;
    public bool nada = false;
    float nadaTime = 0, updateTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateTime += 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (vaiDestino)
        {
            this.moveToDestiny();
        }
        if (nada)
        {
            nadaTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 180f, angleNada), Time.deltaTime * 5f);

            if (nadaTime >= updateTime)
            {
                angleNada = -angleNada;
                nadaTime = 0f;
                Debug.Log("moveu");
            }
        }
    }

    public void moveToDestiny()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinoPeixinho.transform.position, speed * Time.deltaTime);
        nada = true;
        if (Vector3.Distance(transform.position, destinoPeixinho.transform.position) < 0.001f)
        {
            nada = false;
            vaiDestino = false;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 180f, 0f), Time.deltaTime * 500000f);
            gameState.peixePosition = transform;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sceneController.GetComponent<dialogoPeixinhoController>().playDialogoNome();
        }
    }
}
