using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> parentsPos;
    public GameObject enemy;
    public float respawmTime = 1f;
    public GameOverScreen gameOverScreen;


    // Start is called before the first frame update
    public void Start()
    {       
        StartCoroutine(EnemyWave());
    }

    private void SpawnEnemy()
    {
        GameObject a = Instantiate(enemy) as GameObject;
        a.transform.SetParent(parentsPos[Random.Range(0, parentsPos.Count - 1)].gameObject.transform, false);
        a.transform.localScale = new Vector3(10, 10, 1);
    }

    IEnumerator EnemyWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawmTime);
            SpawnEnemy();
        }
    }

    public void GameOver()
    {
        PlayerMovement.controllable = false;
        gameOverScreen.SetUp(ScoreScript.scoreValue);
        StopAllCoroutines();
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("Game");
    }
}
