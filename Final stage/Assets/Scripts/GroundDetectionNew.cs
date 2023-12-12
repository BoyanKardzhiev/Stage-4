using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetectionNew : MonoBehaviour
{
    [SerializeField]
    CreateMap goldAmountScript;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something else");
        if (other.tag == "Breakable")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("RockFallen");
            goldAmountScript.SetAmount(-1);
            //Destroy(other.gameObject);
        }
    }
}
