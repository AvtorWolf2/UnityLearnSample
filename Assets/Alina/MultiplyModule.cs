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

    private bool done = false;

    public override void Use()
    {
        if (done == false)
        {
            for (int i = 0; i < Count; i++)
            {
                Instantiate(prefab, prefab.transform.position + new Vector3(0, 0, Step), Quaternion.identity, transform);
            }
            done = true;
        }
        
    }

    
}
