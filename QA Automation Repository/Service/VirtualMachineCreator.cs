using NUnit.Framework;
using TestProject.Model;

namespace TestProject.Service
{
    public class VirtualMachineCreator
    {
        public static VirtualMachine CreateVM()
        {
            return new VirtualMachine(TestContext.Parameters["NumberOfInstances"], 
                TestContext.Parameters["VMSerial"], 
                TestContext.Parameters["VMType"],
                TestContext.Parameters["VMVolume"],
                TestContext.Parameters["NumberOfGPUs"],
                TestContext.Parameters["GPUType"],
                TestContext.Parameters["Region"],
                TestContext.Parameters["CommitedUsage"]);
        }
    }
}
