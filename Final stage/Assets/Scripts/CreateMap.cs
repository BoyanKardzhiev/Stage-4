using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.UI;
using TMPro;



public class CreateMap : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    List<GameObject> PlacebleObjects = new List<GameObject>();

    [SerializeField]
    List<GameObject> FoundObjects = new List<GameObject>();

    //[SerializeField]
    //GameObject building;

    Camera arCam;
    GameObject spawnedObject;
    GameObject spawnablePrefab;

    public int objectNumber;

    [SerializeField]
    TextMeshProUGUI goldText;
    int amountFound;
    // Start is called before the first frame update
    void Start()
    {

        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();

        objectNumber = 0;
        amountFound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //spawnablePrefab = PlacebleObjects[objectNumber];
        amountFound = Mathf.Clamp(amountFound, 0, 20);
        goldText.text = amountFound + "/20";

        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Collectable")
                    {
                        //foundNumber = hit.collider.gameObject.GetComponent<FoundObject>().obj.CollectableNumber;
                        //FoundObjects[foundNumber].SetActive(true);

                        SetAmount(1);
                        Destroy(hit.collider.gameObject);
                    }
                    else if (hit.collider.gameObject.tag == "Breakable")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        //for(int i=0; i<amountFound; i++)
        //{
        //    building.transform.GetChild(i).gameObject.SetActive(true);
        //}
    }

    private void SpawnPrefab(Vector3 spawnPosition, Quaternion rotation)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, rotation);
    }

    public void ChangeObjectNumber(int change)
    {
        objectNumber = change;
    }

    public void ChangeFoundAmount(int change)
    {
        //for (int i = 0; i < amountFound; i++)
        //{
       //    building.transform.GetChild(i).gameObject.SetActive(false);
        //}

        amountFound = amountFound + change;
    }

    public void SetAmount(int amount)
    {
        amountFound = amountFound + amount;
    }
}

