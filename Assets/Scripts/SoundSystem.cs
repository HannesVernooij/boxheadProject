using System;
using UnityEngine;
using System.Collections;

public class SoundSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Locations;
    [SerializeField]
    private AudioClip[] m_Pistol,
                        m_Shotgun,
                        m_AK,
                        m_Sniper;
    private AudioSource[] m_AudioSource;

    private void Start()
    {
        m_AudioSource = new AudioSource[4];
        for (int i = 0; i < m_Locations.Length; i++)
        {
            m_AudioSource[i] = m_Locations[i].AddComponent<AudioSource>();
        }
    }

    public void Shoot(int player, string gunTag)
    {
        switch (gunTag)
        {
            case "Pistol":
                ShootPistol(player);
                break;
            case "Shotgun":
                ShootShotgun(player);
                break;
            case "Smg":
                ShootAK(player);
                break;
            case "Sniper":
                ShootSniper(player);
                break;
        }
    }

    private void ShootPistol(int player)
    {
        m_AudioSource[player].clip = m_Pistol[0];
        m_AudioSource[player].Play();
    }

    private void ShootShotgun(int player)
    {

        m_AudioSource[player].clip = m_Shotgun[0];
        m_AudioSource[player].Play();

    }

    private void ShootAK(int player)
    {
        m_AudioSource[player].clip = m_AK[0];
        m_AudioSource[player].Play();
    }

    private void ShootSniper(int player)
    {
        m_AudioSource[player].clip = m_Sniper[0];
        m_AudioSource[player].Play();
    }
}
