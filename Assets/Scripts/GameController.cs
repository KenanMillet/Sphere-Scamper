using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text winText;
    public string startText = "Avoid the balls and collect 10 squares!";
    public string tryAgainText = "Try Again?";
    public string winMessage = "You Win!";
    public string loseMessage = "You Lose!";
    private int score;
    public int scoreWinValue;

    public GameObject tryAgainButton;
    public GameObject quitButton;

    public GameObject player;

    public GameObject groundSpawn;

    public AudioSource victory;
    public AudioSource death;
    public AudioSource collect;
    public AudioSource music;

    private Vector3 playerStart = new Vector3(0, 0.5f, 0);

    private Vector3 stop = new Vector3(0, 0, 0);

    [Serializable]
    public struct VillainSpawn
    {
        public int scoreTrigger;
        public VillainController villain;
        public Vector3 spawnPoint;
    }

    public VillainSpawn[] villains;





    // Use this for initialization
    private void Start () {

        foreach (VillainSpawn vs in villains)
        {
            vs.villain.gameObject.SetActive(false);
        }
        player.SetActive(false);


        tryAgainButton.GetComponentInChildren<Text>().text = "Start!";

        winText.text = startText;
    }
	
	// Update is called once per frame
	void Update() {
		
	}

    private void UpdateScorePanelText()
    {
        scoreText.text = "Score: " + score + "/ " + scoreWinValue + Environment.NewLine + "Has Powerup: " + player.GetComponent<PlayerController>().poweredUp;

    }


    public void initializeGame()
    {
        tryAgainButton.SetActive(false);
        quitButton.SetActive(false);

        player.GetComponent<PlayerController>().poweredUp = false;
        score = 0;
        UpdateScorePanelText();//to initialize on screen
        winText.text = "";//see above;

        player.SetActive(true);
        player.GetComponent<Rigidbody>().transform.position = playerStart;
        player.GetComponent<Rigidbody>().velocity = stop;

        foreach (VillainSpawn vs in villains)
        {
            vs.villain.GetComponent<Rigidbody>().transform.position = vs.spawnPoint;
            vs.villain.GetComponent<Rigidbody>().velocity = stop;
            vs.villain.gameObject.SetActive(false);
        }

        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawner.GetComponent<SpawnerController>().stopSpawn = false;
        }

        groundSpawn.GetComponent<SpawnerController>().SpawnPickup();

        music.Play();
    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        collect.Play();
        UpdateScorePanelText();
        if (score == 1)
        {
            foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
            {
                spawner.GetComponent<SpawnerController>().StartSpawning();
            }
        }
        else if (score >= scoreWinValue)
        {
            Win();
        }
        foreach (VillainSpawn vs in villains)
        {
            if (score == vs.scoreTrigger)
                vs.villain.gameObject.SetActive(true);
        }
    }

    public void Lose()
    {
        music.Stop();
        death.Play();
        endGame(loseMessage);
    }

    public void Win()
    {
        music.Stop();
        victory.Play();
        endGame(winMessage);
    }

    public void endGame(string endMessage)
    {

        foreach (VillainSpawn vs in villains)
        {
            vs.villain.gameObject.SetActive(false);
        }

        foreach (GameObject shifter in GameObject.FindGameObjectsWithTag("Pick Up"))
        {
            Destroy(shifter);
        }

        foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("Power Up"))
        {
            Destroy(powerup);
        }

        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawner.GetComponent<SpawnerController>().StopSpawning();
            spawner.GetComponent<SpawnerController>().totalSpawned = 0;

        }
        tryAgainButton.SetActive(true);
        quitButton.SetActive(true);

        tryAgainButton.GetComponentInChildren<Text>().text = tryAgainText;

        winText.text = endMessage;

    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
