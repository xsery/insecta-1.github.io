using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    public float range;
    public Transform rayOrigin;
    public LineRenderer laser;

	// Use this for initialization
	void Start () {
        laser = GetComponent<LineRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < laser.positionCount; i++)
            laser.SetPosition(i, Vector3.zero);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, range))
        {
            //GameObject tempSpark = Instantiate (sparks, _hit.point, Quaternion.identity) as GameObject;
            //tempSpark.transform.SetParent (GameObject.Find("Spawn").transform);
            //tempSpark.GetComponent<ParticleSystem> ().Play ();
            
            laser.SetPosition(0, rayOrigin.position);
            laser.SetPosition(2, ((rayOrigin.position + _hit.point) / 2));
            laser.SetPosition(1, ((laser.GetPosition(2) + rayOrigin.position) / 2));
            laser.SetPosition(3, ((laser.GetPosition(2) + _hit.point) / 2));
            laser.SetPosition(4, _hit.point);

            if (_hit.collider.tag == ("Enemy"))
            {
                Destroy(_hit.collider.gameObject);
            }
            
        }
    }
}
