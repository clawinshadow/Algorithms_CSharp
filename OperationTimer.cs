using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms
{
    internal sealed class OperationTimer : IDisposable
    {
        private Stopwatch m_stopwatch;
        private String m_text;
        private Int32 m_collectionCount;
        public OperationTimer(String text)
        {
            PrepareForOperation();
            m_text = text;
            m_collectionCount = GC.CollectionCount(0);
            // This should be the last statement in this
            // method to keep timing as accurate as possible
            m_stopwatch = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            Console.WriteLine("{0} (GCs={1,3}) {2}", (m_stopwatch.Elapsed),
            GC.CollectionCount(0) - m_collectionCount, m_text);
        }
        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    sealed class AppDomainMonitorDelta : IDisposable 
    {
        private AppDomain m_appDomain;
        private TimeSpan m_thisADCpu;
        private Int64 m_thisADMemoryInUse;
        private Int64 m_thisADMemoryAllocated;
        static AppDomainMonitorDelta() {
        // Make sure that AppDomain monitoring is turned on
        AppDomain.MonitoringIsEnabled = true;
        }
        public AppDomainMonitorDelta(AppDomain ad) {
        m_appDomain = ad ?? AppDomain.CurrentDomain;
        m_thisADCpu = m_appDomain.MonitoringTotalProcessorTime;
        m_thisADMemoryInUse = m_appDomain.MonitoringSurvivedMemorySize;
        m_thisADMemoryAllocated = m_appDomain.MonitoringTotalAllocatedMemorySize;
        }
        public void Dispose() {
        GC.Collect();
        Console.WriteLine("FriendlyName={0}, CPU={1}ms", m_appDomain.FriendlyName,
        (m_appDomain.MonitoringTotalProcessorTime - m_thisADCpu).TotalMilliseconds);

        Console.WriteLine(" Allocated {0:N0} bytes of which {1:N0} survived GCs",
        m_appDomain.MonitoringTotalAllocatedMemorySize - m_thisADMemoryAllocated,
        m_appDomain.MonitoringSurvivedMemorySize - m_thisADMemoryInUse);
        }
    }
}
