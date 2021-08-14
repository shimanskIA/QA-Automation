using System;
using TestProject.Enums;
using TestProject.Utils;

namespace TestProject.Model
{
    public class VirtualMachine
    {
        public uint NumberOfInstances { get; set; }

        public VMSeries VMSerial { get; set; }

        public string VMType { get; set; }

        public string VMVolume { get; set; }

        public uint NumberOfGPUs { get; set; }

        public GPUTypes GPUType { get; set; }

        public string Region { get; set; }

        public uint CommitedUsage { get; set; }

        public VirtualMachine(string numberOfInstances, string vMSerial, string vMType, string vMVolume, string numberOfGPUs, string gPUType, string region, string commitedUsage)
        {
            try
            {
                NumberOfInstances = UInt32.Parse(numberOfInstances);
            }
            catch
            {
                LoggerWrapper.LogError($"Number of instances: {numberOfInstances} is an invalid value");
                throw;
            }
            try
            {
                VMSerial = (VMSeries)Enum.Parse(typeof(VMSeries), vMSerial, true);
            }
            catch
            {
                LoggerWrapper.LogError($"VM serial: {vMSerial} is an invalid value");
                throw;
            }

            VMType = vMType;
            VMVolume = vMVolume;

            try
            {
                NumberOfGPUs = UInt32.Parse(numberOfGPUs);
            }
            catch
            {
                LoggerWrapper.LogError($"Number of GPUs: {numberOfGPUs} is an invalid value");
                throw;
            }
            try
            {
                GPUType = (GPUTypes)Enum.Parse(typeof(GPUTypes), gPUType, true);
            }
            catch
            {
                LoggerWrapper.LogError($"GPU type: {gPUType} is an invalid value");
                throw;
            }

            Region = region;

            try
            {
                CommitedUsage = UInt32.Parse(commitedUsage);
            }
            catch
            {
                LoggerWrapper.LogError($"Commited usage: {commitedUsage} is an invalid value");
                throw;
            }
        }
    }
}
