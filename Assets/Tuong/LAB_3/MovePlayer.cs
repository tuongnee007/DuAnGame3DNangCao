using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển

    void Update()
    {
        // Lấy đầu vào từ bàn phím
        float horizontal = Input.GetAxis("Horizontal"); // A/D hoặc phím mũi tên trái/phải
        float vertical = Input.GetAxis("Vertical"); // W/S hoặc phím mũi tên lên/xuống

        // Tính hướng di chuyển
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Di chuyển nhân vật
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
