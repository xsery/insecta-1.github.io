using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUp : MonoBehaviour {

    private Rigidbody rb;
    private Transform tr;
    public float forcaPulo;
    private float num;

    private bool estaNoChao;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        estaNoChao = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (estaNoChao == false)
        {
            estaNoChao = true;
            StartCoroutine("pulo");
        }
    }

    IEnumerator pulo()
    {
        num = Random.Range(0.1f, 3f);
        rb.AddForce(tr.up * forcaPulo);
        yield return new WaitForSeconds(num);
        estaNoChao = false;
    }

}
