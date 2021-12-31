using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 5;
    public int HitPoints
    {
        get { return hitPoints; }
        set { hitPoints = value; }
    }
   

    ScoreBoard scoreBoard;
    GameObject parentGameObject;
    
    

    protected void Start()
    {
        AddRigidbody();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnManager");
    }

    protected void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    protected void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (HitPoints < 1)
        {
            DestroyEnemy();
        }
        
    }

    protected virtual void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        HitPoints--;
        
    }

   protected void DestroyEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

   
}
