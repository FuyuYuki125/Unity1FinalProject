using UnityEngine;
using UnityEngine.InputSystem;

public class spawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float upperBound = 7.5f; // you can edit this to change bounds :D
    public float lowerBound = -7.5f;
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandom", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandom()
    {
        int enemy = Random.Range(0, enemyPrefabs.Length); // this is for if we have multiple bird models
        GameObject clone = Instantiate(enemyPrefabs[enemy], new Vector3(Random.Range(lowerBound, upperBound), 0, 7), enemyPrefabs[enemy].transform.rotation); // You can move Random.Range to z if the plane is facing a diff direction
        clone.transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        if (clone.transform.position.z < lowerBound)
        {
            Destroy(clone);
        }
        Collider col = clone.AddComponent<BoxCollider>();
        col.isTrigger = true;
        Rigidbody rb = clone.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
}
