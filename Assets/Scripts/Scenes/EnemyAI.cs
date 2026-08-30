using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public GameObject gegnerGo;
    public Rigidbody gegner;
    public GameObject playerPlaceholder;
    public Rigidbody player;
    public bool besiegt = false;
    public float range = 10f;
    public float moveSpeed = 3f;
    public Animator animator = null;
    public int delay;

    // Start is called before the first frame update
    void Start()
    {
        gegner = GetComponent<Rigidbody>();
        playerPlaceholder = GameObject.FindGameObjectWithTag("Player");
        player = playerPlaceholder.GetComponent<Rigidbody>();
        gegner = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        delay = 70;
    }

    // Update is called once per frame
    void Update()
    {   
        if(besiegt == false)
        {
            //Berechnet den Abstand zwischen Spieler und Gegner
            float distance = Vector3.Distance(gegner.transform.position, player.transform.position);
            if (distance < range)
            {
                if (distance > 3f)
                {
                    //Bewegt den Gegner auf den Spieler zu
                    var step = moveSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, player.position, step);

                    //Spieler anschauen
                    Vector3 lookAt = player.position;
                    lookAt.y = transform.position.y;
                    transform.LookAt(lookAt);

                    //Animation
                    animator.SetBool("Rennt", true);
                    animator.SetBool("GreiftAn", false);

                    //Debug.Log("In Reichweite - kommt näher");
                }
                else
                {
                    //Spieler anschauen
                    Vector3 lookAt = player.position;
                    lookAt.y = transform.position.y;
                    transform.LookAt(lookAt);

                    //Animation
                    animator.SetBool("Rennt", false);
                    animator.SetBool("GreiftAn", true);

                    //Hier Angriff einfügen
                    delay -= 1;
                    if (delay <= 0)
                    {
                        GameObject.Find("Spieler 2").GetComponent<PlayerController2>().playerHealth -= 10;
                        GameObject.Find("Spieler 2").GetComponent<PlayerController2>().healDelay = 200;
                        delay = 70;
                    }
                }
            }
            else
            {
                //Animation
                animator.SetBool("Rennt", false);
                animator.SetBool("GreiftAn", false);
            }
            if(gegnerGo.transform.position.y <= 1.5)
            {
                gegnerGo.SetActive(false);
            }
        }
    }
}