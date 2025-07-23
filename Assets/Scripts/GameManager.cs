using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Block spawning")]
    [SerializeField] private GameObject blockPrefab;

    [SerializeField] private float spawnHeight = 1f;

    private Block lastPlacedBlock;
    private Vector3 lastBlockSize;
    
    [Header("Dependencies")]
    [SerializeField] private CameraController cameraController;
    
    [Header("UIElements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private int _score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        UpdateScoreUI();
        StartGame();
    }

    public void StartGame()
    {
        GameObject baseObject = GameObject.Find("Base");
        if (baseObject != null)
        {
            lastPlacedBlock = baseObject.GetComponent<Block>();
            lastBlockSize = lastPlacedBlock.transform.localScale;
            SpawnNewBlock();
        }
        else
        {
            Debug.LogError("GameManager could not find Base");
        }
    }

    public void SpawnNewBlock()
    {
        GameObject newBlockObject = Instantiate(blockPrefab);

        Vector3 spawnPosition = new Vector3(
            0,
            lastPlacedBlock.transform.position.y + spawnHeight,
            0
        );
        newBlockObject.transform.position = spawnPosition;
        
        newBlockObject.transform.localScale = lastBlockSize;
        
        Block newBlockScript = newBlockObject.GetComponent<Block>();
        
        newBlockScript.previousBlock = lastPlacedBlock;
    }

    public void ProcessSuccessfulStack(Block stackedBlock)
    {
        _score++;
        UpdateScoreUI();
        
        lastPlacedBlock = stackedBlock;
        lastBlockSize = stackedBlock.transform.localScale;

        if (cameraController != null)
        {
            cameraController.UpdateTargetHeight(stackedBlock.transform.position.y);
        }
        
        SpawnNewBlock();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + _score.ToString();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + _score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
