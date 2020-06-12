using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBench;
using ProjectManager.Controllers;

namespace PerformanceTests
{    
    public class TaskPerfTests
    {
        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput,
        TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void PerformanceTests()
        {
            // Set up Prerequisites   
            var controller = new ProjectController();
            // Act on Test  
            var response = controller.RetrieveProjects();
            // Assert the result  
            Assert.IsTrue(response != null);
        }
    }
}
