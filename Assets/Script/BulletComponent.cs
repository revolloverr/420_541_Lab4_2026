using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletComponent : MonoBehaviour
{

    void Start()
    {
        // Destroy object after a few seconds
        Destroy(gameObject, 5f);
    }
}
