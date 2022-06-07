using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform rays;
    public GameObject crystalEffect;

    private Rigidbody rb;
    private bool isWalkingRight = true;

    private Animator anim;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("gamestarted");
        }


        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            dir();
        }

        RaycastHit hit;
        
        if(!Physics.Raycast(rays.position, -transform.up , out hit , Mathf.Infinity))
        { 
            anim.SetTrigger("isfalling");
        }

        if(transform.position.y < -10)
        {
            gameManager.EndGame();
        }
    }

    private void dir()
    {
        if(!gameManager.gameStarted)
        {
            return;
        }

        isWalkingRight = !isWalkingRight;

        if(isWalkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            gameManager.IncreaseScore();

            GameObject g = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}