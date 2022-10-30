using EnergyCompany.Application.Mediator;
using System.Diagnostics;

namespace EnergyCompany.main;

public class View
{
    public static void Main(string[] args)
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }

    internal static bool MainMenu()
    {
        EndpointMediator endpointMediator = new EndpointMediator();

        Console.Clear();
        Console.WriteLine("===== Energy Company =====");
        Console.WriteLine("\nChoose an option:\n");
        Console.WriteLine("1) Insert a new endpoint");
        Console.WriteLine("2) Edit an existing endpoint");
        Console.WriteLine("3) Delete an existing endpoint");
        Console.WriteLine("4) List all endpoints");
        Console.WriteLine("5) Find a endpoint by serial number");
        Console.WriteLine("6) Exit");
        Console.Write("\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                endpointMediator.InsertEndpoint();
                return ReturnToMainMenu();
            case "2":
                endpointMediator.UpdateEndpoint();
                return ReturnToMainMenu();
            case "3":
                endpointMediator.DeleteEndpoint();
                return ReturnToMainMenu();
            case "4":
                endpointMediator.ListEndpoints();
                return ReturnToMainMenu();
            case "5":
                endpointMediator.FindEndpoint();
                return ReturnToMainMenu();
            case "6":
                return CloseAplication();
            default:
                Console.WriteLine("Choose a valid option");
                return CloseAplication();
        }
    }

    private static bool CloseAplication()
    {
        Console.WriteLine("Do you want to close the application? (Y / N)");
        if (View.confirmation())
        {
            Process.GetCurrentProcess().Kill();
            return false;
        }
        return true;
    }

    private static bool ReturnToMainMenu()
    {
        Console.WriteLine("Do you want to return to Main Menu? (Y / N)");
        if (View.confirmation())
            return true;
        else
            return false;
    }

    private static bool confirmation()
    {
        char value = char.ToUpper(Console.ReadKey().KeyChar);
        while (!value.Equals('Y') && !value.Equals('N'))
        {
            Console.WriteLine("\nInsert a valid value (Y / N)");
            value = char.ToUpper(Console.ReadKey().KeyChar);
        }
        if (value.Equals('N')) return false;
        return true;
    }
}