using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevetor : MonoBehaviour
{
    public bool upperbound;
    public bool lowerbound;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localRotation = Quaternion.Euler(90 * speed * Time.deltaTime, transform.localRotation.y, transform.localRotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UpperBound")
        {
            Debug.Log("HelloUB");
            upperbound = false;
            lowerbound = false;
           // Invoke("ForUpperBound", 0.1f);
        }
        else if (other.gameObject.tag == "LowerBound")
        {
            Debug.Log("HelloLB");
            upperbound = false;
            lowerbound = false;
           // Invoke("ForLowerBound", 0.1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "UpperBound")
        {
            Debug.Log("HelloUB");
            upperbound = false;
            lowerbound = false;
            // Invoke("ForUpperBound", 0.1f);
        }
        else if (collision.gameObject.tag == "LowerBound")
        {
            Debug.Log("HelloLB");
            upperbound = false;
            lowerbound = false;
            // Invoke("ForLowerBound", 0.1f);
        }
    }

    public void ForUpperBound()
    {
        upperbound = true;
    }

    public void ForLowerBound()
    {
        lowerbound = true;
    }
}
