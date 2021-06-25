using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YExampleScript : SampleScript
{
    [SerializeField]
    private float cx = 1;

    [SerializeField]
    private float cy = 1;

    [SerializeField]
    private float cz = 1;

    [SerializeField]
    private float speed = 1;

    /*private void Update()
    {
        Use();
    }

    [ContextMenu("Go")]
    public void Go()
    {
        StartCoroutine(Inf());
    }

    [ContextMenu("Stop")]
    public void Stop()
    {
        StopAllCoroutines();
    }*/

    public override void Use()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(cx, cy, cz) * speed * Time.deltaTime);
    }

    /*private IEnumerator Inf()
    {
        float t = 0;
        while (t == 0)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(cx, cy, cz) * speed * Time.deltaTime);
            yield return null;
        }
        
    }*/

}
