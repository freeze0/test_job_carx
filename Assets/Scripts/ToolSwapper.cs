using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwapper : MonoBehaviour
{
    [SerializeField] private GameObject[] toolPrefabs;
    [SerializeField] private GameObject[] dummies;

    public void SwapTools()
    {
        Debug.Log("Swaping Tools");
        for (int i = 0; i < dummies.Length; i++)
        {
            var _tool = GetChildByTag(dummies[i]);
            
        }
    }

    private GameObject GetRandomTool() //�� ����������� ������ � ��������� ������ ��-�� ���� ����� ���������� �� ��� ��
    {
        Debug.Log("Got random tool");
        int index = Random.Range(0, toolPrefabs.Length);
        var prefab = toolPrefabs[index];
        return prefab;
    }

    private GameObject GetChildByTag(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            //if (child.tag == "Tool") //�� ������� ���� 
            //{
                Debug.Log($"{child.name}"); //�������� ������ �� DummyMesh 
                //Debug.Log("Found child by tag");
                return child.gameObject;
            //}
        }
        Debug.Log("By tag returned null");
        return null;
    }
}
