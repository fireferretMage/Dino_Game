using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Mountain : MonoBehaviour
{

    [SerializeField] private GameObject _obj;
    [SerializeField] private Rigidbody _rb;

    static float offset;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _obj = this.gameObject;

        _obj.tag = "Destructible";

        _rb.AddForce(new Vector3(CS_Spawner.levelSpeed, 0f, 0f), ForceMode.Force);

    }

    public void InitMountain(GameObject Last)
    {
        if (Last == null)
        {
            return;

        }

        if (CS_Mountain.offset == 0f)
        {
            Collider otherCollider = Last.GetComponent<Collider>();

            CS_Mountain.offset = ((otherCollider.bounds.extents.x) * 2f);
        }



        this.transform.position = new Vector3(Last.transform.position.x - offset, transform.position.y, transform.position.z);


    }

}
