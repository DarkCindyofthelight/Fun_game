using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{


    public BallController ballController;

    public float speed;
    public float minDirection = 0.5f;
       
    private Vector3 direction;
    private Rigidbody rb;

    private bool stopped = true;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
      
                        
    }

    public void ReturnToCenter()
    {
        transform.position = new Vector3(0.2f, 0, 0.4f);

    }

    void Update()
    {
        //essaye1
        //transform.position += direction * speed * Time.deltaTime;
        //a exploser

    }

    private void FixedUpdate()
    {
        if (stopped)
            return;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
        }

       if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;

        }

       
    }
      

    private void ChooseDirection()
    {

        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);

    }

    public void Stop()
    {
        this.stopped = true;

    }

    public void Go()
    {
        ChooseDirection();
        this.stopped = false;

    }

}
