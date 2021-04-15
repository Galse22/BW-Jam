using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;

    public string nameUUID;
}
public class ObjectPooler : MonoBehaviour {
    public static ObjectPooler SharedInstance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    void Awake () {
        SharedInstance = this;
    }

    void Start () {
        pooledObjects = new List<GameObject> ();
        foreach (ObjectPoolItem item in itemsToPool) {
            for (int i = 0; i < item.amountToPool; i++) {
                GameObject obj = (GameObject) Instantiate (item.objectToPool);
                obj.name = item.nameUUID;
                obj.SetActive (false);
                pooledObjects.Add (obj);
            }
        }
    }

    public GameObject GetPooledObject (string stringFunc) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].name == stringFunc) {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool) {
            if (item.objectToPool.name == stringFunc) {
                if (item.shouldExpand) {
                    GameObject obj = (GameObject) Instantiate (item.objectToPool);
                    obj.name = item.nameUUID;
                    obj.SetActive (false);
                    pooledObjects.Add (obj);
                    return obj;
                }
            }
        }
        return null;
    }

}