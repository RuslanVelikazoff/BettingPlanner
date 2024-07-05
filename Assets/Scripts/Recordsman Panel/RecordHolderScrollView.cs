using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class RecordHolderScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject recordPrefab;
    [SerializeField] 
    private Canvas canvas;

    [SerializeField] private int maxIndex = 4;

    private List<GameObject> recordList = new List<GameObject>();

    private DatabaseReference databaseReference;

    private void Awake()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SpawnPrefabs(GameData.TypeOfSport category)
    {
        for (int i = 0; i < maxIndex; i++)
        {
            StartCoroutine(LoadDataBase(category, i));
        }
    }

    public void ResetAllRecords()
    {
        if (recordList != null)
        {
            for (int i = 0; i < recordList.Count; i++)
            {
                Destroy(recordList[i]);
                recordList.RemoveAt(i);
                ResetAllRecords();
            }
        }
    }

    private IEnumerator LoadDataBase(GameData.TypeOfSport catergory, int index)
    {
        Debug.Log(catergory.ToString());
        var record = databaseReference.Child("Records")
            .Child(catergory.ToString())
            .Child(index.ToString()).GetValueAsync();

        yield return new WaitUntil(predicate: () => record.IsCompleted);

        if (record.Exception != null)
        {
            Debug.LogError(record.Exception);
        }
        else if (record.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = record.Result;
            SpawnNewsPrefabInScrollView(snapshot.Child("Name").Value.ToString(),
                snapshot.Child("Record").Value.ToString());
        }
    }

    private void SpawnNewsPrefabInScrollView(string nameText, string recordText)
    {
        var record = Instantiate(recordPrefab, transform.position, Quaternion.identity);
        record.transform.SetParent(canvas.transform);
        record.transform.localScale = new Vector3(1, 1, 1);
        record.transform.SetParent(this.gameObject.transform);
        record.GetComponent<RecordHolderPrefab>().SpawnPrefab(nameText, recordText);
        recordList.Add(record);
    }
}
