using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.VersionControl;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0f, 0f);
    protected Rigidbody2D rid2D;
    public float pressHori = 0f;
    public float pressVerti = 0f;
    public float speedUp = 0.5f;
    public float speedDown = 0.5f;
    public float speedMax = 4f;
    public float speedHorizontal = 3f;

    private void Awake()
    {
        this.rid2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        this.pressHori = Input.GetAxis("Horizontal");
        //this.pressVerti = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        if (Linker.isStopped == false)
        {
            this.updateSpeed();
        }

    }
    protected virtual void updateSpeed()
    {
        this.velocity.x = this.pressHori * speedHorizontal;
        this.updateSpeedUp();
        //this.updateSpeedDown();


        if (this.velocity.y > this.speedMax) this.velocity.y = this.speedMax;

        this.rid2D.MovePosition(this.rid2D.position + this.velocity * Time.deltaTime);
    }
    protected virtual void updateSpeedUp()
    {
        if (this.pressVerti > 0)
        {
            this.velocity.y += this.speedUp;
            if (transform.position.x < -7 || transform.position.x > 7)
            {
                this.velocity.y -= 1f;
                if (this.velocity.y < 3f) this.velocity.y = 3f;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Police")
        {
            Destroy(other.gameObject);
            
        }
        
    }
    //protected virtual void updateSpeedDown()
    //{
    //    if (this.pressVerti == 0)
    //    {
    //        this.velocity.y -= this.speedDown;
    //        if (this.velocity.y < 0) this.velocity.y = 0;
    //    }
    //}
}
