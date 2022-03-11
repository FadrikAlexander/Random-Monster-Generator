using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script to select a part from the parts list
public class MonsterPartSelector : MonoBehaviour
{
    [SerializeField] List<GameObject> monsterPartList;

    private void OnEnable()
    {
        foreach (var v in monsterPartList)
            v.SetActive(false);

        monsterPartList[Random.Range(0, monsterPartList.Count)].SetActive(true);
    }
}
