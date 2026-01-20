using Spectre.Console;

namespace WinHealthCheckerCLI.Prompts;

public class HelpPrompt : IPrompter
{
    public string[] UserSelectedOptions { get; set; }
    
    /// <summary>
    /// Displays the help prompt in the CLI.
    /// </summary>
    /// <returns>An empty string array.</returns>
    public Task<string[]> DisplayPrompt()
    {
        AnsiConsole.Clear(); 
        
        // Displays the different keybindings that are used in the application.
        AnsiConsole.WriteLine();
        Table _keysTable = new Table().Border(TableBorder.Rounded).Centered();
        _keysTable.Title = new TableTitle("[bold underline green]Help and About[/]");
        _keysTable.ShowRowSeparators = true;
        _keysTable.AddColumn("[green]Keyboard Key[/]");   
        _keysTable.AddColumn("[green]Description[/]");
        _keysTable.AddRow("[bold]h[/]", "Display this help message.");
        _keysTable.AddRow("[bold]b[/]", "Navigates back to the previous prompt.\n(How you exit this menu)");
        _keysTable.AddRow("[bold]q[/]", "Exit the program.");
        AnsiConsole.Write(_keysTable);
        
        // Displays the different options that are available in the application.
        AnsiConsole.WriteLine();
        Table _optionsTable = new Table().Border(TableBorder.Rounded).Centered();
        _optionsTable.Title = new TableTitle("[bold underline green]Options and Tools[/]");
        _optionsTable.ShowRowSeparators = true;
        _optionsTable.Width = 120;
        _optionsTable.AddColumn("[green]Option[/]");
        _optionsTable.AddColumn("[green]Description[/]");
        _optionsTable.AddRow(
            "[bold]Run Deployment Image Servicing and Management Restore Health (DISM)[/]", 
            "This tools is used to repair the Windows image and fix any issues with the system files. This can be " +
            "combined with the SFC tool.");
        _optionsTable.AddRow(
            "[bold]System File Checker[/]", 
            "This tool is used to check windows system files for corruption and repair them if needed. This can be " +
            "combined with the DISM tool.");
        _optionsTable.AddRow(
            "[bold]Windows Disk Check[/]",
            "This will allow for you to do a disk check on a drive for corruption. You will then get the option to " +
            "only check for errors and not fix them, or you can also select the option to fix them.");
        AnsiConsole.Write(_optionsTable);
        
        var key = DisplayMoreInfo("Do you wish to see the how to use message? Press space to continue or 'b' to go back...");
        if (key == ConsoleKey.B)
            return Task.FromResult(UserSelectedOptions);

        // Displays a simple explanation of how to use the application.
        AnsiConsole.WriteLine();
        Panel aboutPanel = new Panel(
            "To use the app just follow the prompts and select the options you want to use.\n" +
            "You can use the arrow keys to navigate through the options and press space to select an option.\n" +
            "Once you have selected an option, you can press enter to confirm your selection(s), and proceed to" +
            "the next part of the application.\n" +
            "\nYou may be asking what options should I select or need to repair my system.\n" +
            "Please refer to the table above for what each option does.\n"
            );
        aboutPanel.Header = new PanelHeader("[bold underline green]How to use![/]");
        aboutPanel.Border = BoxBorder.Rounded;
        AnsiConsole.Write(new Align(aboutPanel, HorizontalAlignment.Center));
        
        var key2 = DisplayMoreInfo("Do you wish to see the licence details? Press space to continue or 'b' to go back...");
        if (key2 == ConsoleKey.B)
            return Task.FromResult(UserSelectedOptions);
        
        // Display the licence details for the application.
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
        Panel licencePanel = new Panel(
            "   Link to Licence: " +
            "   https://github.com/TheTurnnip/WindowsHealthCheck/blob/main/LICENSE.txt/\n\n" +
            "    WindowsHealthCheck, a program to do simple windows health checks and scans.\n" +
            "    Copyright (C) 2025  Ryan Steffan\n\n" +
            "    This program is free software: you can redistribute it and/or modify\n" +
            "    it under the terms of the GNU General Public License as published by\n" +
            "    the Free Software Foundation, either version 3 of the License, or\n" +
            "    (at your option) any later version.\n\n" +
            "    This program is distributed in the hope that it will be useful,\n" +
            "    but WITHOUT ANY WARRANTY; without even the implied warranty of\n" +
            "    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the\n" +
            "    GNU General Public License for more details."
            );
        licencePanel.Header = new PanelHeader("[bold underline green]Licence[/]");
        licencePanel.Border = BoxBorder.Rounded;
        AnsiConsole.Write(new Align(licencePanel, HorizontalAlignment.Center));
        
        return Task.FromResult(UserSelectedOptions);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private static ConsoleKey DisplayMoreInfo(string message)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLineInterpolated($"[yellow underline]{message}[/]");
        while (true)
        {
            var key = AnsiConsole.Console.Input.ReadKey(true);
            return key!.Value.Key;
        }
    }
}
