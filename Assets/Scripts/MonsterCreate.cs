using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    GameObject monster;

    public string str;
    public int minX, maxX, minZ, maxZ;
    public GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        monster = Resources.Load<GameObject>(str);
        InvokeRepeating("Create", 2, 2);
    }
    
    public void Create()
    {
        GameObject clone = Instantiate(monster);

        int MonsterNum = Random.Range(0, 3);
        for(int i = 0; i < MonsterNum; i++)
        {
            float x = Random.Range(minX, maxX), z = Random.Range(minZ, maxZ);
            clone.transform.position = new Vector3(x, 30, z);
        }
    }
}
