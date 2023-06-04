using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public BoxCollider2D bc;

    public float shootSpeed = 2.5f;
    public float timer = 0f;
    public Vector2 vel;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        timer += 1f * Time.deltaTime;
        Debug.Log(timer);

        if (timer >= 1.5)
        {
            Destroy(this.gameObject);
        }
    }

    public void Shoot(Vector2 direction)
    {
        vel = direction * shootSpeed;
        rb2d.velocity = vel;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Character") 
        {
            Rigidbody2D player = other.GetComponent<Rigidbody2D>();
            player.AddForce(vel * 300);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}