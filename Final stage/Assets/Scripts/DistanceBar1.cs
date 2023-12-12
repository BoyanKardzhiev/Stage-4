using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBar1 : MonoBehaviour
{
    [SerializeField]
    DistanceBar DistanceBar;

    [SerializeField]
    GameObject FallingRock;
    public float speed;
    bool passedField;

    // Start is called before the first frame update
    void Start()
    {
        FallingRock = gameObject.transform.GetChild(0).gameObject;
        passedField = false;
    }

    void Update()
    {
        if(passedField)
        {
            if (FallingRock != null)
            {
                FallingRock.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            }
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something");
        if(other.gameObject.GetComponent<Camera>() != null)
        {
            DistanceBar.SetDistance(1);
            gameObject.GetComponent<MeshCollider>().enabled = false;

            passedField = true;
        }
    }
}
