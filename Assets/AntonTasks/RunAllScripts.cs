using System.Collections.Generic;
using UnityEngine;

public class RunAllScripts : MonoBehaviour
{
    [SerializeField]
    List<Transform> objects = new List<Transform>();

    [ContextMenu("Запустить скрипты")]
    void runScripts()
    {
        foreach (var obj in objects)
        {
            SampleScript script = obj.GetComponent<SampleScript>();
            script.Use();
        }
    }

}
