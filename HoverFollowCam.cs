using UnityEngine;
using System.Collections;

public class HoverFollowCam : MonoBehaviour
{
  public float m_camHeight;
  public float m_camDist;
  public float offsetCam;

  GameObject m_player;
  int m_layerMask;

  void Start()
  {
    m_player = GameObject.FindGameObjectWithTag("CameraView") as GameObject;

		Vector3 offsetCam = new Vector3 (0, 20, -50);
		m_camHeight = 20;
		m_camDist = Mathf.Sqrt(
		offsetCam.x * offsetCam.x + 
 		offsetCam.z * offsetCam.z);

    m_layerMask = 1 << LayerMask.NameToLayer("Characters");
    m_layerMask = ~m_layerMask;
  }
	
  void Update()
  {
		Vector3 camOffset = new Vector3 (0, 20, -50);
		camOffset = new Vector3(camOffset.x, camOffset.y, camOffset.z) * m_camDist
      + Vector3.up * m_camHeight;

    RaycastHit hitInfo;
    if (Physics.Raycast(m_player.transform.position, camOffset, 
                       out hitInfo, m_camDist, 
                       m_layerMask))
    {
      transform.position = hitInfo.point;
    } else
    {
      transform.position = m_player.transform.position + camOffset;
    }

    transform.LookAt(m_player.transform.position);
  }
}
