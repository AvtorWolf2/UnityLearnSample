using System.Collections.Generic;
using UnityEngine;

public class RunAllScripts : MonoBehaviour
{
    [SerializeField]
    List<SampleScript> objects = new List<SampleScript>();

    [ContextMenu("Запустить скрипты")]
    void runScripts()
    {
        foreach (var obj in objects)
        {
            obj.Use();
        }
    }
}
