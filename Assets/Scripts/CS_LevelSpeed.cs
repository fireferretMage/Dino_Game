using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_LevelSpeed : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _obj;
    public CS_Spawner Spawner;

    public void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _obj = this.GetComponent<GameObject>();

        float boundsFloat = Spawner.lastSpawnedBoundsVector.x;

        //_obj.transform.localScale = CS_Spawner.spawnSize;
        if (Spawner.groundCounter >= 1)
        {
            _obj.transform.position = _obj.transform.position - Spawner.lastSpawnedBoundsVector * 2;

        }
        

        _rb.AddForce(new Vector3(CS_Spawner.levelSpeed, 0f, 0f), ForceMode.Force);

        

        //Debug.Log(CS_Spawner.levelSpeed);
    }
}
