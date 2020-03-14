// SPDX-License-Identifier: Apache-2.0

#pragma warning disable 649

using System;
using Go2DotNet.Test.Binding.AutoGen;

namespace Go2DotNet.Test.Binding
{
    public class Testing
    {
        // All numerics from Go are treated as double due to syscall/js.
        internal static double StaticField;

        internal static double StaticProperty
        {
            get { return staticProperty; }
            set { staticProperty = value; }
        }
        static double staticProperty;

        internal static string StaticMethod(string arg)
        {
            return arg + " and C#";
        }

        public Testing(string str, double num)
        {
            this.str = str;
            this.num = num;
        }

        internal double InstanceField;

        internal double InstanceProperty
        {
            get { return instanceProperty; }
            set { instanceProperty = value; }
        }
        private double instanceProperty;

        internal string InstanceMethod(string arg)
        {
            return $"str: {this.str}, num: {this.num}, arg: {arg}";
        }

        internal object InvokeGo(IInvokable a, string arg)
        {
            return a.Invoke(new object[] { arg });
        }

        private string str;
        private double num;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Go go = new Go();
            go.Run(args);
        }
    }    
}