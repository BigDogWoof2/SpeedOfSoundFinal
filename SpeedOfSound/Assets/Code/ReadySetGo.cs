using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadySetGo : MonoBehaviour
{

    [SerializeField] public GameObject readySetGo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    // Update is called once per frame
    IEnumerator CountdownRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        readySetGo.GetComponent<Text>().text = "Ready";
        readySetGo.SetActive(true);

        yield return new WaitForSeconds(1f);
        readySetGo.SetActive(false);
        readySetGo.GetComponent<Text>().text = "Set";
        readySetGo.SetActive(true);

        yield return new WaitForSeconds(1f);
        readySetGo.SetActive(false);
        readySetGo.GetComponent<Text>().text = "Go";
        readySetGo.SetActive(true);

        yield return new WaitForSeconds(1f);
        readySetGo.SetActive(false);
    }
}
