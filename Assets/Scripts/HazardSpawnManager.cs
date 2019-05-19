using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hazards;
    int randomhaz1, randomhaz2, randomhaz3, randomhaz4, randomhaz5, randomhaz6, randomhaz7, randomhaz8, randomhaz9, randomhaz10;
    float leftlimit, rightlimit;
    float curr_x, curr_y;
    Vector2 playerposition;

    [SerializeField]
    public GameObject player;


    [SerializeField]
    public GameObject cp1, cp2, cp3, cp4, cp5, cp6, cp7, cp8, cp9, cp10;

    public Vector2 hz1, hz2, hz3, hz4, hz5, hz6, hz7, hz8, hz9, hz10;

    
    // Start is called before the first frame update
    void Start()
    {
        // get player position 
        playerposition = GameObject.Find("Sisyphus").transform.position;
        curr_x = playerposition.x;
        curr_y = playerposition.y;

        //Get locations for each of the different checkpoints
        hz1 = cp1.transform.position;
        hz2 = cp2.transform.position;
        hz3 = cp3.transform.position;
        hz4 = cp4.transform.position;
        hz5 = cp5.transform.position;
        hz6 = cp6.transform.position;
        hz7 = cp7.transform.position;
        hz8 = cp8.transform.position;
        hz9 = cp9.transform.position;
        hz10 = cp10.transform.position;


        //Debug.Log("Player position:" + curr_x + "," + curr_y + ".");
        BeginHazardSpawn();    

    }

    // Update is called once per frame
    void Update()
    {
        playerposition = GameObject.Find("Sisyphus").transform.position;
        curr_x = playerposition.x;
        curr_y = playerposition.y;

        Spikes.Spikemove();
    }


    public void BeginHazardSpawn()
    {
        StartCoroutine(OilSpawnRoutine());
    }

    
public IEnumerator OilSpawnRoutine()
    {
        Debug.Log("Starting Hazard Spawn Routine");
        /*
        randomhaz1 = Random.Range(0, 2);
        randomhaz2 = Random.Range(0, 2);
        randomhaz3 = Random.Range(0, 2);
        randomhaz4 = Random.Range(0, 2);
        randomhaz5 = Random.Range(0, 2);
        randomhaz6 = Random.Range(0, 2);
        */

        // assign hazard to each hazard point
        randomhaz1 = 1;
        randomhaz2 = 1;
        randomhaz3 = 0;
        randomhaz4 = 2;
        randomhaz5 = 1;
        randomhaz6 = 0;
        randomhaz7 = 1;
        randomhaz8 = 2;
        randomhaz9 = 0;
        randomhaz10 = 1;


        Instantiate(hazards[randomhaz1], new Vector3(hz1.x, hz1.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz2], new Vector3(hz2.x, hz2.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz3], new Vector3(hz3.x, hz3.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz4], new Vector3(hz4.x, hz4.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz5], new Vector3(hz5.x, hz5.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz6], new Vector3(hz6.x, hz6.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz7], new Vector3(hz7.x, hz7.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz8], new Vector3(hz8.x, hz8.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz9], new Vector3(hz9.x, hz9.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz10], new Vector3(hz10.x, hz10.y, 0), Quaternion.identity);

        yield return new WaitForSeconds(5.0f);
        Debug.Log("Ending Power Up Spawn Routine");
    }

    
}
