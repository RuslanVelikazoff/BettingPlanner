using System.Collections.Generic;
using UnityEngine;

public class BetCategoryScrollView : MonoBehaviour
{
    [SerializeField] private GameObject betPrefab;
    
    [SerializeField] private Canvas canvas;

    private List<GameObject> bets = new List<GameObject>();
    private List<int> betIndex;

    public void SetScrollViewCategory(GameData.TypeOfSport category)
    {
        betIndex = MatchData.Instance.GetMatchCategoryIndexList(category);

        for (int i = 0; i < betIndex.Count; i++)
        {
            var bet = Instantiate(betPrefab, transform.position, Quaternion.identity);
            bet.transform.SetParent(canvas.transform);
            bet.transform.localScale = new Vector3(1, 1, 1);
            bet.transform.SetParent(this.gameObject.transform);
            bet.GetComponent<BetPrefab>().SpawnPrefab(betIndex[i]);
            bets.Add(bet);
        }
    }

    public void SetScrollViewSearch(string searchString)
    {
        betIndex = MatchData.Instance.GetSearchMatchIndexList(searchString);

        for (int i = 0; i < betIndex.Count; i++)
        {
            var bet = Instantiate(betPrefab, transform.position, Quaternion.identity);
            bet.transform.SetParent(canvas.transform);
            bet.transform.localScale = new Vector3(1, 1, 1);
            bet.transform.SetParent(this.gameObject.transform);
            bet.GetComponent<BetPrefab>().SpawnPrefab(betIndex[i]);
            bets.Add(bet);
        }
    }

    public void ResetAllMatches()
    {
        if (bets != null)
        {
            for (int i = 0; i < bets.Count; i++)
            {
                Destroy(bets[i]);
                bets.RemoveAt(i);
                ResetAllMatches();
            }
        }
    }
}
