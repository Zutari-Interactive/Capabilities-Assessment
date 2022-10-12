using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    #region VARIABLES
    public MovementSM m_MovementSM;

    // Assign list of relevant speeds 
    [SerializeField]
    private List<float> _speeds = new List<float>() { 10f, 20f, 5f};

    private int count = 0;
    #endregion

    #region UNITY EVENTS
    private void Update()
    {
        // iterate through speeds when input "c" is pressed to execute change

        if (Input.GetKeyDown("c"))
        {
            if (count == 2)
            {
                count = 0; 
            }
            else
            {
                count += 1;
            }

            m_MovementSM.speed = _speeds[count];
            
        }
    }
    #endregion




}
