using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject animatedObj;

    List<GameObject> animatedObjects = new List<GameObject>();

    float animationSpeed = 2.0f;

    bool animationDone = false;

    // Start is called before the first frame update
    void Start()
    {
        float yCoord = 0.25f;
        for (int i = 0; i < 4; i++)
        {
            float xCoord = -1.25f;
            for (int j = 0; j < 16; j++)
            {
                var clone = Instantiate(animatedObj, new Vector3(-j + xCoord, i + yCoord, -8.5f), Quaternion.identity);
                animatedObjects.Add(clone);

                xCoord += 0.5f;
            }
            yCoord -= 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!animationDone)
        {
            //Debug.Log("I'm in if!");
            StartCoroutine(animateObject(true));
        }

        else
        {
            //Debug.Log("I'm in else!");
            StartCoroutine(animateObject(false));
        }
    }

    IEnumerator animateObject(bool way)
    {
        if (way)
        {
            foreach (var obj in animatedObjects)
            {
                if (obj.transform.position.z < -6.0f && obj.transform.localScale.z > 0.2f)
                {
                    obj.transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * animationSpeed;
                    obj.transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f) * Time.deltaTime * animationSpeed;
                }
                yield return new WaitForSeconds(0.01f);
            }

            animationDone = true;
            yield break;
        }

        else{
            foreach (var obj in animatedObjects)
            {
                if (obj.transform.position.z > -9.0f && obj.transform.localScale.z < 0.5f)
                {
                    obj.transform.position -= new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * animationSpeed;
                    obj.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f) * Time.deltaTime * animationSpeed;
                }
                yield return new WaitForSeconds(0.01f);
            }

            animationDone = false;
            yield break;
        }
    }
}
