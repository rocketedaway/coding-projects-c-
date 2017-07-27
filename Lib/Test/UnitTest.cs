using System;

namespace DataStructures.Test 
{
    public class UnitTest<T> : IDisposable
    {
        protected T[] implementations;

        public void Dispose() {}

        protected void PrepareImplementationsForTest(Action<T> prepare)
        {
            foreach(T implementation in implementations)
            {
                prepare(implementation);
            }
        }

        protected void TestImplementations(Action<T> test)
        {
            foreach(T implementation in implementations)
            {
                test(implementation);
            }
        }
    }
}
