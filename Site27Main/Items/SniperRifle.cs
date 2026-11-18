/*
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Firearms.Attachments;
using PlayerStatsSystem;
using MEC;
using System.Collections.Generic;
using UnityEngine;
using Exiled.API.Enums;

namespace Site27Main.Items;

[CustomItem(ItemType.GunE11SR)]
public class SniperRifle : CustomWeapon
{
    public override uint Id { get; set; } = 52;
    public override string Name { get; set; } = "Sniper Rifle (Broken)";
    public override string Description { get; set; } = "A modified E-11 with a scope that does more damage, but only holds one bullet at a time. Doesn't really work atm, sorry.";
    public override float Weight { get; set; }
    public override bool FriendlyFire { get; set; } = true;
    public override byte ClipSize { get; set; } = 1;
    public override SpawnProperties? SpawnProperties { get; set; }

    public override AttachmentName[] Attachments { get; set; } =
    [
        AttachmentName.ScopeSight,
        AttachmentName.RifleBody,
        AttachmentName.LowcapMagAP
    ];

    private float DamageMultiplier { get; set; } = 2.1f;
    private bool ShootingAllowed { get; set; } = true;
    private float CooldownTime { get; set; } = 3f;

    protected override void OnHurting(HurtingEventArgs ev)
    {
        if (ev.Attacker != ev.Player && ev.DamageHandler.Base is FirearmDamageHandler firearmDamageHandler && firearmDamageHandler.WeaponType == ev.Attacker.CurrentItem.Type)
            ev.Amount *= DamageMultiplier;
    }

    protected override void OnReloading(ReloadingWeaponEventArgs ev)
    {
            ev.IsAllowed = false;
    }

    private readonly Dictionary<Player, float> _lastShotTime = new();

    protected override void OnShooting(ShootingEventArgs ev)
    {
        if (!ShootingAllowed)
        {
            ev.IsAllowed = false;
            float remainingTime = CooldownTime - (Time.time - _lastShotTime[ev.Player]);
            ev.Player.ShowHint($"You must wait {remainingTime:F1} seconds before shooting again.");
            Log.Debug($"Shooting not allowed. Cooldown time remaining: {remainingTime:F1}");
        }
        else if (ShootingAllowed)
        {
            ShootingAllowed = false;
            _lastShotTime[ev.Player] = Time.time;

            Timing.CallDelayed(CooldownTime, () =>
            {
                ShootingAllowed = true;

                //this should auto force reload? since there is a bug where e-11s with less than 11 clipsize can't reload
                int AmmoCount = ev.Player.GetAmmo(AmmoType.Nato556);

                if (AmmoCount > 0)
                { 
                    ev.Player.SetAmmo(AmmoType.Nato556, ((ushort)(AmmoCount - ClipSize)));
                    ev.Firearm.MagazineAmmo = ClipSize; //this will work as long as clipsize isnt more than like 1 lol
                }
                else
                    ev.Player.ShowHint("You are out of ammo!");
            });

            Log.Debug($"Shooting allowed. Disallowing shooting for {CooldownTime} seconds.");
        }
    }
}*/