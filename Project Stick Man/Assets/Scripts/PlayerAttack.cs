using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; // Waktu cooldown antara serangan
    [SerializeField] private Transform attackPoint; // Titik di mana serangan akan dilakukan
    [SerializeField] private float attackRange = 1.5f; // Jarak serangan
    [SerializeField] private int attackDamage = 20; // Damage serangan
    [SerializeField] private GameObject slashEffect; // Prefab efek slashing

    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Memeriksa apakah tombol 'Z' ditekan dan cooldown sudah habis
        if (Input.GetKeyDown(KeyCode.Z) && cooldownTimer > attackCooldown)
        {
            Attack();
        }

        // Mengupdate cooldown timer
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        // Memicu animasi serangan
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        // Menampilkan efek slashing
        if (slashEffect != null)
        {
            Instantiate(slashEffect, attackPoint.position, Quaternion.identity);
        }

        // Menampilkan jangkauan serangan
        // Anda dapat menambahkan logika di sini jika Anda ingin melakukan sesuatu saat menyerang
        // Misalnya, menampilkan pesan di konsol
        Debug.Log("Attack executed, but no enemies detected.");
    }

    // Untuk menampilkan jangkauan serangan di editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}