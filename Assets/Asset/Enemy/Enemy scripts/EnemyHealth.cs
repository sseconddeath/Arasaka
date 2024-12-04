using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("��������� ������� ����");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }


    void Die()
    {
        //���� �������� ��� ����� ������
        Debug.Log("��������� ����");
        // Animator.SetBool("����", true); CC���� �� ������ �����
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
