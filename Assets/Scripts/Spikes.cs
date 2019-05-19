using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    static List<Spikes> s_Spikes = new List<Spikes>();

    public GameObject spikes;
    // Start is called before the first frame update
    void Start()
    {
       s_Spikes.Add(this);
    }

    private void Update()
    {
       
    }

    private void OnEnable()
    {
    }

    private void OnDestroy()
    {
        s_Spikes.Remove(this);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player encountered Spikes");
    }

    public static void Spikemove()
    {
        foreach (Spikes spike in s_Spikes)
        {
            spike.gameObject.SetActive((((int)Time.time / 2f) % 2) == 1);
        }
    }

 }
