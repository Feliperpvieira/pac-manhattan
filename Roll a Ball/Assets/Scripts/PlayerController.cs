using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    public GameObject DeathMenu, PointsScore;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        DeathMenu.SetActive(false);
        PointsScore.SetActive(true);

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = count.ToString();
       
        winText.text = count.ToString();
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            DeathMenu.SetActive(true);
            PointsScore.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
