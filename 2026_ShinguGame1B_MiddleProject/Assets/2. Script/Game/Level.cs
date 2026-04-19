using UnityEngine;

public class Level : MonoBehaviour
{
    public string nextLevel;

    public void MovetoLevel()
    {
        LoadingSceneController.LoadScene(nextLevel);
    }
}
