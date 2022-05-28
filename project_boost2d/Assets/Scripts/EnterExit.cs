using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExit : MonoBehaviour
{
    public GameObject StartEnabled;
    public GameObject StartDisabled;
    // V_Switch
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touch Me");
        StartEnabled.SetActive(false);
        StartDisabled.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Not touching you");
        StartEnabled.SetActive(true);
        StartDisabled.SetActive(false);
    }
}
