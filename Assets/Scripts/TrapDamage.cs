using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDamage : MonoBehaviour
{
  //public int Respawn;
    public PlayerController _TrapPC;
    public Switch _switch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (InGameManager.Instance.wrong >= 5)
            {
                if (InGameManager.Instance.LifePoint == 0)
                {
                    _TrapPC.GameOverScreen();
                }
                else
                {
                    InGameManager.Instance.LifePoint -= 1;
                    _TrapPC.transform.position = _TrapPC.respawnPoint;
                    _switch._isPressed = false;
                    _switch.ResetPosition();
                    _switch._BallonClue.SetActive(false);
                    InGameManager.Instance.areGameObjectsEnabled = false;
                }

            }
            else
            {
                _TrapPC.transform.position = _TrapPC.respawnPoint;
                _switch._isPressed = false;
                _switch.ResetPosition();
                _switch._BallonClue.SetActive(false);
                InGameManager.Instance.areGameObjectsEnabled = false;
            }
        }
    }
}
