using UnityEngine;
using Cinemachine;

public class Cinetouch : MonoBehaviour
{
    [SerializeField] TouchField touchField; //touch input panel
    [SerializeField] CinemachineFreeLook cineCam;
    
    [SerializeField] float SenstivityX = 2f;
    [SerializeField] float SenstivityY = 2f;


   
    void Update()
    {
        cineCam.m_XAxis.Value += touchField.TouchDist.x * 200 * SenstivityX * Time.deltaTime;

        cineCam.m_YAxis.Value += touchField.TouchDist.y * SenstivityY * Time.deltaTime;

    }
}
