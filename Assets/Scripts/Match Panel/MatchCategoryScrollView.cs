using System.Collections.Generic;
using UnityEngine;

public class MatchCategoryScrollView : MonoBehaviour
{
    [SerializeField] private GameObject matchPrefab;
    
    [SerializeField] private Canvas canvas;

    private List<GameObject> matches = new List<GameObject>();
    private List<int> matchIndex;

    public void SetScrollViewCategory(GameData.TypeOfSport category)
    {
        matchIndex = MatchData.Instance.GetMatchCategoryIndexList(category);

        for (int i = 0; i < matchIndex.Count; i++)
        {
            var match = Instantiate(matchPrefab, transform.position, Quaternion.identity);
            match.transform.SetParent(canvas.transform);
            match.transform.localScale = new Vector3(1, 1, 1);
            match.transform.SetParent(this.gameObject.transform);
            match.GetComponent<MatchPrefab>().SpawnPrefab(matchIndex[i]);
            matches.Add(match);
        }
    }

    public void SetScrollViewSearch(string searchString)
    {
        matchIndex = MatchData.Instance.GetSearchMatchIndexList(searchString);

        for (int i = 0; i < matchIndex.Count; i++)
        {
            var match = Instantiate(matchPrefab, transform.position, Quaternion.identity);
            match.transform.SetParent(canvas.transform);
            match.transform.localScale = new Vector3(1, 1, 1);
            match.transform.SetParent(this.gameObject.transform);
            match.GetComponent<MatchPrefab>().SpawnPrefab(matchIndex[i]);
            matches.Add(match);
        }
    }

    public void ResetAllMatches()
    {
        if (matches != null)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                Destroy(matches[i]);
                matches.RemoveAt(i);
                ResetAllMatches();
            }
        }
    }
}
