using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{

    public float minForce = 10.0f;
    public float maxForce = 15.0f;
    public float minTorque = -10.0f;
    public float maxTorque = 10.0f;
    public float minXPos = -3.00f;
    public float maxXPos = 3.00f;
    public float ySpawnPos = -2.00f;

    private Rigidbody targetRb;
    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem expParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        RandomForce();
        RandomTorque();
        RandomSpawnPos();

    }

    void RandomForce()
    {
        targetRb.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }

    void RandomTorque()
    {
        targetRb.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque,maxTorque), Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }

    void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(minXPos, maxXPos), ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.gameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(expParticle, transform.position, expParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Hazard"))
        {
            gameManager.GameOver();
        }
    }

}
