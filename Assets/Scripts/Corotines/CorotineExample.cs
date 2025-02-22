using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorotineExample : MonoBehaviour
{

    private void Start()
    {
        WaitThenPrint();
        NowPrint();
        StartCoroutine(ParentCorutine());

    }
    private IEnumerable WaitThenPrint()
    {
        yield return new WaitForSeconds(2f);
        print("Hi");
    }

    private void NowPrint()
    {
        print("Hi");
    }


    IEnumerator ParentCorutine()
    {
        Debug.Log("starting first task...");
        yield return StartCoroutine(ChildCoroutine());
        Debug.Log("First task complete, continuing");
    }

    IEnumerator ChildCoroutine()
    {
        Debug.Log("Running child task...");

        yield return new WaitForSeconds(2f);

        Debug.Log("Child task done");
    }
}
