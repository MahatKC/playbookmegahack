using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimatorObject : MonoBehaviour
{
    // Start is called before the first frame update
    bool up, down, isDown = true;
    
	public GameObject perola;
	public AudioSource sound;
    public bool isUp = false, achou = false;

    Vector3 objectUp, objectDown;

    float timeAt = 0, timeToFlip = 2f;

    void Start()
    {
        objectUp = new Vector3(transform.position.x + 0.20f, transform.position.y + 0.20f, transform.position.z);
        objectDown = transform.position;
        gameState.s2Clicavel = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeAt += Time.deltaTime;
        
        if (up)
        {
            animationUp();
        }
        if (down)
        {
            animationDown();
        }
        if (isUp && (timeAt >= timeToFlip) && !achou)
        {
            down = true;
            isUp = false;
        }
    }

    public void animationUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectUp, 1f * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, -20f), Time.deltaTime * 1f);
        if (Vector3.Distance(transform.position, objectUp) < 0.001f)
        {
            up = false;
            isUp = true;
		perola.SetActive(true);
		sound.Play();
        }
    }

    public void animationDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectDown, 1f * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * 6f);
        if ((Vector3.Distance(transform.position, objectDown) < 0.001f))
        {
            down = false;
            isDown = true;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameState.s2Clicavel)
            {
                if (isUp)
                {
                    down = true;
                    isUp = false;
                }
                else if (isDown)
                {
                    up = true;
                    isDown = false;
                    timeAt = 0;
                }
            }
        }
    }
}
