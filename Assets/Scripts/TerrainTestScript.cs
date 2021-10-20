using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTestScript : MonoBehaviour
{
    [SerializeField]
    GameObject prefabObject;//!<GameObject prefab containing the terrain
    Terrain prefabTerrain;//!<The terrain component of the prefab
    Terrain currentTerrain;//!<The current terrain component
    // Start is called before the first frame update
    void Start()
    {
        //Default terrain size is 1000x1000
        currentTerrain = gameObject.GetComponent<Terrain>();
        Instantiate(prefabObject, new Vector3(-1000,0,0), Quaternion.identity);//!<Create the object holding the terrain
        prefabTerrain = prefabObject.GetComponent<Terrain>();//!<Get the terrain component
        currentTerrain.SetNeighbors(prefabTerrain, null, null, null);//!<Set the neighbours (Neighbour in a purely logical sense, possibly used to texture mapping and rendering)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
