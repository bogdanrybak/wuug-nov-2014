using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System;

namespace Misc
{
    public class Benchmark : MonoBehaviour
    {
        public BenchmarkSubject BenchmarkSubject;

        private ObservableProperty property;
        private float valueToSet;

        public void Profile()
        {
            float testValue = 0.5f;

            property = new ObservableProperty();
            BenchmarkSubject.ObservableProperty = property;
            ProfileAction("Notifier pattern", 1000, () => property.Value = testValue);

            ProfileAction("Direct function call", 1000, () =>
                {
                    valueToSet = testValue;
                    BenchmarkSubject.SetScrollbarValue(valueToSet);
                });
        }

        static void ProfileAction(string description, int iterations, Action func)
        {
            // warm up 
            func();

            var watch = new Stopwatch();

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            UnityEngine.Debug.Log(description);
            UnityEngine.Debug.Log(string.Format(" Time Elapsed {0} ms", watch.Elapsed.TotalMilliseconds));
        }
    }
}