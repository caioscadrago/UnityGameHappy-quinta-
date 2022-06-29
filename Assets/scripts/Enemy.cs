using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D rig;
    public bool Grounded;
    public Transform groundcheck;
    public LayerMask layerchao;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundcheck.position,0.1f,layerchao);
        if(!Grounded)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1,1,1);
        }
        else
        {
            rig.velocity = new Vector2(speed*-1,rig.velocity.y);
        }
    }
}
