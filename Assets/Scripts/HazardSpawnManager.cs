using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hazards;
    int randomhaz1, randomhaz2, randomhaz3, randomhaz4, randomhaz5, randomhaz6;
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

        /*
        hz7 = cp7.transform.position;
        hz8 = cp8.transform.position;
        hz9 = cp9.transform.position;
        hz10 = cp10.transform.position;
        */
        Debug.Log("Player position:" + curr_x + "," + curr_y + ".");
        BeginHazardSpawn();    

    }

    // Update is called once per frame
    void Update()
    {
        playerposition = GameObject.Find("Sisyphus").transform.position;
        curr_x = playerposition.x;
        curr_y = playerposition.y;
    }


    public void BeginHazardSpawn()
    {
        StartCoroutine(OilSpawnRoutine());
    }

    /*
    public IEnumerator HazardSpawnRoutine()
    {
        
        
        //while (gameManager.gameOver == false)
        //{
            Debug.Log("Starting Hazard Spawn Routine");
            int randomHazard = Random.Range(0, 1);
            randomx = Random.Range(leftlimit, rightlimit);
        // where to instantiate the hazard on the Y? X should be greater than the Players current location
            Instantiate(hazards[0], new Vector3(randomx, 8, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
            Debug.Log("Ending Power Up Spawn Routine");
        //}
        
    }
    */

    public IEnumerator OilSpawnRoutine()
    {
        Debug.Log("Starting Hazard Spawn Routine");
        randomhaz1 = Random.Range(0, 2);
        randomhaz2 = Random.Range(0, 2);
        randomhaz3 = Random.Range(0, 2);
        randomhaz4 = Random.Range(0, 2);
        randomhaz5 = Random.Range(0, 2);
        randomhaz6 = Random.Range(0, 2);

        Instantiate(hazards[randomhaz1], new Vector3(hz2.x, hz2.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz2], new Vector3(hz3.x, hz3.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz3], new Vector3(hz4.x, hz4.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz4], new Vector3(hz5.x, hz5.y, 0), Quaternion.identity);
        Instantiate(hazards[randomhaz5], new Vector3(hz6.x, hz6.y, 0), Quaternion.identity);

        yield return new WaitForSeconds(5.0f);
        Debug.Log("Ending Power Up Spawn Routine");
    }

    
}
