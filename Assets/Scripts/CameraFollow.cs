using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0f;
        transform.position = targetPos;
    }

    public void HelpGame()
    {
        SceneManager.LoadScene("HelpScene");
    }
}
