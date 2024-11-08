using System;
using UnityEngine;

//공격 대상을 고르는 객체 인터페이스 
public interface IAttackToTargetAble
{
    //공격 대상을 찾는 메서드
    public IDamageAble AttackToTarget();
}

//자기 자신이 데미지를 입어 Hp에 피해를 받을 수 있는 객체 인터페이스
public interface IDamageAble
{
    //공격을 받을때 동작하는 메서드
    public void TakeDamage();
    //적에게 디버프가 적용됬을때 동작하는 메서드
    public void TakeDebuff();
}
