using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    GameObject player;
    Vector3 startPoint;
    Vector3 direction;
    
    public float speed;
    bool canMove = true;
    Animator anim;

    // Use this for initialization
    void Awake () {
        anim = GetComponentInChildren<Animator>();
        startPoint = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            float step = (speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            transform.LookAt(player.transform);
            if (transform.position.z == 0)
                transform.position = startPoint;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canMove = false;
            anim.SetBool("atack", true);
        }
    }
}
