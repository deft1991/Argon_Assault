using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform parent;
    [SerializeField] private int scorePerHit = 12;
    [SerializeField] private int healthPoints = 100;
    [SerializeField] private int healthPointsPerHit = 25;

    private ScoreBoard m_ScoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        m_ScoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnParticleCollision(GameObject other)
    {
        m_ScoreBoard.ScoreHit(scorePerHit);
        healthPoints -= healthPointsPerHit;
        if (healthPoints <= 0)
        {
            KillEnemy();
        }
        else
        {
            
        }
    }

    private void KillEnemy()
    {
        GameObject effect = Instantiate(deathFX, transform.position, Quaternion.identity);
        effect.transform.parent = parent;
        Destroy(gameObject);
    }
}