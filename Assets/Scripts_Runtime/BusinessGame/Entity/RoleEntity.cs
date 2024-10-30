using System;
using System.Collections.Generic;
using UnityEngine;


public class RoleEntity : MonoBehaviour
{


    public int id;


    public void Ctor()
    {

    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void TearDown()
    {
        Destroy(gameObject);
    }
}