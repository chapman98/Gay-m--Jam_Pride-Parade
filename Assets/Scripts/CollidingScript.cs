using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollidingScript : MonoBehaviour{
    [SerializeField] Collider2D player;

    // Start is called before the first frame update
    void Start() {
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //collision.gameObject.GetComponent(speed) = 0.0f;
        Debug.Log("Collide");
    }

    // Update is called once per frame
    void Update() {
        
    }
}
