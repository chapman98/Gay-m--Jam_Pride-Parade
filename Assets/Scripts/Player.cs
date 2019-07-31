using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Vector2 minScreenBounds;
    private Vector2 maxScreenBounds;
    private float playerWidth;
    private float playerHeight;
    [SerializeField] private float speed = 100.0f;
    [SerializeField] private Rigidbody2D rb_body;

    void Start()
    {
        rb_body = gameObject.GetComponent<Rigidbody2D>();
        playerHeight = this.GetComponent<SpriteRenderer>().bounds.size.y/2;
        playerWidth = this.GetComponent<SpriteRenderer>().bounds.size.x/2;
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //Debug.Log("min screen pos = ("+ minScreenBounds[0] + "," + minScreenBounds[1] + ")" + "max screen pos = (" + maxScreenBounds[0] + "," + maxScreenBounds[1] + ")");
    }

    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("Collide");
        
    }
    
    private void Move()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && rb_body.position.y < (maxScreenBounds.y - playerHeight)) {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && rb_body.position.y > (minScreenBounds.y + playerHeight))
        {
            transform.Translate((new Vector3(0, -speed, 0) * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && rb_body.position.x > (minScreenBounds.x + playerWidth)) {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
        else if ((Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && rb_body.position.x < (maxScreenBounds.x - playerWidth)) {
            
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }
    }
}