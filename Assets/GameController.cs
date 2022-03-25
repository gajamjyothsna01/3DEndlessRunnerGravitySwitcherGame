using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playermovement;
    public Camera cam;
    public GameObject[] blockPrefabs;
    public float spawnPoint;
    public float safeMargin;
    //public PlatformController platformController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
            
        // Spawing the Platforms Randomly;
        int k = Random.Range(0, blockPrefabs.Length);
        if (spawnPoint < 5)
        {
            k = 0;
        }

        while (playermovement != null &&  spawnPoint < playermovement.transform.position.x + safeMargin)
        {
            GameObject currentPlatform = Instantiate(blockPrefabs[k], transform.position, Quaternion.identity);
            PlatformController platformController = currentPlatform.GetComponent<PlatformController>();
            currentPlatform.transform.position = new Vector3(spawnPoint + platformController.platformSize / 2, 0, 0);
            spawnPoint = spawnPoint + platformController.platformSize;
        }

        ////Camera follows the Player.
        if(playermovement!=null)
        {
            cam.transform.position = new Vector3(playermovement.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
        






    }
}
