using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public Rigidbody BalonRigidBody;
    public float Fuerza = 10f;
    public Transform BalonTransform;
    public Transform DestinoTransform;
    public Animator DireccionAnimator;
    public Animator ElevacionAnimator;
    public Animator IndicadorAnimator;
    public float NivelFuerza1;
    public float NivelFuerza2;
    public Transform TransformIndicador;

    void Start()
    {
        DireccionAnimator.speed = 1;
        ElevacionAnimator.speed = 0;
    }

    public void DetenerBarrafuerza()
    {
        IndicadorAnimator.speed = 0;
        IndicadorAnimator.Update(0);

        NivelFuerza1 = TransformIndicador.localPosition.y;
        NivelFuerza2 = Mathf.InverseLerp(0f, 2080f, NivelFuerza1);
    }


    public void PatearPelota()
    {
        Vector3 direccion = (DestinoTransform.position - BalonTransform.position).normalized;

        //print("¡Pelota pateada!");
        BalonRigidBody.AddForce(direccion * Fuerza, ForceMode.Impulse);
    }

    public void PosicionarBalon()
    {
        BalonRigidBody.velocity = Vector3.zero;
        BalonRigidBody.angularVelocity = Vector3.zero;
        BalonRigidBody.Sleep();
        BalonTransform.position = new Vector3(0f, 0.5f,0f);
        BalonTransform.rotation = Quaternion.identity;
    }
   

    // detener direccion
    public void DetenerDireccion()
    {
        //print("DetenerDireccion");
        DireccionAnimator.speed = 0;
    }

    // reproducir direccion
    public void ReproducirDireccion()
    {
        //print("ReproducirDireccion");
        DireccionAnimator.speed = 1;
    }


    // detener elevacion
    public void DetenerElevacion()
    {
        //print("DetenerElevacion");
        ElevacionAnimator.speed = 0;
    }

    // reproducir elevacion

    public void ReproducirElevacion()
    {
        //print("ReproducirElevacion");
        ElevacionAnimator.speed = 1;
    }



}
