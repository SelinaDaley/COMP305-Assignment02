using UnityEngine;
using System.Collections;

public class CreateLand : MonoBehaviour {

	public GameObject landTile;
	public GameObject waterTile;
	public GameObject bridgeTile;
    public GameObject sPlatform;
    public GameObject blockTile;
    public GameObject player;
	public GameObject dirtTile;
	public GameObject blackTile;
	public GameObject spikeTile;
	public GameObject goldCoin;
	public GameObject crateTile;
	public GameObject longHill;
	public GameObject shortHill;
	public GameObject greenSwitch;
	public GameObject[] platforms;

	public GameObject enemyBomb;

	private Vector2 originPosition;
    private Vector2 trans;
	private float spawnWait = 0;
    private int groundSpawnCount = 0;
    private float platformHight = 3;
	private GameController gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' Script");
		}

        originPosition = transform.position;
		trans = transform.position;

		for (int i = 0; i < 20; i++) 
		{
			SpawnFloor();

            if (i == 4 || i == 5 || i == 6 || i == 9 || i == 10 || i == 11)
            {
                SpawnBlock();
            }

            if (groundSpawnCount == 20)
            {
                SpawnPlatformS(platformHight);
                platformHight += 1;
            }
		}
        
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(gameController.gameOver == false){

		if(player.transform.position.x > 0f && Input.GetKey(KeyCode.RightArrow))
        {
			trans = new Vector2 (-0.15f, 0.0f);
			if(groundSpawnCount < 133)
				this.transform.position += new Vector3 (-0.15f, 0.0f, 0.0f);
			originPosition += trans;
			spawnWait += 0.15f;
			//print(spawnWait);

			if(spawnWait >= 1f)
			{
                if (groundSpawnCount == 0)
                {
                    print("Start ground spawn");
                }
                else if (groundSpawnCount > 0 && groundSpawnCount < 26)
                {
                    SpawnFloor();
                }
                else if (groundSpawnCount >= 26 && groundSpawnCount < 41)
                {
                    SpawnWater();
                }
				else if (groundSpawnCount >= 70 && groundSpawnCount < 82)
				{
					SpawnWaterBridge();
				}
				else if(groundSpawnCount == 45 || groundSpawnCount == 100)
				{
					SpawnDirtHill();
				}
					else if(groundSpawnCount == 108 || groundSpawnCount == 109)
				{
					SpawnCastleFront();
				}
				else if(groundSpawnCount == 110 || groundSpawnCount == 111 || groundSpawnCount == 112 ||
					        groundSpawnCount == 113 || groundSpawnCount == 114 || groundSpawnCount == 115 || groundSpawnCount == 116)
				{
					SpawnCastle();
				}
                else
                {
                    SpawnFloor();
                }

                if (groundSpawnCount == 26 || groundSpawnCount == 33 || groundSpawnCount == 39)
                {
                    SpawnPlatformS(platformHight);
                }
				if(groundSpawnCount == 42 || groundSpawnCount == 50 || groundSpawnCount == 93 || groundSpawnCount == 101  )
				{
					SpawnSpikes();
				}
				

				/*if(groundSpawnCount == 105) || groundSpawnCount == 108 || groundSpawnCount == 111 || groundSpawnCount == 114 || groundSpawnCount == 117 || groundSpawnCount == 120)
				{
					if(platf == 1)
						SpawnPlatforms(0, 1);
					else if(platf == 2)
						SpawnPlatforms(2, 1);
					else if(platf == 3)
						SpawnPlatforms(3, 1);
					else if(platf == 4)
						SpawnPlatforms(2, 1);
					else if(platf == 5)
						SpawnPlatforms(5, 1);
					else if(platf == 6)
						SpawnPlatforms(2, 1);

					platf++;
				}*/

				if(groundSpawnCount == 53 || groundSpawnCount == 76)
				{
					SpawnGoldCoin();
				}
				if(groundSpawnCount == 76 || groundSpawnCount == 86)
				{
					SpawnCrate();
				}
				if (groundSpawnCount == 58 || groundSpawnCount == 59 || groundSpawnCount == 60 ||
				    groundSpawnCount == 63 || groundSpawnCount == 64 || groundSpawnCount == 65 ||
				    groundSpawnCount == 97 || groundSpawnCount == 98 || groundSpawnCount == 99)
				{
					SpawnBlock();
				}
				if(groundSpawnCount == 92)
				{
					SpawnLongHill();
				}
				if(groundSpawnCount == 21 || groundSpawnCount == 41 || groundSpawnCount == 61 || 
				  groundSpawnCount == 81 || groundSpawnCount == 101 || groundSpawnCount == 111)
				{
					GameObject clone;
					Vector2 randomPosition = originPosition + new Vector2(0f, 7.3f);
					clone = Instantiate(enemyBomb, randomPosition, Quaternion.identity) as GameObject;
					clone.transform.parent = GameObject.Find("SpawnManager").transform;
				}
				/*if(groundSpawnCount == 110)
				{
					SpawnGreenSwitch();
				}
				if(groundSpawnCount == 111)
				{
					SpawnShortHill();
				}*/

				spawnWait = -0.35f;
			}
			//print (groundSpawnCount);
			}
        }


	    if(Input.GetKeyDown(KeyCode.Q))
        {
            SpawnFloor();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnWater();
        }
		if (Input.GetKeyDown(KeyCode.E))
		{
			SpawnWaterBridge();
		}
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnPlatformS(platformHight);
        }
		if (Input.GetKeyDown(KeyCode.T))
		{
			SpawnDirtHill();
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			SpawnCrate();
		}
		if (Input.GetKeyDown(KeyCode.U))
		{
			groundSpawnCount = 101;
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			SpawnCastle();
			SpawnCastle();
			SpawnCastle();
			SpawnCastle();
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			GameObject clone;
			Vector2 randomPosition = originPosition + new Vector2(0f, 7.3f);
			clone = Instantiate(enemyBomb, randomPosition, Quaternion.identity) as GameObject;
			clone.transform.parent = GameObject.Find("SpawnManager").transform;
		}
	}

    void SpawnFloor()
    {        
        //Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(1.4f, 0f);
        clone = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
        originPosition = randomPosition;        
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
        groundSpawnCount++;
		//GameObject clone;
		//clone = Instantiate(bronzeCoin, coinPosition, Quaternion.identity) as GameObject;
		//clone.transform.parent = GameObject.Find("SpawnManager").transform;
    }

    void SpawnWater()
    {
        GameObject clone;
        Vector2 randomPosition = originPosition + new Vector2(1.4f, -0.2f);
        clone = Instantiate(waterTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, 0.2f);
        clone.transform.parent = GameObject.Find("SpawnManager").transform;
        groundSpawnCount++;
    }

	void SpawnWaterBridge()
	{
        GameObject clone;
        GameObject clone2;

		Vector2 randomPosition = originPosition + new Vector2(1.4f, -0.2f);
		clone = Instantiate(waterTile, randomPosition, Quaternion.identity) as GameObject;

		Vector2 bridgePosition = randomPosition + new Vector2(0f, 0.7f);
		clone2 = Instantiate(bridgeTile, bridgePosition, Quaternion.identity) as GameObject;

		originPosition = randomPosition + new Vector2(0f, 0.2f);
        clone.transform.parent = GameObject.Find("SpawnManager").transform;
        clone2.transform.parent = GameObject.Find("SpawnManager").transform;
        groundSpawnCount++;
	}

    void SpawnPlatformS(float hight)
    {
        GameObject clone;
        Vector2 randomPosition = originPosition + new Vector2(0f, platformHight);
        clone = Instantiate(sPlatform, randomPosition, Quaternion.identity) as GameObject;
        originPosition = randomPosition + new Vector2(0f, -platformHight);
        clone.transform.parent = GameObject.Find("SpawnManager").transform;
    }

	void SpawnPlatforms(int plat, float hight)
	{
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(0f, hight);
		clone = Instantiate(platforms[0], randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -hight);
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
	}

    void SpawnBlock()
    {
        GameObject clone;
        Vector2 randomPosition = originPosition + new Vector2(0.0f, 4f);
        clone = Instantiate(blockTile, randomPosition, Quaternion.identity) as GameObject;
        originPosition = randomPosition + new Vector2(0f, -4f);
        clone.transform.parent = GameObject.Find("SpawnManager").transform;
    }

	void SpawnSpikes()
	{
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(0f, 1.0f);
		clone = Instantiate(spikeTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -1.0f);
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
	}

	void SpawnCrate()
	{
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone = Instantiate(crateTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -1.4f);
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
	}

	void SpawnLongHill()
	{
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(0f, 2.7f);
		clone = Instantiate(longHill, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -2.7f);
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
	}

	void SpawnShortHill()
	{
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(0f, 0.07f);
		clone = Instantiate(shortHill, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -0.07f);
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
	}

	void SpawnGoldCoin()
	{
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(0f, 7f);
		clone = Instantiate(goldCoin, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -7f);
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
	}

	void SpawnGreenSwitch()
	{
		GameObject clone;
		Vector2 randomPosition = originPosition + new Vector2(0f, 0f);
		clone = Instantiate(greenSwitch, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, 0f);
		clone.transform.parent = GameObject.Find("SpawnManager").transform;
	}

	void SpawnDirtHill()
	{
		GameObject[] clone = new GameObject[10];

		Vector2 randomPosition = originPosition + new Vector2(1.4f, 0f);
		clone[0] = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;// + new Vector2(0f, 0f);
		clone[0].transform.parent = GameObject.Find("SpawnManager").transform;
////////////
		randomPosition = originPosition + new Vector2(1.4f, 0f);
		clone[1] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[1].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[2] = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -1.4f);
		clone[2].transform.parent = GameObject.Find("SpawnManager").transform;
////////////
		randomPosition = originPosition + new Vector2(1.4f, 0f);
		clone[3] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[3].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[4] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[4].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[5] = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -2.8f);
		clone[5].transform.parent = GameObject.Find("SpawnManager").transform;
////////////
		randomPosition = originPosition + new Vector2(1.4f, 0f);
		clone[6] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[6].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[7] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[7].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[8] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[8].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[9] = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -4.2f);
		clone[9].transform.parent = GameObject.Find("SpawnManager").transform;

		groundSpawnCount += 4;
		spawnWait -= 5.9f;
	}

	void SpawnCastle()
	{
		GameObject[] clone = new GameObject[4];
		
		Vector2 randomPosition = originPosition + new Vector2(1.4f, 0f);
		randomPosition = originPosition + new Vector2(1.4f, 0f);
		clone[0] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[0].transform.parent = GameObject.Find("SpawnManager").transform;
		
		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[1] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[1].transform.parent = GameObject.Find("SpawnManager").transform;
		
		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[2] = Instantiate(dirtTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[2].transform.parent = GameObject.Find("SpawnManager").transform;
		
		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[3] = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -4.2f);
		clone[3].transform.parent = GameObject.Find("SpawnManager").transform;
		
		groundSpawnCount++;
		spawnWait -= 5.9f;
	}

	void SpawnCastleFront()
	{
		GameObject[] clone = new GameObject[4];
		Vector2 randomPosition = originPosition + new Vector2(1.4f, 0f);
		clone[0] = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;        
		clone[0].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[1] = Instantiate(blackTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[1].transform.parent = GameObject.Find("SpawnManager").transform;
		
		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[2] = Instantiate(blackTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition;
		clone[2].transform.parent = GameObject.Find("SpawnManager").transform;

		randomPosition = originPosition + new Vector2(0f, 1.4f);
		clone[3] = Instantiate(landTile, randomPosition, Quaternion.identity) as GameObject;
		originPosition = randomPosition + new Vector2(0f, -4.2f);
		clone[3].transform.parent = GameObject.Find("SpawnManager").transform;

		groundSpawnCount++;
	}
}
 