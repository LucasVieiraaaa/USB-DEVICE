using System;
using System.Management;

namespace USB
{
    class UsbReader
    {
        public void usbDevices(ManagementObject device)
        {
            if (device["Name"].ToString() != "USB Root Hub (USB 3.0)")
            {
                Console.WriteLine("Dispositivo USB: ");
                Console.WriteLine("  - ID: " + device["DeviceID"]);
                Console.WriteLine("  - Nome: " + device["Name"]);
                Console.WriteLine("  - Status: " + device["Status"]);
                Console.WriteLine("  - Descrição: " + device["Description"] + "\n");
            }
            else
                Console.WriteLine("Entrada USB padrão do sistema detectada \n");
        }
    }
    class Program
    {
        public static void Main()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_USBHub");
            try
            {
                string input = "";
                UsbReader usb = new UsbReader();
                while (true)
                {
                    foreach (ManagementObject device in searcher.Get())
                    {
                        usb.usbDevices(device);
                    }

                    input = Console.ReadLine();

                    if (input == "-1")
                    {
                        break;
                    }
                    else if (input == string.Empty)
                    {
                        Console.Clear();
                    }
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}