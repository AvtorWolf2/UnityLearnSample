using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject animatedObj;

    List<GameObject> animatedObjects = new List<GameObject>();

    [SerializeField]
    [Min(1)]
    int wallHeight = 4;

    [SerializeField]
    [Min(1)]
    int wallWidth = 16;

    float animationSpeed = 1f;
    bool animationDone = false;

    float defaultObjScale;

    [SerializeField]
    [Min(0)]
    float targetObjScale = 0.2f;

    [SerializeField]
    Vector3 startGenerationCoordinates = new Vector3(-1.25f, 0.25f, -8.5f);

    void Start()
    {
        defaultObjScale = animatedObj.transform.localScale.x;
        var currentGenerationCoordinates = startGenerationCoordinates;
        for (int i = 0; i < wallHeight; i++)
        {
            for (int j = 0; j < wallWidth; j++)
            {
                var clone = Instantiate(animatedObj, 
                    new Vector3(
                        currentGenerationCoordinates.x, 
                        currentGenerationCoordinates.y, 
                        currentGenerationCoordinates.z
                    ), 
                    Quaternion.identity);

                animatedObjects.Add(clone);

                currentGenerationCoordinates.x -= defaultObjScale;
            }

            currentGenerationCoordinates.x = startGenerationCoordinates.x;
            currentGenerationCoordinates.y += defaultObjScale;
        }
    }


void Update()
{
    if (!animationDone)
    {
        StartCoroutine(animateObject(true));
    }

    else
    {
        StartCoroutine(animateObject(false));
    }
}

IEnumerator animateObject(bool way)
{
    if (way)
    {
        foreach (var obj in animatedObjects)
        {
            if (/*obj.transform.position.z < -6.0f &&*/ obj.transform.localScale.z > targetObjScale)
            {
                // obj.transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * animationSpeed;

                var scale = Time.deltaTime * animationSpeed;
                obj.transform.localScale -= new Vector3(scale, scale, scale);
            }

            // obj.transform.position = new Vector3(0.0f, 0.0f, -6.0f);
            // obj.transform.localScale = new Vector3(targetObjScale, targetObjScale, targetObjScale);

            yield return new WaitForSeconds(0.01f);
        }

        animationDone = true;
        yield break;
    }

    else
    {
        foreach (var obj in animatedObjects)
        {
            if (/*obj.transform.position.z > -9.0f &&*/ obj.transform.localScale.z < defaultObjScale)
            {
                // obj.transform.position -= new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * animationSpeed;

                var scale = Time.deltaTime * animationSpeed;
                obj.transform.localScale += new Vector3(scale, scale, scale);
            }

            // obj.transform.position = new Vector3(0.0f, 0.0f, -9.0f);
            // obj.transform.localScale = new Vector3(defaultObjScale, defaultObjScale, defaultObjScale);

            yield return new WaitForSeconds(0.01f);
        }

        animationDone = false;
        yield break;
    }
}
}
