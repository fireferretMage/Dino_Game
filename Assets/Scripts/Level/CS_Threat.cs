using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CS_Threat : MonoBehaviour
{

    [SerializeField] private GameObject _obj;
    [SerializeField] private Rigidbody _rb;
    public CS_Spawner Spawner;

    private System.Random randomThreatsize = new System.Random();

    public float minThreatSize = 0.6f;
    public float maxThreatSize = 1.5f;

    public float threatsize;

    Vector3 threatsizeConfirmed;

    //CS_Score Score;

    // Start is called before the first frame update
    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _obj = this.gameObject;

        _obj.tag = "Destructible";

        //maxThreatSize = Score.maxThreatSize;

        threatsize = (UnityEngine.Random.Range(minThreatSize, maxThreatSize));
        threatsize = threatsize - 1f;

        if (threatsize <= 0.5f)
        {
            Destroy(_obj.GetComponent<BoxCollider>());
        }
        else { }

        threatsizeConfirmed = new Vector3 (threatsize, threatsize, threatsize);

        //UnityEngine.Random.Range(minThreatSize, maxThreatSize);


        _obj.transform.localScale = threatsizeConfirmed;

        _rb.AddForce(new Vector3(CS_Spawner.levelSpeed, 0f, 0f), ForceMode.Force);




    }

    public void OnTriggerEnter(Collider col) //trigger events 
    {


        if (col.tag == "Player")
        {

            SceneManager.LoadScene("Dino Run");

        }

    }


}
