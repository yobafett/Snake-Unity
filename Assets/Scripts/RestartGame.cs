using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class RestartGame : MonoBehaviour
{
    private void OnEnable() => SnakeCollisions.OnObstacleCollide += DelayerRestart;
    private void OnDisable() => SnakeCollisions.OnObstacleCollide -= DelayerRestart;
    private void DelayerRestart() => Invoke(nameof(Restart), 1f);
    private void Restart() => SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
}
