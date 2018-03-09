using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerForce : MonoBehaviour {

    Rigidbody rb;
    public float speed;

    public Text countText;

    public float count;

    public Vector3 Vector3 { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        updateCountText();
    }

    void FixedUpdate () {
        //called just before doing physics calculation

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement= new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement*speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        //OnTriggerEnter is called when the Collider other enters the trigger.

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            updateCountText();
        }
    }
        
    public void updateCountText()
    {
        countText.text = "Count : " + count.ToString();
    }
}
