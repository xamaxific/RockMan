using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    [SerializeField]
    public GameObject boulder;
    public Rigidbody2D rb;
    public float temp_mass;

    // Start is called before the first frame update
    void Start()
    {
        temp_mass = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // if x position of the player is greater than current position of the hazard, destroy hazard
        /*
        if (transform.position.y > 6)
        {
          if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player encountered Oil");
        // reduce player max push by half 
        // find boulder object
        boulder = GameObject.Find("Boulder");
        rb = boulder.GetComponent<Rigidbody2D>();
        rb.mass = temp_mass;
        Debug.Log("Boulder mass reduced to " + rb.mass);

    }


}
