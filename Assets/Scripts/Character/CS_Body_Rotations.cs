using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CS_Body_Rotations : MonoBehaviour
{
    public GameObject Right_Leg;
    public GameObject Left_Leg;
    //GameObject go_Collider;

    public float speed = 6f;
    public float maxRotation = 30f;

    public float start_Rotation = 33f;
    public float Leg_Rotation_Speed = 25f;



    void Awake()
    {
        //Right_Leg = GameObject.Find("Dino_Right_Leg");
        //Left_Leg = GameObject.Find("Dino_Right_Leg");
        //go_Collider = GameObject.Find("Collider");
    }


    
    void Start()
    {
        Right_Leg.transform.Rotate(0, 0, start_Rotation);
        Left_Leg.transform.Rotate(0, 0, start_Rotation + 180);
    }


    void Update()
    {
        Right_Leg.transform.Rotate(0, 0, 50 * Time.deltaTime * Leg_Rotation_Speed);
        Left_Leg.transform.Rotate(0, 0, 50 * Time.deltaTime * Leg_Rotation_Speed);

        transform.rotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * speed), 0f, 0f);
        //go_Collider.transform.rotation = Quaternion.Euler( 0f , 0f, 0f);


    }


}
