﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
        CreateEnemy();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        enemy.transform.parent = gameObject.transform;
    }
}
