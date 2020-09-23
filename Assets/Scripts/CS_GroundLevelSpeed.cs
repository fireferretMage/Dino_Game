using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_GroundLevelSpeed : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private Rigidbody _rb;
    //[SerializeField] private GameObject _obj;

    static float offset;

    public CS_Spawner Spawner;
    float lastSpawnedTranslate;

    public void Awake()
    {

        //lastSpawnedTranslate = Spawner.lastSpawnedBoundsVector.x;

        _rb = GetComponent<Rigidbody>();
       // Collider col = GetComponent<Collider>();
       // col.enabled = false;

        

        _obj = this.gameObject;

        _obj.tag = "Platform";

       
        //_obj.transform.position = new Vector3(0.0f, this.gameObject.transform.position.x - lastSpawnedTranslate * 2, 0.0f) ;

        _rb.AddForce(new Vector3(CS_Spawner.levelSpeed, 0f, 0f), ForceMode.Force);

        //_obj.transform.localScale = CS_Spawner.spawnSize;

        //layermask is like tags but it will ignore things inside the that set layer https://www.youtube.com/watch?v=EINgIoTG8D4


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



        this.transform.position = new Vector3(Last.transform.position.x - offset, transform.position.y, transform.position.z);


    }

}
