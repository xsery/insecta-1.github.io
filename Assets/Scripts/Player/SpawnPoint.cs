using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject enemy;
    public bool canSpawn;

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnEnemy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnEnemy()
    {
        while (canSpawn) {
            Instantiate(enemy, transform);
            yield return new WaitForSeconds(Random.Range(3, 6));
        }
    }
}
