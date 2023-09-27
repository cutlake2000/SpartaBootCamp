using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MercenaryCtrl : MonoBehaviour
{
    public Rigidbody mercenary;
    Animator animator;
    public MercenaryData data;
    public List<GameObject> target;
    private float targetDistance;
    public string TagName = "Enemy";
    public GameObject enemy;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName));
        
    }
    private void Start()
    {

    }

    private void Update()
    {
        // ���� �Ǿ� �����Ӱ� ������϶�
       //StartCoroutine(MoveObject());

        GameObject CloseEnemy = GetClosest();
        float distance = GetDistance(enemy);
        Moving(CloseEnemy);
        Debug.Log(CloseEnemy.name);
        if (distance < data.AttackRange) 
        {
            Attacking();
        }

    }

    IEnumerator MoveObject()
    {
        mercenary = GetComponent<Rigidbody>();

        while(true)
        {
            float dir1 = Random.Range(-1f, 1f);
            float dir2 = Random.Range(-1f, 1f);

            yield return new WaitForSeconds(1);
            mercenary.velocity = new Vector3(dir1, 0, dir2);
        }
    }
    GameObject GetClosest()
    {
        enemy = target[0];
        float ShortDistance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
        foreach(GameObject found in target)
        {
           float distance =  GetDistance(found);
            if(distance < ShortDistance)
            {
                enemy = found;
                ShortDistance = distance;
            }
        }
        return enemy;
    }

    void Attacking()
    {
        // Ÿ�ٰ��� �Ÿ��� ���ݹ������� ������ ����!

        animator.SetTrigger("Attack");
        
    }
    float GetDistance(GameObject target)
    { 
        targetDistance = Vector3.Distance(target.transform.position, mercenary.transform.position);
        return targetDistance;
    }
    void Moving(GameObject target)
    {
        // ���� �����̿� �ִ� ������ ����
        Vector3 speed = Vector3.zero;
        Vector3 destination = target.transform.position;
        transform.position = Vector3.Lerp(transform.position, destination, 0.001f);
    }

}
