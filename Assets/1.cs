using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;          // 飛行器 Transform
    public Vector3 offset = new Vector3(0f, 3f, -10f); // 視角相對距離
    public float smoothSpeed = 5f;    // 平滑跟隨係數

    void LateUpdate()
    {
        if (target == null) return;

        // 計算目標位置與旋轉
        Vector3 desiredPosition = target.TransformPoint(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}