using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    private const float SpawnRate = 2.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            UpdateScore(1);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }

    private void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        scoreText.text = "Score: " + score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
