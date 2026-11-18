using System;
using CommandSystem;
using Exiled.API.Features;

namespace Site27Main.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class ShyGuyToggle : ICommand
{
    public string Command => "shyguytoggle";
    public string[] Aliases => new string[] { "096toggle", "permashyguy", "perma096" };
    public string Description => "When enabled, SCP-096 will never calm down after being agitated until its target is dead. Off by default.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (EventHandlers.PermaAngerEnabled)
            EventHandlers.PermaAngerEnabled = false;
        else
            EventHandlers.PermaAngerEnabled = true;

        response = $"Perma Anger is now {(EventHandlers.PermaAngerEnabled ? "enabled" : "disabled")}.";
        return true;
    }
}