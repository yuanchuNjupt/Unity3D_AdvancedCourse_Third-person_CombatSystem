using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.ATK)
        {
            Debug.Log("Attack button pressed!");
        }

        if (InputManager.Instance.Parry)
        {
            Debug.Log("Parry button pressed!");
        }
        
        Debug.Log(InputManager.Instance.Move);
        
    }
}
