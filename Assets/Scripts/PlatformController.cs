using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool[] hasPlayerSteppedOn; // Array untuk melacak platform-platform yang telah dilewati
    private GameObject[] platformObjects; // Array untuk menyimpan game object platform

    private void Awake()
    {
        // Mendapatkan semua game object platform dalam scene
        platformObjects = GameObject.FindGameObjectsWithTag("PapanFloating");

        // Inisialisasi array
        hasPlayerSteppedOn = new bool[platformObjects.Length];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mendapatkan indeks platform yang terkena oleh pemain
            int platformIndex = GetPlatformIndex(collision.gameObject);

            // Memastikan platform yang terkena adalah valid
            if (platformIndex != -1 && !hasPlayerSteppedOn[platformIndex])
            {
                hasPlayerSteppedOn[platformIndex] = true;
                DisablePlatform(platformIndex);
            }
        }
    }

    private int GetPlatformIndex(GameObject player)
    {
        // Mencari indeks platform yang terkena oleh pemain
        for (int i = 0; i < platformObjects.Length; i++)
        {
            if (player.transform.position.y > platformObjects[i].transform.position.y)
            {
                return i;
            }
        }
        return -1; // Tidak ada platform yang terkena oleh pemain
    }

    private void DisablePlatform(int platformIndex)
    {
        platformObjects[platformIndex].SetActive(false);
        // Tambahkan kode lain yang ingin Anda jalankan saat platform menghilang
    }
}
