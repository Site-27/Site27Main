using System;
using CommandSystem;

namespace Site27Main.Commands;

public abstract class RPDescription
{
    public static string rpdescription = "No custom description has been set for this roleplay. Check #rp-announcements in the discord for the schedule!";
}

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class SetDescription : ICommand
{
    public string Command { get; } = "setdescription";
    public string[] Aliases { get; } = new string[] { "rpinfo", "schedule", "rpschedule", "description", "rpdescription" };
    public string Description { get; } = "Sets the information/description of the current roleplay, which players can read in the Console.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {

        //setdescription [description]

        if (arguments.Count == 0)
        {
            response = "Usage: setdescription [description]. Consider typing out your description in a text editor first, like Discord or Notepad.";
            return false;
        }

        string info = string.Join(" ", arguments);

        if (arguments.At(1) == "reset")
        {
            info = "\nNo custom description has been set for this roleplay. Check #rp-announcements in the discord for the schedule!";
            response = "Description reset to default.";
            return true;
        }

        RPDescription.rpdescription = $"\n{info}";
        response = "Description set successfully! Check in the console with .rpinfo or .description.";
        return true;
    }
}

[CommandHandler(typeof(ClientCommandHandler))]
public class RPInfo : ICommand
{
    public string Command { get; } = "rpinfo";
    public string[] Aliases { get; } = new string[] { "schedule", "description" };
    public string Description { get; } = "Displays the roleplay description set by the staff.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (RPDescription.rpdescription == null || RPDescription.rpdescription == "")
        {
            response = "\nNo custom description has been set for this roleplay. Check #rp-announcements in the discord for the schedule!";
            return true;
        }

        response = RPDescription.rpdescription;
        return true;
    }
}