using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed = 100;
     public Vector3 target;
    Rigidbody rigidbody;
    public GameObject Player;
    public Transform near;

    private void Awake()
    {

        rigidbody = this.GetComponent<Rigidbody>();

    }
    private void Start()
    {
        
    
    
        Player = GameObject.Find("Player");
        near = Player.GetComponent<NearestEnemyBehaviour>().nearestEnemy;
        
        
        //rigidbody = this.GetComponent<Rigidbody>();
        target = (near.position - Player.transform.position);
       
        rigidbody.AddForce(target * ProjectileSpeed);
        Destroy(this.gameObject, 4f);

    }



    // Update is called once per frame
    void Update()
    {
       
    }
}
