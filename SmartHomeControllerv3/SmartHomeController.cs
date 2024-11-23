using SmartHomeController;
using System.Net.NetworkInformation;

public class Program
{
    private static List<SmartDevice> devices = new List<SmartDevice>();
    public static void Main()
    {
        MainMenu();
    }

    public static void MainMenu()
    {
        while (true)
        {           
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Install new device");
            Console.WriteLine("2. Control a device");
            Console.WriteLine("3. View all devices");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InstallDeviceMenu();
                    break;
                case "2":
                    ControlDevicesMenu();
                    break;
                case "3":
                    ViewAllDevices();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void InstallDeviceMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Install a device Menu:");
            Console.WriteLine("1. Install new smart light");
            Console.WriteLine("2. Install a new smart security camera");
            Console.WriteLine("3. Install a new smart thermostat");
            Console.WriteLine("4. Install a new smart speaker");
            Console.WriteLine("5. Return to main menu");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InstallSmartLightMenu();
                    break;
                case "2":
                    InstallSmartSecurityCameraMenu();
                    break;
                case "3":
                    InstallSmartThermostatMenu();                  
                    break;
                case "4":
                    InstallSmartSpeakerMenu();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void InstallSmartLightMenu()
    {
        Console.Clear();
        Console.WriteLine("\nInstall Smart Light:");

        Console.Write("Enter Device ID: ");
        int deviceId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter default colour: ");
        string colour = Console.ReadLine();

        Console.Write("Enter Brightness (0-100): ");
        int brightness = Convert.ToInt32(Console.ReadLine());

        SmartLight newLight = new SmartLight(deviceId, name, brightness, colour);
        devices.Add(newLight);

        Console.WriteLine("\nSmart Light Installed:");
        Console.WriteLine($"Device ID: {newLight.DeviceID}");
        Console.WriteLine($"Name: {newLight.DeviceName}");
        Console.WriteLine($"Default colour: {newLight.Colour}");
        Console.WriteLine($"Brightness: {newLight.Brightness}%");

        Console.WriteLine("\nReturning to Main Menu...");
    }

    public static void InstallSmartSecurityCameraMenu()
    {
        Console.Clear(); // Clear the screen
        Console.WriteLine("Install Smart Security Camera:");

        Console.Write("Enter Device ID: ");
        int deviceId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Resolution (e.g., 1080p, 4K): ");
        string resolution = Console.ReadLine();

        SmartSecurityCamera newCamera = new SmartSecurityCamera(deviceId, name, resolution);
        devices.Add(newCamera);

        Console.WriteLine("\nSmart Security Camera Installed:");
        newCamera.GetStatus();

        Console.WriteLine("\nPress any key to return to the Main Menu...");
        Console.ReadKey(); // Wait for user input before returning to the main menu
    }

    public static void InstallSmartSpeakerMenu()
    {
        Console.Clear(); // Clear the screen
        Console.WriteLine("Install Smart Speaker:");

        Console.Write("Enter Device ID: ");
        int deviceId = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Volume (0-100): ");
        int volume = int.Parse(Console.ReadLine());

        SmartSpeaker newSpeaker = new SmartSpeaker(deviceId, name, volume);
        devices.Add(newSpeaker);

        Console.WriteLine("\nSmart Speaker Installed:");
        newSpeaker.GetStatus();

        Console.WriteLine("\nPress any key to return to the Main Menu...");
        Console.ReadKey(); // Wait for user input before returning to the main menu
    }

    public static void InstallSmartThermostatMenu()
    {
        Console.Clear(); // Clear the screen
        Console.WriteLine("Install Smart Thermostat:");

        Console.Write("Enter Device ID: ");
        int deviceId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Current Temperature: ");
        double currentTemperature = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Target Temperature: ");
        double targetTemperature = Convert.ToDouble(Console.ReadLine());

        SmartThermostat newThermostat = new SmartThermostat(deviceId, name, currentTemperature, targetTemperature);
        devices.Add(newThermostat);

        Console.WriteLine("\nSmart Thermostat Installed:");
        newThermostat.GetStatus();

        Console.WriteLine("\nPress any key to return to the Main Menu...");
        Console.ReadKey(); // Wait for user input before returning to the main menu
    }

    public static void TurnOnSmartLight()
    {
        Console.Clear(); // Clear the screen
        Console.WriteLine("Turn On Smart Light:");
        ViewAllDevices();

        Console.Write("Enter Device ID of the light to turn on: ");
        int deviceId = int.Parse(Console.ReadLine());

        SmartLight light = devices.Find(d => d.DeviceID == deviceId && d is SmartLight) as SmartLight;

        if (light != null)
        {
            light.TurnOn();
            Console.WriteLine("\nSmart Light is now ON:");
            light.GetStatus();
        }
        else
        {
            Console.WriteLine("Smart Light not found.");
        }

        Console.WriteLine("\nPress any key to return to the Main Menu...");
        Console.ReadKey(); // Wait for user input before returning to the main menu
    }

    public static void ControlDevicesMenu()
    {
        while (true)
        {
            Console.Clear(); // Clear the screen
            Console.WriteLine("Control Devices Menu:");
            Console.WriteLine("1. Turn On Device");
            Console.WriteLine("2. Turn Off Device");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TurnOnDevice();
                    break;
                case "2":
                    TurnOffDevice();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void TurnOnDevice()
    {
        
        Console.Clear(); // Clear the screen
        Console.WriteLine("Turn On Device:");
        ViewAllDevices();
        Console.Write("Enter Device ID of the device to turn on: ");
        int deviceId = int.Parse(Console.ReadLine());

        SmartDevice device = devices.Find(d => d.DeviceID == deviceId);

        if (device != null)
        {
            device.TurnOn();
            Console.WriteLine("\nDevice is now ON:");
            device.GetStatus();
        }
        else
        {
            Console.WriteLine("Device not found.");
        }

        Console.WriteLine("\nPress any key to return to the Control Devices Menu...");
        Console.ReadKey(); // Wait for user input before returning to the control devices menu
    }

    public static void TurnOffDevice()
    {
        Console.Clear(); // Clear the screen
        Console.WriteLine("Turn Off Device:");

        Console.Write("Enter Device ID of the device to turn off: ");
        int deviceId = int.Parse(Console.ReadLine());

        SmartDevice device = devices.Find(d => d.DeviceID == deviceId);

        if (device != null)
        {
            device.TurnOff();
            Console.WriteLine("\nDevice is now OFF:");
            device.GetStatus();
        }
        else
        {
            Console.WriteLine("Device not found.");
        }

        Console.WriteLine("\nPress any key to return to the Control Devices Menu...");
        Console.ReadKey(); // Wait for user input before returning to the control devices menu
    }

    public static void ViewAllDevices()
    {
        Console.WriteLine("\nAll Devices:");
        foreach (var device in devices)
        {
            device.GetStatus();
            Console.WriteLine(); // Add a blank line between devices for readability
        }
    }




}
