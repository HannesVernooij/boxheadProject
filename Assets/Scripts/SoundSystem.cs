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
    public void Shoot(int player, string weaponTag)
    {
        switch (weaponTag)
        {
            case "Pistol":
                ShootPistol(player);
                break;
            case "Shotgun":
                ShootShotgun(player);
                break;
            case "smg":
                break;
            case "Sniper":
                ShootSniper(player);
                break;
        }
    }

    public void Reload(int player,string weaponTag)
    {
        switch (weaponTag)
        {
            case "Pistol":
                StartCoroutine(ReloadPistol(player));
                break;
            case "Shotgun":
                ReloadShotgun(player);
                break;
            case "smg":
                StartCoroutine(ReloadAK(player));
                break;
            case "Sniper":
                StartCoroutine(ReloadSniper(player));
                break;
        }
    }

    private void ShootShotgun(int player)
    {
        m_AudioSource[player].clip = m_Shotgun[0];
        m_AudioSource[player].Play();
    }
    private void ReloadShotgun(int player)
    {
        m_AudioSource[player].clip = m_Shotgun[1];
        m_AudioSource[player].Play();
    }
    public void ShotgunPump(int player)
    {
        m_AudioSource[player].clip = m_Shotgun[2];
    }
    private void ShootAK(int player)
    {
        m_AudioSource[player].clip = m_AK[0];
        m_AudioSource[player].Play();
    }

    private IEnumerator ReloadAK(int player)
    {
        m_AudioSource[player].clip = m_AK[1];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_AK[1].length + 0.2f);
        m_AudioSource[player].clip = m_AK[3];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_AK[3].length + 0.3f);
        m_AudioSource[player].clip = m_AK[2];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_AK[2].length + 0.25f);
        m_AudioSource[player].clip = m_AK[1];
        m_AudioSource[player].Play();
    }

    private void ShootPistol(int player)
    {
        m_AudioSource[player].clip = m_Pistol[0];
        m_AudioSource[player].Play();
    }

    private IEnumerator ReloadPistol(int player)
    {
        m_AudioSource[player].clip = m_Pistol[3];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_Pistol[3].length + 0.1f);
        m_AudioSource[player].clip = m_Pistol[2];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_Pistol[2].length + 0.1f);
        m_AudioSource[player].clip = m_Pistol[1];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_Pistol[1].length + 0.1f);
        m_AudioSource[player].clip = m_Pistol[4];
        m_AudioSource[player].Play();
    }
    private void ShootSniper(int player)
    {
        m_AudioSource[player].clip = m_Sniper[0];
        m_AudioSource[player].Play();
    }
    private IEnumerator ReloadSniper(int player)
    {
        m_AudioSource[player].clip = m_Sniper[1];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_Sniper[1].length + 0.1f);
        m_AudioSource[player].clip = m_Sniper[5];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_Sniper[5].length + 0.3f);
        m_AudioSource[player].clip = m_Sniper[4];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_Sniper[4].length - 0.1f); //Cliphit voert uit terwijl clipin uitvoert.
        m_AudioSource[player].clip = m_Sniper[3];
        m_AudioSource[player].Play();
        yield return new WaitForSeconds(m_Sniper[3].length + 0.1f);
        m_AudioSource[player].clip = m_Sniper[2];
        m_AudioSource[player].Play();
    }
}
