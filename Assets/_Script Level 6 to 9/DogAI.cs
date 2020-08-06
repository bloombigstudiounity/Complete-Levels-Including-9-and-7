using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody _rigidbody;
    public Collider _collider;
    public Animator _animator;
    public bool lookleft;
    public bool lookright;
    public float speed;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lookright)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z - (Time.deltaTime * speed));
            this.transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180, transform.localRotation.z);
            //SetAnimatorState(0);
        }
        else if (lookleft)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z + (Time.deltaTime * speed));
            this.transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0, transform.localRotation.z);
            // SetAnimatorState(0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DogLeft")
        {
            lookleft = false;
            lookright = true;
        }
        else if (other.gameObject.tag == "DogRight")
        {
            lookright = false;
            lookleft = true;
        }
    }
}
