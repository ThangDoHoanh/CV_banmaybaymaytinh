using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    Dictionary<GameObject,List<GameObject>> _listObject = new Dictionary<GameObject,List<GameObject>>();
    public GameObject GetObject(GameObject defaultPrefab)
    {

        if (!_listObject.ContainsKey(defaultPrefab))
        {
            // Nếu khóa không tồn tại, tạo một List mới và thêm vào Dictionary
            _listObject.Add(defaultPrefab, new List<GameObject>());
        }

        foreach (GameObject a in _listObject[defaultPrefab])
        {
            if (!a.activeSelf)
            {
                // Nếu tìm thấy một đối tượng không hoạt động, trả về nó
                return a;
            }
        }

        // Nếu không tìm thấy đối tượng không hoạt động, tạo một đối tượng mới
        GameObject b = Instantiate(defaultPrefab, this.transform.position, Quaternion.identity,this.transform.parent=this.transform);
        _listObject[defaultPrefab].Add(b);
        b.SetActive(false);
        return b;
    }
    public void DesTroychild()
    {
        foreach (Transform child in transform)
        {
            // Kiểm tra nếu đối tượng con không phải là cha
            if (child != transform)
            {
                // Vô hiệu hóa đối tượng con
                child.gameObject.SetActive(false);
            }
        }
    }    
}
