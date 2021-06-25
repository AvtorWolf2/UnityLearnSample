using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyModule : SampleScript
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    [Min(0)]
    [Tooltip("����������")]
    private int Count;

    [SerializeField]
    [Min(0)]
    [Tooltip("���")]
    private float Step;


    public override void Use()
    {
        for (int i = 0; i < Count; i++)
        {
            Instantiate(prefab,new  Vector3(0, 0, Step), Quaternion.identity , transform);
        }
    }

    
}
