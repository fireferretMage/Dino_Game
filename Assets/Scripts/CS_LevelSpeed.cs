using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_LevelSpeed : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    //[SerializeField] private GameObject _obj;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        //_obj.transform.localScale = CS_Spawner.spawnSize;

        _rb.AddForce(new Vector3(CS_Spawner.levelSpeed, 0f, 0f), ForceMode.Force);

        

        //Debug.Log(CS_Spawner.levelSpeed);
    }

    public void Update()
    {
        
    }

}
