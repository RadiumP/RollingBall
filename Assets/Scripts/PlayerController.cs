using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;

    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

	void FixedUpdate ()
    {
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHori, 0.0f, moveVert);

        rb.AddForce(movement * speed);
	}

     void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 5)
        {
            winText.text = "YOU WIN";
        }
    }
}
