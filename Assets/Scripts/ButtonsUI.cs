using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsUI : MonoBehaviour
{

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();   
    }

    public void ClickButtonAttack()
    {
        _playerController.Attack();
    }

     public void ClickButtonJump()
    {
        _playerController.Jump();
    }

    public void ClickButtonRun()
    {
        _playerController.Run();
    }
   
}