using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    private Vector3 startSwipe, endSwipe;
    private float timeWhenInAir, timeWhenStartedFlying;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            startSwipe = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endSwipe = Input.mousePosition;
            Swipe();
        }
	}
    void Swipe()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        Debug.Log("swipe action"); 
        Vector3 swipe = endSwipe - startSwipe;
        rb.AddForce(swipe*0.04f, ForceMode.Impulse);
        rb.AddTorque(0.0f, 0.0f, -20, ForceMode.Impulse);
        timeWhenStartedFlying = Time.time;
    }
    private void OnTriggerEnter(Collider other)
    {
        rb.isKinematic = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        timeWhenInAir = Time.time - timeWhenStartedFlying;
        if(!rb.isKinematic && timeWhenInAir >= 0.01f)
        Debug.Log("Failed");
    }
}
