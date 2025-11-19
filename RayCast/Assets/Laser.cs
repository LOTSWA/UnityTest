using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{
    LineRenderer laserLine;
    public GameObject weaponAnchor;
    // Start is called before the first frame update
    void Start()
    {
        //weaponAnchor = transform.Find("WeaponAnchor").gameObject;

        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += x * Time.deltaTime * 30;
        pos.y += y * Time.deltaTime * 30;
        transform.position = pos;


        if (Input.GetMouseButtonDown(0))
        {
            laserLine.enabled = true;
            Ray ray = new Ray(weaponAnchor.transform.position, Vector3.up);

            RaycastHit hit;
            laserLine.SetPosition(0, ray.origin);


            if (Physics.Raycast(ray, out hit, 100))
            {
                laserLine.SetPosition(1, hit.point);
                print(hit.collider.gameObject.name);
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;

            }
            else
            {
                laserLine.SetPosition(1, ray.GetPoint(10));
            }

        
        }
        else
        {
            laserLine.enabled = false;
        }
    }
}