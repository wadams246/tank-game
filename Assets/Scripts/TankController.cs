using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMover tankMover;
    public AimTurrent aimTurrent;
    public Turret[] turrets;

    private void Awake()
    {
        if (tankMover == null)
            tankMover = GetComponentInChildren<TankMover>();

        if (aimTurrent == null)
            aimTurrent = GetComponentInChildren<AimTurrent>();

        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
           
    }

    public void HandelShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);
    }

    public void HandleTurrentMovement(Vector2 pointerPosition)
    {
        aimTurrent.Aim(pointerPosition);
    }


}
