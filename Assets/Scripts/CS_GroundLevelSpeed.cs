using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_GroundLevelSpeed : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private Rigidbody _rb;
    //[SerializeField] private GameObject _obj;
    static float offset;


    public void Awake()
    {
        
        this.tag = "Destructible";

                       
        _rb = GetComponent<Rigidbody>();
       // Collider col = GetComponent<Collider>();
       // col.enabled = false;

        _rb.AddForce(new Vector3(CS_Spawner.levelSpeed, 0f, 0f), ForceMode.Force);

        _obj = this.gameObject;

        //_obj.transform.localScale = CS_Spawner.spawnSize;

        //layermask is like tags but it will ignore things inside the that set layer https://www.youtube.com/watch?v=EINgIoTG8D4

        //RaycastHit hit;
        //Vector3 spawnedPosition = transform.position;

        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
        //{
        //    try
        //    {
        //        if (hit.collider.tag == "Destructible")
        //        {
        //            Debug.Log(hit.transform.position); 
        //            this.transform.position = Vector3.MoveTowards(spawnedPosition, hit.transform.position, 0f) - new Vector3(0f, 0f, 0f);
        //        }
               

        //    } catch
        //    {
        //        Debug.Log(hit.transform);

        //    }

          

        //}
        //Debug.Log(CS_Spawner.levelSpeed);


       // col.enabled = true;

    }

    public void Init(GameObject Last)
    {
        if (Last == null)
        {
            return;

        }

        if (CS_GroundLevelSpeed.offset == 0f)
        {
            Collider otherCollider = Last.GetComponent<Collider>();

            CS_GroundLevelSpeed.offset = ((otherCollider.bounds.extents.x) * 2f);
        }
        
        
        
        this.transform.position = new Vector3 (Last.transform.position.x + offset, transform.position.y, transform.position.z);


    }

}
