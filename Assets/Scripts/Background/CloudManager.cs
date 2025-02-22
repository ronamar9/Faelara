using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject[] newCloud;
    private Transform firstPos;

    private void Start()
    {

        StartCoroutine(CreateNewCloud());
    }

    IEnumerator CreateNewCloud()
    {
        while (true)
        {
            float waitTime = Random.Range(4f, 8f);
            float startX = -20;
            float desiredY = Random.Range(2, 6);
            float desiredZ = 50;

            yield return new WaitForSeconds(waitTime);
            int randomIndex = Random.Range(0, newCloud.Length);
            GameObject cloud = Instantiate(newCloud[randomIndex], transform);
            cloud.transform.localPosition = new Vector3(startX, desiredY, desiredZ);
        }
    }

}
