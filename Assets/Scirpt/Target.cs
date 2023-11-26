using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float minForce = 10f;
    private const float maxForce = 15f;
    private const float minTorque = -10f;
    private const float maxTorque = 10;
    private const float minXPos = -3;
    private const float maxXPos = 3;
    private const float ySpawnPos = -2;
    private Rigidbody targetRB;
    private GameManager gameManager;
    public int pointValue;

    public ParticleSystem expParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRB= GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        RandomForce();
        RandomTorque();
        RandomSpawnPos();
    }

    void RandomForce()
    {
        targetRB.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }

    void RandomTorque()
    {
        targetRB.AddForce(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }

    void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(minXPos, maxXPos), ySpawnPos);
    }

    private void OnMouseDown()
    {
        gameManager.UpdateScore(pointValue);
        Instantiate(expParticle,transform.position, expParticle.transform.rotation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
