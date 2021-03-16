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

    //Spawn items:
    public GameObject ItemPrefab;
    public Vector3 center;
    public Vector3 size;


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

            if (count % 10 == 0)
            {
                SpawnItem();
                SpawnItem();
                SpawnItem();
                SpawnItem();
                SpawnItem();
                SpawnItem();
                SpawnItem();
                SpawnItem();
                SpawnItem();
                SpawnItem();
            }

            SetCountText();

            SpawnItem();
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

    public void SpawnItem()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(ItemPrefab, pos, Quaternion.identity);
    }

}
