using EnergyCompany.Application.Service;
using EnergyCompany.Domain.Entities;
using EnergyCompany.Domain.Enums;
using EnergyCompany.Domain.Exceptions;

namespace EnergyCompany.Application.Mediator
{
    internal class EndpointMediator : IEndpointMediator
    {
        EndpointService endpointService = new EndpointService();

        public void DeleteEndpoint()
        {
            Console.Clear();
            Console.WriteLine("\nDeleting a Endpoint:\n");

            Console.WriteLine("Enter a serial number:");
            string serialNumber = this.readString();

            try
            {
                endpointService.DeleteEndpointById(serialNumber);
                Console.WriteLine("Endpoint deleted!");
            }
            catch (ModelNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FindEndpoint()
        {
            Console.Clear();
            Console.WriteLine("\nSearching for a Endpoint:\n");

            Console.WriteLine("Enter a serial number:");
            string serialNumber = this.readString();

            try
            {
                Endpoint endpoint = endpointService.FindEndpointById(serialNumber);
                printEndpoint(endpoint);
            }
            catch (ModelNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InsertEndpoint()
        {
            string serialNumber, firmwareVersion;
            int meterNumber, state, modelId;

            Console.Clear();
            Console.WriteLine("\nInserting a new Endpoint:\n");

            Console.WriteLine("Enter a serial number:");
            serialNumber = this.readString();

            Console.WriteLine("Choose the equivalent numeric id value");
            Console.WriteLine("NSX1P2W - id: 16");
            Console.WriteLine("NSX1P3W - id: 17");
            Console.WriteLine("NSX2P3W - id: 18");
            Console.WriteLine("NSX3P4W - id: 19");
            Console.WriteLine("Enter a model id:");
            modelId = this.readInt();
            while (!validateMeterModel(modelId))
            {
                Console.WriteLine("Enter a valid option:");
                modelId = this.readInt();
            }

            Console.WriteLine("Enter a meter number:");
            meterNumber = this.readInt();

            Console.WriteLine("Enter a firmware version:");
            firmwareVersion = this.readString();

            Console.WriteLine("Choose the equivalent numeric id value");
            Console.WriteLine("Disconnected - id: 0");
            Console.WriteLine("Connected - id: 1");
            Console.WriteLine("Armed - id: 2");
            Console.WriteLine("Enter a Switch State value:");
            state = this.readInt();
            while (!validateSwitchState(state))
            {
                Console.WriteLine("Enter a valid option:");
                state = this.readInt();
            }

            try
            {
                endpointService.CreateEndpoint(serialNumber, modelId, meterNumber, firmwareVersion, state);
                Console.WriteLine("Endpoint created");
            }
            catch (AlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListEndpoints()
        {
            List<Endpoint> endpoints = endpointService.GetAllEndpoints();
            if(!endpoints.Any())
            {
                Console.WriteLine("List is empty! \n");
                return;
            }
            Console.WriteLine("List of endpoints: \n");
            foreach (Endpoint endpoint in endpoints)
            {
                printEndpoint(endpoint);
            }
        }

        public void UpdateEndpoint()
        {
            Console.Clear();
            Console.WriteLine("\nSearching for a Endpoint:\n");

            Console.WriteLine("Enter a serial number:");
            string serialNumber = this.readString();

            try
            {
                Endpoint endpoint = endpointService.FindEndpointById(serialNumber);
                int value = endpoint.SwitchState;
                Console.WriteLine("Current switch state is: " + Enum.Parse(typeof(ESwitchState), endpoint.SwitchState.ToString()));
                Console.WriteLine("Choose the equivalent numeric id value");
                Console.WriteLine("Disconnected = 0");
                Console.WriteLine("Connected = 1");
                Console.WriteLine("Armed = 2");
                Console.WriteLine("Enter a Switch State value:");
                int state = this.readInt();
                while (!validateSwitchState(state))
                {
                    Console.WriteLine("Enter a valid option:");
                    state = this.readInt();
                }

                endpointService.UpdateEndpointById(serialNumber, state);
                Console.WriteLine("Endpoint updated");
            }
            catch (ModelNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void printEndpoint(Endpoint endpoint)
        {
            Console.WriteLine("=============== Serial Number: " + endpoint.SerialNumber + " ===============");
            Console.WriteLine("Meter model ID: " + Enum.Parse(typeof(EMeterModel), endpoint.MeterModelId.ToString()));
            Console.WriteLine("Meter Number: " + endpoint.MeterNumber);
            Console.WriteLine("Firmware Version: " + endpoint.FirmwareVersion);
            Console.WriteLine("Switch State: " + Enum.Parse(typeof(ESwitchState), endpoint.SwitchState.ToString()));
            Console.WriteLine("\n");
        }
        private bool validateMeterModel(int value)
        {
            if (value != 16 && value != 17 && value != 18 && value != 19) return false;
            return true;
        }

        private bool validateSwitchState(int value)
        {
            if (value != 0 && value != 1 && value != 2) return false;
            return true;
        }

        public string readString()
        {
            string value = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Insert a valid string!");
                value = Console.ReadLine();
            }
            return value;
        }

        public int readInt()
        {
            string value = Console.ReadLine();
            int intValue;
            var valid = int.TryParse(value, out intValue);
            while (valid == false)
            {
                Console.WriteLine("Insert a valid numeric value!");
                value = Console.ReadLine();
                valid = int.TryParse(value, out intValue);
            }
            return intValue;
        }
    }
}
