using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapMouse : MonoBehaviour {

    Collider coll;
    Renderer rend;
    public Color highlightColor;
    public Color normalColor;

    private void Start()
    {
        coll = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (coll.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            rend.material.color = highlightColor;
            int x = (int) hitInfo.point.x;
            int z = (int)hitInfo.point.z;
        }
        else {
            rend.material.color = normalColor;
        }


	}
}
