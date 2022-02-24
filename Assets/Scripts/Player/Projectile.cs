using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed = 100;
    public Vector3 target;
    Rigidbody rigidbody;
    public GameObject Player;
    
    
    NearestEnemyBehaviour near;

    private void Awake()
    {

        rigidbody = this.GetComponent<Rigidbody>();

    }
    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);


        Player = GameObject.Find("Player");
        near = Player.GetComponent<NearestEnemyBehaviour>();
        Debug.Log(near+ " ,");
        
        
        //rigidbody = this.GetComponent<Rigidbody>();
        target = (near.nearestEnemy.transform.position - transform.position).normalized;
       
        rigidbody.AddForce(target * ProjectileSpeed);
        Destroy(this.gameObject, 4f);

    }



    // Update is called once per frame
    void Update()
    {
       
    }
}
