using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using UnityEngine;

namespace Site27Main.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class ZoneColor : ICommand
{
    public string Command { get; set; } = "zcolor";
    public string[] Aliases { get; set; } = new[] { "ZoneColor" };
    public string Description { get; set; } = "Colors all the lights in one zone.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {

        //   -1    0   1 2 3
        // zcolor Zone r g b

        if (arguments.Count < 4)
        {
            response = "Not enough arguments! Syntax: zcolor [zone] [r] [g] [b]";
            return false;
        }

        if (!Enum.TryParse(arguments.At(0), out ZoneType zoneType))
        {
            response = "Invalid zone! Zones: Surface, Entrance, HeavyContainment, LightContainment";
            return false;
        }

        if (!byte.TryParse(arguments.At(1), out var r) || !byte.TryParse(arguments.At(2), out var g) || !byte.TryParse(arguments.At(3), out var b))
        {
            response = "Invalid RGB! RGB must be a number 0-255.";
            return false;
        }

        Color rgb = new Color(r / 255f, g / 255f, b / 255f);

        foreach (var room in Room.List)
        {
            if (room.Zone != zoneType)
                continue;

            room.Color = rgb;
        }

        response = $"<color=green>Lights set to ({r}, {g}, {b}) successfully in {zoneType}!";
        return true;
    }
}
