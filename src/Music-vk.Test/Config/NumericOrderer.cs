using Xunit.Abstractions;
using Xunit.Sdk;

namespace Music_vk.Test.Config
{
    public class NumericOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            return testCases.OrderBy(x => int.Parse(x.TestMethod.Method.Name.Split('_')[1]));
        }
    }
}
