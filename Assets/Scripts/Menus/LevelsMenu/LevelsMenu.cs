using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField] Transform[] levels;
    private int currentLevel;
    private float speed = 5;
    private void Start()
    {
        currentLevel = 0;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, levels[currentLevel].transform.position, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            MoveToLevel(1);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            MoveToLevel(-1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            EnterLevel();
        }

    }
    public void MoveToLevel(int direction)
    {
        if (currentLevel >= 0 && currentLevel < levels.Length - 1)
        {
            currentLevel += direction;
            print(currentLevel);
        }
    }

    private void EnterLevel()
    {
        SceneManager.LoadScene(currentLevel+2);
    }


}
